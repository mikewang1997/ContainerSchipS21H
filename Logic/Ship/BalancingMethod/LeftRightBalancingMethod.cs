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
        public void PlaceContainers(Ship ship, List<BaseContainer> containersToPlace)
        {
            foreach (BaseContainer container in GetContainerListSortedByType(containersToPlace))
            {
                bool isAssigned = false;
                //If sinkable just place a container in a stack, if not place containers in a stack in a balancing way
                //if (IsSinkable(ship))
                //{
                //    if (isAssigned)
                //    {
                //        break;
                //    }
                //    foreach (Stack stack in ship.ListStack)
                //    {
                //        //duplicate code, i dont see another fix for now
                //        if (isAssigned)
                //        {
                //            break;
                //        }
                //        List<Stack> stacksInFrontAndBehind = ship.GetStacksInFrontAndBehindOfStack(stack);

                //        CanJoinParams canJoinParams = new CanJoinParams(stack, stacksInFrontAndBehind);
                //        if (!container.CanJoin.CanJoinStack(canJoinParams))
                //        {
                //            continue;
                //        }
                //        isAssigned = stack.AddObject(container);
                //    }
                //}
                //else
                //{
                    List<StackGroup> stackGroups = GetListStackInSections(ship.TotalColumns, ship.TotalRows, ship.ListStack);
                    foreach (StackGroup stackGroup in GetStackGroupSortedOnWeightASC(stackGroups))
                    {
                        if (isAssigned)
                        {
                            break;
                        }
                        foreach (Stack stack in SortStacksByWeightASC(stackGroup))
                        {
                            //duplicate code, i dont see another fix for now
                            if (isAssigned)
                            {
                                break;
                            }
                            List<Stack> stacksInFrontAndBehind = ship.GetStacksInFrontAndBehindOfStack(stack);

                            CanJoinParams canJoinParams = new CanJoinParams(stack, stacksInFrontAndBehind);
                            if (!container.CanJoin.CanJoinStack(canJoinParams))
                            {
                                continue;
                            }
                            isAssigned = stack.AddObject(container);
                        }
                    }
                }
            //}
            //Code smell?
            //if (IsInBalance(ship))
            //{
            //    return true;
            //}
            //return false;
        }
        public bool IsInBalance(Ship ship)
        {
            bool IsInBalance = false;
            List<StackGroup> stackGroups = GetListStackInSections(ship.TotalColumns, ship.TotalRows, ship.ListStack);

            if (HasShipRequiredMargin(stackGroups, ship.GetTotalWeight()) & !IsSinkable(ship))
            {
                IsInBalance = true;
            }
            return IsInBalance;
        }
        private bool HasShipRequiredMargin(List<StackGroup> stackGroups, int totalShipWeight)
        {
            int percentageWeightOccupied = (int)((decimal)(GetHalfSideOfStorageWeight(stackGroups)) / (decimal)(totalShipWeight) * 100);
            if (percentageWeightOccupied <= 60 && percentageWeightOccupied >= 40)
            {
                return true;
            }
            return false;
        }
        //public bool IsStackGroupBalanced(StackGroup stackGroup, Ship ship)
        //{
        //    if (stackGroups.Count%2  > 0)
        //    {

        //    }
        //    int percentageWeightOccupied = (int)((decimal)(stackGroup.GetTotalWeightKG()) / (decimal)(ship.GetTotalWeight()) * 100);
        //    if (percentageWeightOccupied <= 60 && percentageWeightOccupied >= 40)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        private int GetHalfSideOfStorageWeight(List<StackGroup> stackGroups)
        {
            int totalWeightSide = 0;
            for (int i = 0; i <= stackGroups.Count / 2; i++)
            {
                if (stackGroups.Count / 2 <= i)
                {
                    totalWeightSide += (stackGroups[i].GetTotalWeightKG() / 2);
                }
                else
                {
                    totalWeightSide += stackGroups[i].GetTotalWeightKG();
                }
            }
            return totalWeightSide;
        }
        public List<BaseContainer> GetContainerListSortedByType(List<BaseContainer> containersToSort)
        {
            List<BaseContainer> sortedContainers = containersToSort.OrderByDescending(o => o.ContainerType).OrderByDescending(o => o.WeightKG).ToList();
            return sortedContainers;
        }
        private bool IsSinkable(Ship ship)
        {
            List<StackGroup> stackGroups = GetListStackInSections(ship.TotalColumns, ship.TotalRows, ship.ListStack);

            int currentWeightKG = ship.GetTotalWeight();
            int totalMaxWeightKG = ship.GetTotalPotentialMaxWeight();

            if ((decimal)currentWeightKG / totalMaxWeightKG*100 >= 50)
            {
                return false;
            }
            else
            {
                return true; 
            }
        }
        public List<Stack> SortContainerType()
        {
            return null;
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
