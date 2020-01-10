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
        private List<IItem> _ListObject;
        public IList<IItem> ListObject { get { return _ListObject; } }
        public bool HasPower { get; private set; }
        public Stack(Coordinate coordinate, bool hasPower)
        {
            _ListObject = new List<IItem>();
            Coordinate = coordinate;
            HasPower = hasPower;
        }
        public Stack(Coordinate coordinate)
        {
            _ListObject = new List<IItem>();
            Coordinate = coordinate;
            HasPower = false;
        }
        //Can be used in a wrong way
        public Stack(Coordinate coordinate, IList<IItem> listObject, bool hasPower)
        {
            _ListObject = listObject.ToList();
            Coordinate = coordinate;
            HasPower = false;
        }
        public int GetWeightKG()
        {
            int totalWeight = 0;
            foreach (IItem objectInList in ListObject)
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
        public bool AddObject(IItem itemToAdd)
        {
            bool canJoin = CanObjectJoin(itemToAdd);

            if (canJoin)
            {
                ListObject.Add(itemToAdd);
            }
            return canJoin;
        }
        public bool CanObjectJoin(IItem itemToAdd)
        {
            bool canJoin = true;

            if (!DoesObjectFitInStack(itemToAdd.WeightKG))
            {
                return false;
            }

            foreach (IItem itemInStack in ListObject)
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
