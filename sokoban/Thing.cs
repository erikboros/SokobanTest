using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    abstract class Thing
    {
        protected Field ownField;
        protected Thing(Field f)
        {
            ownField = f;
            f.accept(this);
        }

        public void setField(Field f)
        {
            ownField = f;
        }

        public virtual string getName()
        {
            return "thing";
        }
        public void step(direct.direction d)//ez asszem csak playerbe kéne
        {
            ownField.move(d, this);//saját fielden vagy mellette lévőn induljon a "rekurzió" (ez obj)
            
            //saját mellettin kezdődik a move, csöves
            /*
            if (ownField.getNeighbor(d) != null)
            {
                ownField.getNeighbor(d).move(d, this);
            }
            */
            
        }
        public void leave()
        {
            ownField.remove();
        }
    }
}
