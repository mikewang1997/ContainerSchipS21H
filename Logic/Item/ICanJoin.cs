using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICanJoin
    {
        bool CanObjectJoin(IItem item);
        bool CanJoinStack(CanJoinParams canJoin);
    }
}
