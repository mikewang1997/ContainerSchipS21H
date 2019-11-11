using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ShipBalancer : IBalancer
    {
        public List<IStackGroup> ListStackGroup { get; private set; }

        public ShipBalancer(List<IStackGroup> listStackGroup)
        {
            ListStackGroup = listStackGroup;
        }

        public IStackGroup GetStackGroupLowestWeight()
        {
            IStackGroup lightestWeightStack = ListStackGroup[0];
            foreach (IStackGroup stackGroup in ListStackGroup)
            {
                if (lightestWeightStack.GetTotalWeightKG() > stackGroup.GetTotalWeightKG())
                {
                    lightestWeightStack = stackGroup;
                }
            }
            return lightestWeightStack;
        }
        public bool IsInBalance()
        {
            bool IsInBalance = true;
            if (!Is50ProcentUsed())
            {
                IsInBalance = false;
            }
            return IsInBalance;
        }
        //private bool IsSideWithinRequiredMargin(IStackGroup stackGroupCompareTo, IStackGroup stackGroupCompareWith)
        //{
        //    int percentageWeightOccupied = (int)((decimal)(sideOfStack) / (decimal)(totalShipWeight) * 100);
        //    if (percentageWeightOccupied <= 60 && percentageWeightOccupied >= 40)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        private bool Is50ProcentUsed()
        {
            int currentWeightKG = 0;
            int totalMaxWeightKG = GetTotalPotentialMaxWeight();
            foreach (IStackGroup stackGroup in ListStackGroup)
            {
                foreach (IStack stack in stackGroup.ListStack)
                {
                    currentWeightKG += stack.GetWeightKG();
                }
            }
            if ((decimal)currentWeightKG / totalMaxWeightKG*100 >= 50)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
        private int GetTotalPotentialMaxWeight()
        {
            int totalPotentialMaxWeight = 0;
            foreach (IStackGroup stackGroup in ListStackGroup)
            {
                totalPotentialMaxWeight += stackGroup.ListStack.Count * 150000;
            }
            return totalPotentialMaxWeight;
        }
    }
}
