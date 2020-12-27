using System;
using System.Collections.Generic;
using System.Text;

namespace _05.CustomStack
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;

        }

        public void AddRange(IEnumerable<string> values)
        {
            foreach (var item in values)
            {
                this.Push(item);
            }
        }
    }
}
