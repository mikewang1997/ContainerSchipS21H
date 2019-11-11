using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IManager
    {
        List<IShip> ListShip { get; }
        List<IStackManager> ListStackManager { get; }
        void AssignObjects(List<IObject> listObject, IShip ship);
        void AddNewShip(IShip ship);
    }
}
