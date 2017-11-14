using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    class Dice
    {
        private Random r = new Random();

        public int roll()
        {
            return r.Next(1, 7);
        }
    }
}
