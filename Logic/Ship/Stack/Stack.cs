using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Stack
    {
        public Coordinate Coordinate { get; private set; }
        private List<BaseContainer> _ListObject;
        public IList<BaseContainer> ListObject { get { return _ListObject; } }
        public bool HasPower { get; private set; }
        public Stack(Coordinate coordinate, bool hasPower)
        {
            _ListObject = new List<BaseContainer>();
            Coordinate = coordinate;
            HasPower = hasPower;
        }
        public Stack(Coordinate coordinate)
        {
            _ListObject = new List<BaseContainer>();
            Coordinate = coordinate;
            HasPower = false;
        }
        //Can be used in a wrong way
        public Stack(Coordinate coordinate, IList<BaseContainer> listObject, bool hasPower)
        {
            _ListObject = listObject.ToList();
            Coordinate = coordinate;
            HasPower = false;
        }
        public int GetWeightKG()
        {
            int totalWeight = 0;
            foreach (BaseContainer objectInList in ListObject)
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
        public bool AddObject(BaseContainer itemToAdd)
        {
            bool canJoin = CanObjectJoin(itemToAdd);

            if (canJoin)
            {
                ListObject.Add(itemToAdd);
            }
            return canJoin;
        }
        public bool CanObjectJoin(BaseContainer itemToAdd)
        {
            bool canJoin = true;

            if (!DoesObjectFitInStack(itemToAdd.WeightKG))
            {
                return false;
            }

            foreach (BaseContainer itemInStack in ListObject)
            {
                if (!itemInStack.CanJoin.CanObjectJoin(itemToAdd))
                {
                    canJoin = false;
                    break;
                }
            }
            return canJoin;
        }
    }
}
