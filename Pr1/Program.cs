using System;

namespace Pr1

{
    public class Point
    {
        Random XY = new Random();
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point()
        {
            Reset();
        }
        public void Reset()
        {
            X = XY.Next(1, Program.X_MAX);
            Y = XY.Next(1, Program.Y_MAX);
        }
    }

    class Hero
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int counter;
        public int direction = 0;
        
        public void Move()
        {
            switch (direction)
            {
                case 0:
                    Moveup();
                    break;
                case 1:
                    MoveDown();
                    break;
                case 2:
                    MoveRight();
                    break;
                case 3:
                    MoveLeft();
                    break;
            }
        }

        void Moveup()
        {
            if (y > 0)
            {
                y = y - 1;
            }
            else
            {
                y = Program.Y_MAX - 1;
            }
        }

        void MoveDown()
        {
            if (y < Program.Y_MAX - 1)
            {
                y += 1;
            }
            else
            {
                y = 0;
            }
        }

        void MoveLeft()
        {
            if (x > 0)
            {
                x = x - 1;
            }
            else
            {
                x = Program.X_MAX - 1 ;
            }

        }

        void MoveRight()
        {
            if (x < Program.X_MAX - 1)
            {
                x = x + 1;
            }
            else
            {
                x = 0;
            }

        }
    }

    class Program
    {
        public const int X_MAX = 40;
        public const int Y_MAX = 20;

        static void Main(String[] args)
        {
            Hero cr = new Hero();
            Point pls = new Point();

            DrawConsole(cr, pls);
            while (true)
            {
                System.Threading.Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.KeyChar.Equals('w'))
                    {
                        cr.direction = 0;
                    }
                    if (key.KeyChar.Equals('s'))
                    {
                        cr.direction = 1;
                    }

                    if (key.KeyChar.Equals('d'))
                    {
                        cr.direction = 2;
                    }

                    if (key.KeyChar.Equals('a'))
                    {
                        cr.direction = 3;
                    }
                }
                cr.Move();
                
                DrawConsole(cr, pls);
            }
        }

        public static void DrawConsole(Hero cr, Point pls)
        {
            Console.Clear();
            for (int y = -1; y < Program.Y_MAX + 1; y++)
            {
                
                for (int x = -1; x < Program.X_MAX + 1; x++)
                {
                    if (y == -1 || y == Program.Y_MAX)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        if (x == -1 || x == Program.X_MAX)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            if (y == cr.y && x == cr.x)
                            {
                                Console.Write("X");
                            }
                            else if (pls.X == x && pls.Y == y)
                            {
                                Console.Write("+");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                    if (cr.y == pls.Y && cr.x == pls.X)
                    {
                        pls.Reset();
                        cr.counter += 1;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Счёт: " + cr.counter);
            
        }
    }
}





