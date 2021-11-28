using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMoves
{
    public class Counter
    {
        private long myTotal = 0;
        public void Add()
        {
            myTotal += 1;
        }
        public long Total()
        {
            return myTotal;
        }
    }
}
