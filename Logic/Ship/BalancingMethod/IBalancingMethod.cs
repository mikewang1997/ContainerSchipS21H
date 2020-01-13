using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IBalancingMethod
    {
        bool IsInBalance(Ship ship);
        void PlaceContainers(Ship ship, List<BaseContainer> containersToPlace);
    }
}
