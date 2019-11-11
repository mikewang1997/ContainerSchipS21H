using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IStack
    {
        ICoordinate Coordinate { get; }
        IList<IObject> ListObject { get; }
        int GetWeightKG();
        bool DoesObjectFitInStack(int objectWeightKG);
        bool AddObject(IObject objectToAdd);
    }
}
