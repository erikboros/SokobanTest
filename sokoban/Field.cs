using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    class Field
    {
        private Dictionary<direct.direction, Field> neighbors;
        private Thing ownThing;
        private int x;
        private int y;

        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }

        public Field(int x, int y)
        {
            neighbors = new Dictionary<direct.direction, Field>();
            ownThing = null;
            this.x = x;
            this.y = y;

        }

        public void addNeighbor(direct.direction d, Field f)
        {
            neighbors.Add(d, f);
        }
        public void accept(Thing t)//private kéne legyen de most ezzel van inicializáva a tárgyak helye
        {
            t.leave();
            //Console.WriteLine("accepted to {0}{1}", x, y);
            ownThing = t;
            t.setField(this);
        }
        public string getThing()
        {
            if (ownThing != null)
            {
                return ownThing.getName();
            }
            return "none";
        }
        public void remove()
        {
            //Console.WriteLine("removed from {0}{1}", x, y);
            ownThing = null;
        }

        //a szomszédtól kéne indítani a rekurziót?
        public Field getNeighbor(direct.direction d)
        {
            return neighbors[d];
        }


        public bool move(direct.direction d, Thing t)
        {
            //Console.WriteLine("move stack: {0} {1}", x, y);
            //kaptunk egy mozgatás kérést

            /* ///pronyó: csak az utolsó lép a sor végén...
            if (ownThing==null)                             //HA nincs rajtunk semmi akkor
            {
                    accept(t);//elfogadjuk az érkezőt (ez értesíti őt és szól az előzőjének h leavel)                            
                    return true;//visszatér a többinek               
            }
            else if(neighbors[d] != null )                  //HA van rajtunk valami de van még tovább abban az irányban szomszéd
            {
                return neighbors[d].move(d, ownThing); //visszaadjuk az abban az irányban történt mozgások eredményét : lehetett e tolni arra
            }
            else                                            //HA van rajtunk valami ÉS nincs tovább mező abban az irányban
            {
                return false; //visszatérünk azzal h nem történt mozgatás
            }
            */


            //az aktuálisan elfoglalt field mellettire kezdődik a "rekurzió"
            //ha ezt a saját mezőjére hívnánk, a rekurzió végén magára is lefutna és mindig visszaléptetné magára a tárgyat...
            /*
            if (ownThing == null || (neighbors[d] != null && neighbors[d].move(d, ownThing)))          //HA nincs rajtunk semmi VAGY lehet a szomszédokon léptetni / tolni
            {
                
                accept(t);//elfogadjuk az érkezőt (ez értesíti őt és szól az előzőjének h leavel)                            
                return true;//visszatér a többinek               
            }
            else    //HA van rajtunk valami ÉS nem lehet tovább léptetni abban az irányban abban az irányban
            {
                return false; //visszatérünk azzal h nem történt mozgatás
            }
            */


            //MŰKÖDIK
            
            if (t == ownThing)//HA saját magunk objektumát kapnánk meg, mint átvenni kívánt, akkor most kezdtük a léptetést, folytassuk a szomszéddal
            {
                if (neighbors[d] != null)//HA a szomszéd létezik
                {
                    return neighbors[d].move(d, ownThing); //elkezdjük a rekurziót
                }
                else
                {
                    return false;//HA nincs zsomszéd, nem léptetünk
                }
            }
            else if (ownThing == null || (neighbors[d] != null && neighbors[d].move(d, ownThing)))          //HA nincs rajtunk semmi VAGY lehet a szomszédokon léptetni / tolni
            {

                accept(t);//elfogadjuk az érkezőt (ez értesíti őt és szól az előzőjének h leavel)                            
                return true;//visszatér a többinek               
            }
            else    //HA van rajtunk valami ÉS nem lehet tovább léptetni abban az irányban abban az irányban
            {
                return false; //visszatérünk azzal h nem történt mozgatás
            }
        }
        
    }
}
