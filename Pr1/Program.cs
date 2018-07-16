using System;

namespace Pr1
{
    class Hero
    {
        public int x = 0;
        public int y = 0;
        public void Moveup()
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

        public void MoveDown()
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
        public void MoveLeft()
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

        public void MoveRight()
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
            DrawConsole(cr);
            while (true)
            {
                var w = Console.ReadKey();

                if (w.KeyChar.Equals('w'))
                {
                    cr.Moveup();
                }
                
                if (w.KeyChar.Equals('s'))
                {
                    cr.MoveDown();
                }
                
                if (w.KeyChar.Equals('d'))
                {
                    cr.MoveRight();
                }
                
                if (w.KeyChar.Equals('a'))
                {
                    cr.MoveLeft();
                }
                DrawConsole(cr);
            }
        }
        public static void DrawConsole(Hero cr)
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
                                Console.Write("%");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}





