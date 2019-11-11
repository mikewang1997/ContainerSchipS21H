using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class NormalStackContainer : NormalContainer, IStackObject
    {
        public NormalStackContainer(IContainer container) : base(container)
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
