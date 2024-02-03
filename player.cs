using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorry
{
    class player
    {
        public string Name { get; set; }
        public string Color { get; set; }

        //public int Pawn { get; set; }

        public player() { }

        public player(string color, string name)
        {
            this.Color = color;
            this.Name = name;
            //pawn here
        }
        public string t = "";
        public bool OnGoingTurn()
        {
            if (t.Equals("Y"))
            {
                return false;
            }
            else
                return true;
        }

    }
    //class pawn
    //{

    //}
}