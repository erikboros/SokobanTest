using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    class Warehouse
    {
        private List<Field> fields;
        private List<Player> players;
        private List<Crate> crates;

        public Warehouse()
        {
            fields = new List<Field>();
            players = new List<Player>();
            crates = new List<Crate>();
        }

        public void addField(Field f)
        {
            fields.Add(f);
        }
        public void addPlayer(Player p)
        {
            players.Add(p);
        }
        public void addCrate(Crate c)
        {
            crates.Add(c);
        }
        public void draw()
        {
            Console.Clear();
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    foreach (Field f in fields)
                    {
                        if(f.getX() == i && f.getY() == j)
                        {
                            switch (f.getThing())
                            {
                                case "none":
                                    Console.Write("  |");
                                    break;
                                case "player":
                                    Console.Write(" .|");
                                    break;
                                case "crate":
                                    Console.Write(" x|");
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
                Console.WriteLine("{0}", Environment.NewLine);
            }
        }
    }
}
