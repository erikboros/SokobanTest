using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokoban
{
    class Player : Thing
    {
        
        public Player(Field f) : base(f){
            
        }

        
        public override string getName()
        {
            return "player";
        }
    }
}
