using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Ship
    {
        public int TotalColumns { get; private set; }
        public int TotalRows { get; private set; }
        private IBalancingMethod BalancingMethod;
        private List<Stack> _ListStack;
        public IList<Stack> ListStack {  get{return _ListStack;} }

        public Ship(int totalColumns, int totalRows, IBalancingMethod balancingMethod)
        {
            TotalColumns = totalColumns;
            TotalRows = totalRows;
            InitializeListStacks();
            BalancingMethod = balancingMethod;
        }
        private void InitializeListStacks()
        {
            _ListStack = new List<Stack>();
            for (int x = 1; x <= TotalColumns; x++)
            {
                for (int y = 1; y <= TotalRows; y++)
                {
                    if (y == 1)
                    {
                        _ListStack.Add(new Stack(new Coordinate(x, y), true));
                    }
                    else
                    {
                        _ListStack.Add(new Stack(new Coordinate(x, y)));
                    }
                }
            }
        }
        public int GetTotalWeight()
        {
            int totalWeight = 0;
            foreach (Stack stack in ListStack)
            {
                totalWeight += stack.GetWeightKG();
            }
            return totalWeight;
        }
        public bool AssignObjects(List<IItem> items)
        {
            BalancingMethod.PlaceItems(items);
        }

        public List<Stack> GetStacksInFrontAndBehindOfStack(Stack currentStack)
        {
            List<Stack> resultStacksInFrontAndBehind = new List<Stack>();
            foreach (Stack stack in ListStack)
            {
                if (stack.Coordinate.X == currentStack.Coordinate.X)
                {
                    ////bad code?
                    //if (currentStack.Coordinate.Y == 1)
                    //{
                    //    resultStacksInFrontAndBehind.Add(new Stack(new Coordinate(currentStack.Coordinate.X,1)));
                    //}
                    if (currentStack.Coordinate.Y + 1 == stack.Coordinate.Y || currentStack.Coordinate.Y - 1 == stack.Coordinate.Y)
                    {
                        resultStacksInFrontAndBehind.Add(stack);
                    }
                }
            }
            return resultStacksInFrontAndBehind;
        }
        public string GetStringVisualizer()
        {
            string http = "https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=" + TotalRows + "&width=" + TotalColumns + "&stacks=";
            for (int X = 1; X <= TotalColumns; X++)
            {
                for (int Y = 1; Y <= TotalRows; Y++)
                {
                    foreach (Stack stack in ListStack.ToList())
                    {
                        if (stack.Coordinate.X == X && stack.Coordinate.Y == Y)
                        {
                            foreach (BaseContainer container in stack.ListObject)
                            {
                                http += (int)container.ContainerType;
                            }
                        }
                    }
                    if (Y != TotalRows)
                    {
                        http += ",";
                    }
                }
                if (X != TotalColumns)
                {
                    http += "/";
                }
            }

            http += "&weights=";

            for (int X = 1; X <= TotalColumns; X++)
            {
                for (int Y = 1; Y <= TotalRows; Y++)
                {
                    foreach (Stack stack in ListStack.ToList())
                    {
                        if (stack.Coordinate.X == X && stack.Coordinate.Y == Y)
                        {
                            for (int numContainer = 0; numContainer < stack.ListObject.Count; numContainer++)
                            {
                                http += stack.ListObject[numContainer].GetTonWeight();
                                if (numContainer != stack.ListObject.Count)
                                {
                                    http += "-";
                                }
                            }
                        }
                    }
                    if (Y != TotalRows)
                    {
                        http += ",";
                    }
                }
                if (X != TotalColumns)
                {
                    http += "/";
                }
            }

            return http;
        }

    }
}
