using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LeftRightBalancingMethod : IBalancingMethod
    {

        public LeftRightBalancingMethod()
        {

        }
        //Balancing cant place items because it cant ask 
        public void PlaceItems(Ship containerShip, List<IItem> itemsToPlace)
        {
            List<StackGroup> stackGroups = GetListStackInSections(containerShip.TotalColumns, containerShip.TotalRows, containerShip.ListStack);

            foreach (IItem item in itemsToPlace)
            {

            }
            foreach (StackGroup stackGroup in GetStackGroupSortedOnWeightASC(stackGroups))
            {
                bool isAssigned = false;
                foreach (Stack stack in SortStacksByWeightASC(stackGroup))
                {
                    List<Stack> stacksInFrontAndBehind = containerShip.GetStacksInFrontAndBehindOfStack(stack);

                    CanJoinParams canJoinParams = new CanJoinParams(stack, stacksInFrontAndBehind);
                    if (!containerToAssign.CanJoin.CanJoinStack(canJoinParams))
                    {
                        continue;
                        //canBeAssigned = false;
                    }
                    //if (canBeAssigned)
                    //{
                    isAssigned = stackToUse.AddObject(containerToAssign);
                    //}
                    //CanJoinParams canJoinParams = CanJoinParamsContainerFactory.Build(containerToAssign, stackToUse, StorageManager.GetStacksInFrontAndBehindOfStack(stackToUse));
                    if (isAssigned)
                    {
                        break;
                    }
                }
            }
        }

        //changed
        public bool IsInBalance()
        {
            bool IsInBalance = false;
            if (IsSideWithinRequiredMargin(GetHalfSideOfStorageWeight(storageManager._ListStackGroup), storageManager.Storage.GetTotalWeight()))
            {
                IsInBalance = true;
            }
            return IsInBalance;
        }
        //needed
        private bool IsSideWithinRequiredWeightMargin(int sideWeight, int totalWeightStorage)
        {
            int percentageWeightOccupied = (int)((decimal)(sideWeight) / (decimal)(totalWeightStorage) * 100);
            if (percentageWeightOccupied <= 60 && percentageWeightOccupied >= 40)
            {
                return true;
            }
            return false;
        }
        public int GetHalfSideOfStorageWeight(List<StackGroup> stackGroups)
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
        public List<StackGroup> GetListStackInSections(int totalColumns, int totalRows, IList<Stack> listStack)
        {
            List<StackGroup> resultListStackGroup = new List<StackGroup>();
            for (int X = 1; X <= totalColumns; X += totalColumns / 2)
            {
                if (X % 2 == 0)
                {
                    resultListStackGroup.Add(new StackGroup(listStack, new Coordinate(X, 1), new Coordinate(X + totalColumns / 2 - 1, totalRows)));
                }
                else
                {
                    if ((totalColumns / 2) + 1 == X)
                    {
                        resultListStackGroup.Add(new StackGroup(listStack, new Coordinate(X, 1), new Coordinate(X, totalRows)));
                        X++;
                    }
                    resultListStackGroup.Add(new StackGroup(listStack, new Coordinate(X, 1), new Coordinate(X + totalColumns / 2 - 1, totalRows)));
                }
            }
            return resultListStackGroup;
        }
    }
}
