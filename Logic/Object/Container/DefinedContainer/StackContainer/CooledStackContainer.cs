using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CooledStackContainer : CooledContainer, IStackContainer
    {
        //Business rule: Cooled containers must be in the first row
        private const int Y = 1;
        private int YaxisToAssign;
        public CooledStackContainer(int weight, int yAxisToAssign) : base(weight)
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
