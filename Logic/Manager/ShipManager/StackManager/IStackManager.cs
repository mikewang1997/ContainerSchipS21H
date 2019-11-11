using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IStackManager
    {
        IManager Manager { get; }
        IShip Ship { get; }
        void CanObjectJoin();
        void AssignObjects(IList<IObject> listObjects);

    }
}
