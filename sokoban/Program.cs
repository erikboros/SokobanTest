using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    class Program
    {

        static void Main(string[] args)
        {
            Warehouse map = new Warehouse();

            Field[,] tmp = new Field[10,10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tmp[i,j] = new Field(i, j);
                    map.addField(tmp[i,j]);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i >= 1)
                    {
                        tmp[i, j].addNeighbor(direct.direction.up, tmp[i - 1, j]);
                    }
                    else
                    {
                        tmp[i, j].addNeighbor(direct.direction.up, null);
                    }
                    if (i < 9)
                    {
                        tmp[i, j].addNeighbor(direct.direction.down, tmp[i + 1, j]);
                    }
                    else
                    {
                        tmp[i, j].addNeighbor(direct.direction.down, null);
                    }
                    if (j >= 1)
                    {
                        tmp[i, j].addNeighbor(direct.direction.left, tmp[i, j-1]);
                    }
                    else
                    {
                        tmp[i, j].addNeighbor(direct.direction.left, null);
                    }
                    if (j < 9)
                    {
                        tmp[i, j].addNeighbor(direct.direction.right, tmp[i, j + 1]);
                    }
                    else
                    {
                        tmp[i, j].addNeighbor(direct.direction.right, null);
                    }
                }
            }

            
            Crate c1 = new Crate(tmp[2, 2]);
            Crate c2 = new Crate(tmp[2, 3]);
            Crate c3 = new Crate(tmp[3, 3]);
            Crate c4 = new Crate(tmp[4, 3]);
            Crate c5 = new Crate(tmp[5, 5]);

            Player p1 = new Player(tmp[0,0]);


            map.draw();


            while (true)
            {
                
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.LeftArrow:
                        //Console.Clear();
                        //Console.WriteLine("left");
                        p1.step(direct.direction.left);
                        map.draw();
                        break;
                    case ConsoleKey.UpArrow:
                        //Console.Clear();
                        //Console.WriteLine("up");
                        p1.step(direct.direction.up);
                        map.draw();
                        break;
                    case ConsoleKey.RightArrow:
                        //Console.Clear();
                        //Console.WriteLine("right");
                        p1.step(direct.direction.right);
                        map.draw();
                        break;
                    case ConsoleKey.DownArrow:
                        //Console.Clear();
                        //Console.WriteLine("down");
                        p1.step(direct.direction.down);
                        map.draw();
                        break;
                    
                    default:
                        break;
                }

            }

            //Console.ReadKey();





        }
    }
}
