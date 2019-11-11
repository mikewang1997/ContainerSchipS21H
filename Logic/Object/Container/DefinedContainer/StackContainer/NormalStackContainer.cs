using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class NormalStackContainer : NormalContainer, IStackContainer
    {
        public NormalStackContainer(int weight) : base(weight)
        {

        }

        public bool CanObjectJoin()
        {
            return true;
        }

        public bool CanJoinStack()
        {
            return true;
        }
    }
}
