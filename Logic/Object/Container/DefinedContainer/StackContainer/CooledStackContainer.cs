using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CooledStackContainer : CooledContainer, IStackObject
    {
        //Business rule: Cooled containers must be in the first row
        private const int Y = 1;
        private int YaxisToAssign;
        public CooledStackContainer(IContainer container, int yAxisToAssign) : base(container)
        {
            YaxisToAssign = yAxisToAssign;
        }
        public bool CanObjectJoin()
        {
            return true;
        }
        public bool CanJoinStack()
        {
            if (YaxisToAssign == Y)
            {
                return true;
            }
            return false;
        }
    }
}
