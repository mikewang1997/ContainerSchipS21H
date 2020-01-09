using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CanJoinParams
    {
        public Stack Stack { get; private set; }
        public List<Stack> StacksInFrontAndBehind { get; private set; }
        public CanJoinParams(Stack stack, List<Stack> stacksInFrontAndBehind)
        {
            Stack = stack;
            StacksInFrontAndBehind = stacksInFrontAndBehind;
        }
        public CanJoinParams(Stack stack)
        {
            Stack = stack;
            StacksInFrontAndBehind = null;
        }
    }
}
