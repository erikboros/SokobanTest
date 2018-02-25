using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    class Crate : Thing
    {
        public Crate(Field f) : base(f) { }

        public override string getName()
        {
            return "crate";
        }
    }
}
