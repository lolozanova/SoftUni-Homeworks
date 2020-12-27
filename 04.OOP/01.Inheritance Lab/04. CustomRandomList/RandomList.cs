using System;
using System.Collections.Generic;
using System.Text;

namespace _04._CustomRandomList
{
    class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int index = random.Next(0, this.Count);
            string element = this[index];

            this.RemoveAt(index);
            return element;
        }
    }
}
