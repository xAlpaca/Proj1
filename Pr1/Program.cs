using System;
using System.Collections.Generic;
using System.Linq;
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
    public struct Coord
    {
        public int X;
        public int Y;

        public Coord(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class Hero
    {
        public LinkedList<Coord> tail = new LinkedList<Coord>();
        public Hero()
        {
            tail.AddFirst(new Coord(0,0));
        }

        public int x { get; private set; }
        public int y { get; private set; }
        public int counter;
        public int direction = 0;
        private bool isStepToX = false;
        public void StepToX()
        {
            isStepToX = true;
        }
        
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
            Coord head = tail.First.Value;
            Coord newCoor = new Coord(head.X, head.Y);
            if (newCoor.Y > 0)
            {
                newCoor.Y = newCoor.Y - 1;
            }
            else
            {
                newCoor.Y = Program.Y_MAX - 1;

            }
            tail.AddFirst(newCoor);
            if (isStepToX == true) isStepToX = false;
            else tail.RemoveLast();
        }

        void MoveDown()
        {
            Coord head = tail.First.Value;
            Coord newCoor = new Coord(head.X, head.Y);
            if (newCoor.Y < Program.Y_MAX - 1)
            {
                newCoor.Y += 1;
            }
            else
            {
                newCoor.Y = 0;
            }
            tail.AddFirst(newCoor);
            if (isStepToX == true) isStepToX = false;
            else tail.RemoveLast();
        }

        void MoveLeft()
        {
            Coord head = tail.First.Value;
            Coord newCoor = new Coord(head.X, head.Y);
            if (newCoor.X > 0)
            {
                newCoor.X = newCoor.X - 1;
            }
            else
            {
                newCoor.X = Program.X_MAX - 1 ;
            }
            tail.AddFirst(newCoor);
            if (isStepToX == true) isStepToX = false;
            else tail.RemoveLast();
        }

        void MoveRight()
        {
            Coord head = tail.First.Value;
            Coord newCoor = new Coord(head.X, head.Y);
            if (newCoor.X < Program.X_MAX - 1)
            {
                newCoor.X = newCoor.X + 1;
            }
            else
            {
                newCoor.X = 0;
            }
            tail.AddFirst(newCoor);
            if (isStepToX == true) isStepToX = false;
            else tail.RemoveLast();
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
                System.Threading.Thread.Sleep(277);

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
                            if (cr.tail.Any(cell => cell.X==x && cell.Y==y))
                            {
                                if (cr.tail.First.Value.X == pls.X && cr.tail.First.Value.Y == pls.Y)
                                {
                                    Console.Write("X");
                                }
                                else
                                {
                                    Console.Write("#");
                                }
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
                    if (cr.tail.First.Value.X == pls.X && cr.tail.First.Value.Y == pls.Y)
                    {
                        pls.Reset();
                        cr.StepToX(); 
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





