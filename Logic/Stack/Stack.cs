using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Stack : IStack
    {
        public ICoordinate Coordinate { get; private set; }
        private List<IObject> _ListObject;
        public IList<IObject> ListObject { get { return _ListObject; } }
        public Stack(ICoordinate coordinate)
        {
            _ListObject = new List<IObject>();
            Coordinate = coordinate;
        }
        public int GetWeightKG()
        {
            int totalWeight = 0;
            foreach (IObject objectInList in ListObject)
            {
                totalWeight += objectInList.WeightKG;
            }
            return totalWeight;
        }
        public bool DoesObjectFitInStack(int objectWeightKG)
        {
            int totalStackWeightIfJoined = objectWeightKG += GetWeightKG();
            if (totalStackWeightIfJoined <= 150000)
            {
                return true;
            }
            return false;
        }
        public bool AddObject(IObject objectToAdd)
        {
            bool canObjectJoin = false;
            IStackObject stackObject = (IStackObject)objectToAdd;
            
            if (stackObject.CanJoinStack())
            {
                canObjectJoin = true;
                foreach (IStackObject stackContainerInStack in ListObject)
                {
                    if (!stackContainerInStack.CanObjectJoin())
                    {
                        canObjectJoin = false;
                    }
                }
            }

            if (canObjectJoin)
            {
                ListObject.Add(objectToAdd);
            }

            return canObjectJoin;
        }
    }
}
