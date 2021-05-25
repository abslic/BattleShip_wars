using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

        
            
namespace Battleship_Console
    {
        public class Battleship//(Морской бой)
        {
            protected const int four = 1;
            protected const int three = 2;
            protected const int two = 3;
            protected const int one = 4;
            public int[,] Field1 = new int[10, 10]; //0 - пустая клетка, 1 - корабль, 2 - попадание по кораблю, 3 - промах
            public static readonly string[] str1 = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            public static readonly string[] str2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            public int Step = new int();
            protected int[] Letter = new int[101];
            protected int[] Index = new int[101];
            public int Points = 0;
            public static int Indent = 2;
            public int Number = 0;

            protected static int[,] BotField = new int[10, 10];

            protected static int[,] UserField = new int[10, 10];

            public void Output(int[,] Field)
            {
                if (Indent > 20)
                {
                    Indent = 2;
                    Console.Clear();
                }
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(2 * i + 3, 0);
                    Console.Write(str1[i]);
                }
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(0, i + 1);
                    Console.Write(str2[i]);
                    Console.SetCursorPosition(2, i + 1);
                    Console.Write("| ");
                    for (int j = 0; j < 10; j++)
                    {
                        Console.SetCursorPosition(2 * j + 3, i + 1);
                        Part(UserField[i, j]);
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(2 * i + 3, 13);
                    Console.Write(str1[i]);
                }
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(0, i + 14);
                    Console.Write(str2[i]);
                    Console.SetCursorPosition(2, i + 14);
                    Console.Write("| ");
                    for (int j = 0; j < 10; j++)
                    {
                        Console.SetCursorPosition(2 * j + 3, i + 14);
                        Part(Field[i, j]);

                    }
                }
            }
            public void Part(int a)
            {
                switch (a)
                {
                    case 0:
                        Console.Write('*');
                        break;
                    case 1:
                        Console.Write('\u25A0');
                        break;
                    case 2:
                        Console.Write('█');
                        break;
                    case 3:

                        Console.Write('☼');
                        break;
                }
            }
            protected void Stroke(int[,] Field, int i, int j)
            {
                int Long = 1;
                int x = j;
                int y = i;
                for (int k = 1; k < 4; k++)
                {
                    try
                    {
                        if (Field[i - k, j] == 2)
                        {
                            Long++;
                            y--;
                        }
                        if (Field[i - k, j] == 1)
                        {
                            return;
                        }
                        if (Field[i - k, j] == 0 || Field[i - k, j] == 3)
                        {
                            break;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
                for (int k = 1; k < 4; k++)
                {
                    try
                    {
                        if (Field[i + k, j] == 2)
                        {
                            Long++;
                        }
                        if (Field[i + k, j] == 1)
                        {
                            return;
                        }
                        if (Field[i + k, j] == 0 || Field[i + k, j] == 3)
                        {
                            break;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
                if (Long > 1)
                {
                    for (int k = y - 1; k < y + Long + 1 && k < 10; k++)
                    {
                        if (k < 0)
                        {
                            k++;
                        }
                        for (int l = x - 1; l < x + 2 && l < 10; l++)
                        {
                            if (l < 0)
                            {
                                l++;
                            }
                            if (Field[k, l] != 2)
                            {
                                Field[k, l] = 3;
                                Field1[k, l] = 3;
                            }
                        }
                    }
                    return;
                }

                for (int k = 1; k < 4; k++)
                {
                    try
                    {
                        if (Field[i, j - k] == 2)
                        {
                            Long++;
                            x--;
                        }
                        if (Field[i, j - k] == 1)
                        {
                            return;
                        }
                        if (Field[i, j - k] == 0 || Field[i, j - k] == 3)
                        {
                            break;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
                for (int k = 1; k < 4; k++)
                {
                    try
                    {
                        if (Field[i, j + k] == 2)
                        {
                            Long++;
                        }
                        if (Field[i, j + k] == 1)
                        {
                            return;
                        }
                        if (Field[i, j + k] == 0 || Field[i, j + k] == 3)
                        {
                            break;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
                if (Long > 1)
                {
                    for (int l = y - 1; l < y + 2 && l < 10; l++)
                    {
                        for (int k = x - 1; k < x + Long + 1 && k < 10; k++)
                        {
                            if (k < 0)
                            {
                                k++;
                            }
                            if (l < 0)
                            {
                                l++;
                            }
                            if (Field[l, k] != 2)
                            {
                                Field[l, k] = 3;
                                Field1[l, k] = 3;
                            }
                        }
                    }
                    return;
                }

                if (Long == 1)
                {
                    for (int k = y - 1; k < y + 2 && k < 10; k++)
                    {
                        if (k < 0)
                        {
                            k = 0;
                        }
                        for (int l = x - 1; l < x + 2 && l < 10; l++)
                        {
                            if (l < 0)
                            {
                                l = 0;
                            }
                            if (Field[k, l] != 2)
                            {
                                Field[k, l] = 3;
                                Field1[k, l] = 3;
                            }
                        }
                    }
                }
            }
        }

        public class User : Battleship
        {
            public User()
            {
                Console.Write("Случайная расстановка кораблей? ");
                if (Console.ReadLine() == "y")
                {
                    Console.Clear();
                    Number = 0;
                    Four();
                    while (Number < three)
                    {
                        Three();
                    }
                    Number = 0;
                    while (Number < two)
                    {
                        Two();
                    }
                    Number = 0;
                    while (Number < one)
                    {
                        One();
                    }
                }
            }

            public void Strike()
            {
                if (Win())
                {
                    return;
                }
                Console.SetCursorPosition(30, Indent++);
                Console.WriteLine("Выстрел №: " + ++Step);
                Boolean letter = true;
                while (letter)
                {
                    Console.SetCursorPosition(30, Indent++);
                    Console.Write("Ваш выстрел: ");
                    switch (Console.Read())
                    {
                        case 'a':
                            Letter[Step] = 0;
                            letter = false;
                            break;
                        case 'b':
                            Letter[Step] = 1;
                            letter = false;
                            break;
                        case 'c':
                            Letter[Step] = 2;
                            letter = false;
                            break;
                        case 'd':
                            Letter[Step] = 3;
                            letter = false;
                            break;
                        case 'e':
                            Letter[Step] = 4;
                            letter = false;
                            break;
                        case 'f':
                            Letter[Step] = 5;
                            letter = false;
                            break;
                        case 'g':
                            Letter[Step] = 6;
                            letter = false;
                            break;
                        case 'h':
                            Letter[Step] = 7;
                            letter = false;
                            break;
                        case 'i':
                            Letter[Step] = 8;
                            letter = false;
                            break;
                        case 'j':
                            Letter[Step] = 9;
                            letter = false;
                            break;
                    }
                }
                Index[Step] = Convert.ToInt32(Console.ReadLine()) - 1;
                if (Hit(Index[Step], Letter[Step]))
                {
                    Points++;
                    Strike();
                }
            }

            public bool Hit(int i, int j)
            {
                if (BotField[i, j] == 0)
                {
                    BotField[i, j] = 3;
                    Field1[i, j] = 3;
                    Output(Field1);
                    Console.SetCursorPosition(30, 0);
                    Console.Write("Промах!   ");
                    return false;
                }
                if (BotField[i, j] == 1)
                {
                    BotField[i, j] = 2;
                    Field1[i, j] = 2;
                    Stroke(BotField, i, j);
                    Output(Field1);
                    Console.SetCursorPosition(30, 0);
                    Console.Write("Попадание!");
                    return true;
                }
                Console.SetCursorPosition(30, 0);
                Console.Write("Нельзя стрелять в эту клетку");
                Console.SetCursorPosition(30, 4);
                Console.WriteLine();
                Step--;
                return true;
            }

            public bool Win()
            {
                if (Points == 20)
                {
                    Console.SetCursorPosition(10, 0);
                    Console.Write("Вы победили!");
                    return true;
                }
                return false;
            }

            private void Four()
            {
                var random = new Random();
                int x = random.Next(10);
                int y = random.Next(10);
                if (x > 5)
                {
                    y = random.Next(5);
                    for (int i = y; i < y + 4; i++)
                    {
                        UserField[i, x] = 1;
                    }
                    return;
                }
                if (y > 5)
                {
                    x = random.Next(5);
                    for (int j = x; j < x + 4; j++)
                    {
                        UserField[y, j] = 1;
                    }
                    return;
                }
                int k = random.Next(1);
                if (k == 0)
                {
                    for (int i = y; i < y + 4; i++)
                    {
                        UserField[i, x] = 1;
                    }
                }
                else
                {
                    for (int j = x; j < x + 4; j++)
                    {
                        UserField[y, j] = 1;
                    }
                }
            }
            private void Three()
            {
                var random = new Random();
                var x = random.Next(10);
                var y = random.Next(10);
                if (y > 6)
                {
                    x = random.Next(7);
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 4; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (UserField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 3; j++)
                    {
                        UserField[y, j] = 1;
                    }
                    Number++;
                    return;
                }
                if (x > 6)
                {
                    y = random.Next(7);
                    for (int i = y - 1; i < y + 4; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            {
                                if (UserField[i, j] != 0)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    for (int i = y; i < y + 3; i++)
                    {
                        UserField[i, x] = 1;
                    }
                    Number++;
                    return;
                }
                int k = random.Next(1);
                if (k == 0)
                {
                    for (int i = y - 1; i < y + 4; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (UserField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int i = y; i < y + 3; i++)
                    {
                        UserField[i, x] = 1;
                    }
                    Number++;
                }
                else
                {
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 4; j++)
                        {
                            if (j < 0)
                            {
                                j = 0;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (UserField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 3; j++)
                    {
                        UserField[y, j] = 1;
                    }
                    Number++;
                }
            }
            private void Two()
            {
                var random = new Random();
                var x = random.Next(10);
                var y = random.Next(10);
                if (y > 7)
                {
                    x = random.Next(8);
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 3; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (UserField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 2; j++)
                    {
                        UserField[y, j] = 1;
                    }
                    Number++;
                    return;
                }
                if (x > 7)
                {
                    y = random.Next(8);
                    for (int i = y - 1; i < y + 3; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (UserField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int i = y; i < y + 2; i++)
                    {
                        UserField[i, x] = 1;
                    }
                    Number++;
                    return;
                }
                int k = random.Next(1);
                if (k == 0)
                {
                    for (int i = y - 1; i < y + 3; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (UserField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int i = y; i < y + 2; i++)
                    {
                        UserField[i, x] = 1;
                    }
                    Number++;
                }
                else
                {
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 3; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (UserField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 2; j++)
                    {
                        UserField[y, j] = 1;
                    }
                    Number++;
                }
            }
            private void One()
            {
                var random = new Random();
                var x = random.Next(10);
                var y = random.Next(10);
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                UserField[y, x] = 1;
                Number++;
            }
        }

        public class Bot : Battleship
        {
            public Bot()
            {
                Four();
                while (Number < three)
                {
                    Three();
                }
                Number = 0;
                while (Number < two)
                {
                    Two();
                }
                Number = 0;
                while (Number < one)
                {
                    One();
                }
            }

            public void Strike()
            {
                if (Win())
                {
                    return;
                }
                Random();
                Console.SetCursorPosition(30, Indent++);
                Console.WriteLine("Выстрел противника: " + str1[Letter[Step]] + (Index[Step] + 1));
                if (Hit(Index[Step], Letter[Step]))
                {
                    Step++;
                    Points++;
                    Strike();
                }
            }

            private void Random()
            {
                var random = new Random(DateTime.Now.Millisecond);
                Letter[Step] = random.Next(9);
                Index[Step] = random.Next(9);
                if (Field1[Index[Step], Letter[Step]] > 0)
                {
                    Random();
                }
            }

            public bool Hit(int i, int j)
            {
                if (UserField[i, j] == 0)
                {
                    Field1[i, j] = 3;
                    UserField[i, j] = 3;
                    return false;
                }
                if (UserField[i, j] == 1)
                {
                    Field1[i, j] = 2;
                    UserField[i, j] = 2;
                    Stroke(UserField, i, j);
                    return true;
                }
                if (UserField[i, j] > 1)
                {
                    return false;
                }
                return false;
            }

            public bool Win()
            {
                if (Points == 20)
                {
                    Console.SetCursorPosition(10, 0);
                    Console.Write("Вы проиграли!");
                    return true;
                }
                return false;
            }

            private void Four()
            {
                var random = new Random();
                int x = random.Next(10);
                int y = random.Next(10);
                if (x > 5)
                {
                    y = random.Next(5);
                    for (int i = y; i < y + 4; i++)
                    {
                        BotField[i, x] = 1;
                    }
                    return;
                }
                if (y > 5)
                {
                    x = random.Next(5);
                    for (int j = x; j < x + 4; j++)
                    {
                        BotField[y, j] = 1;
                    }
                    return;
                }
                int k = random.Next(1);
                if (k == 0)
                {
                    for (int i = y; i < y + 4; i++)
                    {
                        BotField[i, x] = 1;
                    }
                }
                else
                {
                    for (int j = x; j < x + 4; j++)
                    {
                        BotField[y, j] = 1;
                    }
                }
            }
            private void Three()
            {
                var random = new Random();
                var x = random.Next(10);
                var y = random.Next(10);
                if (y > 6)
                {
                    x = random.Next(7);
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 4; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (BotField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 3; j++)
                    {
                        BotField[y, j] = 1;
                    }
                    Number++;
                    return;
                }
                if (x > 6)
                {
                    y = random.Next(7);
                    for (int i = y - 1; i < y + 4; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (BotField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int i = y; i < y + 3; i++)
                    {
                        BotField[i, x] = 1;
                    }
                    Number++;
                    return;
                }
                int k = random.Next(1);
                if (k == 0)
                {
                    for (int i = y - 1; i < y + 4; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (BotField[i, j] != 0)
                            {
                                return;
                            }

                        }
                    }
                    for (int i = y; i < y + 3; i++)
                    {
                        BotField[i, x] = 1;
                    }
                    Number++;
                }
                else
                {
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 4; j++)
                        {
                            if (j < 0)
                            {
                                j = 0;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (BotField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 3; j++)
                    {
                        BotField[y, j] = 1;
                    }
                    Number++;
                }
            }
            private void Two()
            {
                var random = new Random();
                var x = random.Next(10);
                var y = random.Next(10);
                if (y > 7)
                {
                    x = random.Next(8);
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 3; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (BotField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 2; j++)
                    {
                        BotField[y, j] = 1;
                    }
                    Number++;
                    return;
                }
                if (x > 7)
                {
                    y = random.Next(8);
                    for (int i = y - 1; i < y + 3; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j > 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (BotField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int i = y; i < y + 2; i++)
                    {
                        BotField[i, x] = 1;
                    }
                    Number++;
                    return;
                }
                int k = random.Next(1);
                if (k == 0)
                {
                    for (int i = y - 1; i < y + 3; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (BotField[i, j] != 0)
                            {
                                return;
                            }

                        }
                    }
                    for (int i = y; i < y + 2; i++)
                    {
                        BotField[i, x] = 1;
                    }
                    Number++;
                }
                else
                {
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 3; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (BotField[i, j] != 0)
                            {
                                return;
                            }

                        }
                    }
                    for (int j = x; j < x + 2; j++)
                    {
                        BotField[y, j] = 1;
                    }
                    Number++;
                }
            }
            private void One()
            {
                var random = new Random();
                var x = random.Next(10);
                var y = random.Next(10);
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (BotField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                BotField[y, x] = 1;
                Number++;
            }
        }

        internal class Program
        {
            public static void Main(string[] args)
            {
                var User = new User();
                var Bot = new Bot();
                Boolean yes = true;
                while (yes)
                {
                    while (true)
                    {
                        User.Output(User.Field1);
                        User.Strike();
                        if (User.Win())
                        {
                            break;
                        }
                        Bot.Strike();
                        if (Bot.Win())
                        {
                            break;
                        }
                    }
                    Console.SetCursorPosition(30, 1);
                    Console.WriteLine("Спасибо за игру! Хотите сыграть еще раз? ");
                    if (Console.ReadLine() != "y")
                    {
                        yes = false;
                    }
                }
            }
        }
    }

    

