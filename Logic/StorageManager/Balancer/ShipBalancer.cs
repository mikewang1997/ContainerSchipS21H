using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ShipBalancer : IBalancer
    {
        public ShipBalancer()
        {

        }
        public bool IsInBalance(StorageManager storageManager)
        {
            bool IsInBalance = false;
            if (IsSideWithinRequiredMargin(GetHalfOfStorageWeight(storageManager._ListStackGroup), storageManager.Storage.GetTotalWeight()))
            {
                IsInBalance = true;
            }
            return IsInBalance;
        }
        private bool IsSideWithinRequiredMargin(int weightHalfSizeOfStorage, int totalWeightStorage)
        {
            int percentageWeightOccupied = (int)((decimal)(weightHalfSizeOfStorage) / (decimal)(totalWeightStorage) * 100);
            if (percentageWeightOccupied <= 60 && percentageWeightOccupied >= 40)
            {
                return true;
            }
            return false;
        }
        public int GetHalfOfStorageWeight(List<StackGroup> stackGroups)
        {
            int totalWeightSide = 0;
            for (int i = 0; i <= stackGroups.Count/2; i++)
            {
                if (stackGroups.Count/2 >= i)
                {
                    totalWeightSide += (stackGroups[i].GetTotalWeightKG()/2);
                }
                else
                {
                    totalWeightSide += stackGroups[i].GetTotalWeightKG();
                }
            }
            return totalWeightSide;
        }
        public bool IsSinkable(List<StackGroup> listStackGroup)
        {
            int currentWeightKG = 0;
            int totalMaxWeightKG = GetTotalPotentialMaxWeight(listStackGroup);
            foreach (StackGroup stackGroup in listStackGroup)
            {
                foreach (Stack stack in stackGroup.ListStack)
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
        private int GetTotalPotentialMaxWeight(List<StackGroup> listStackGroup)
        {
            int totalPotentialMaxWeight = 0;
            foreach (StackGroup stackGroup in listStackGroup)
            {
                totalPotentialMaxWeight += stackGroup.ListStack.Count * 150000;
            }
            return totalPotentialMaxWeight;
        }
        public List<StackGroup> GetStackGroupSortedOnWeightASC(List<StackGroup> listStackGroup)
        {
            //IList<StackGroup> currentStackGroup = GetListStackInSections();
            List<StackGroup> sortedStackGroupResult = listStackGroup.OrderBy(o => o.GetTotalWeightKG()).ToList();
            return sortedStackGroupResult;
        }
        public List<Stack> SortStacksByWeightASC(StackGroup stackGroup)
        {
            List<Stack> sortedStacksByWeightASC = stackGroup.ListStack.OrderBy(o => o.GetWeightKG()).ToList();
            return sortedStacksByWeightASC;
        }
    }
}
