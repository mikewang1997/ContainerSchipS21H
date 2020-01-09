using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DefaultContainerRules : ICanJoin
    {
        public bool CanObjectJoin(IItem item)
        {
            return true;
        }

        public bool CanJoinStack(CanJoinParams canJoin)
        {
            return true;
        }
    }
}
