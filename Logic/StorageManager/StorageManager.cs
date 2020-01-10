using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class StorageManager 
    {
        public IStorageArea Storage { get; private set; }
        public IList<StackGroup> ListStackGroup { get { return _ListStackGroup; } }
        public List<StackGroup> _ListStackGroup { get; private set; }

        public StorageManager(IStorageArea storage)
        {
            Storage = storage;
            _ListStackGroup = GetListStackInSections();
        }
        //public void AddNewShip(IStorageArea ship)
        //{
        //    ListShip.Add(ship);
        //    IObjectAssigner newStackManager = new ContainerAssigner(this, ship);
        //    ObjectAssigner.Add(newStackManager);
        //}
        private List<StackGroup> GetListStackInSections()
        {
            List<StackGroup> resultListStackGroup = new List<StackGroup>();
            for (int X = 1; X <= Storage.TotalColumns; X += Storage.TotalColumns / 2)
            {
                if (X%2 == 0)
                {
                    resultListStackGroup.Add(new StackGroup(Storage.ListStack, new Coordinate(X, 1), new Coordinate(X + Storage.TotalColumns / 2 - 1, Storage.TotalRows)));
                }
                else
                {
                    if ((Storage.TotalColumns / 2) + 1 == X)
                    {
                        resultListStackGroup.Add(new StackGroup(Storage.ListStack, new Coordinate(X, 1), new Coordinate(X, Storage.TotalRows)));
                        X++;
                    }
                    resultListStackGroup.Add(new StackGroup(Storage.ListStack, new Coordinate(X, 1), new Coordinate(X + Storage.TotalColumns / 2 - 1, Storage.TotalRows)));
                }
            }
            return resultListStackGroup;
        }

        public StackGroup GetStackGroupLowestWeight()
        {
            StackGroup lightestWeightStack = ListStackGroup[0];
            foreach (StackGroup stackGroup in ListStackGroup)
            {
                if (lightestWeightStack.GetTotalWeightKG() > stackGroup.GetTotalWeightKG())
                {
                    lightestWeightStack = stackGroup;
                }
            }
            return lightestWeightStack;
        }


        public List<Stack> GetStacksInFrontAndBehindOfStack(Stack currentStack)
        {
            List<Stack> resultStacksInFrontAndBehind = new List<Stack>();
            foreach (Stack stack in Storage.ListStack)
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
            string http = "https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=" + Storage.TotalRows + "&width=" + Storage.TotalColumns + "&stacks=";
            for (int X = 1; X <= Storage.TotalColumns; X++)
            {
                for (int Y = 1; Y <= Storage.TotalRows; Y++)
                {
                    foreach (Stack stack in Storage.ListStack.ToList())
                    {
                        if (stack.Coordinate.X == X && stack.Coordinate.Y == Y)
                        {
                            foreach (BaseContainer container in stack.ListObject)
                            {
                                http += (int)container.ContainerType;
                            }
                        }
                    }
                    if (Y != Storage.TotalRows)
                    {
                        http += ",";
                    }
                }
                if (X != Storage.TotalColumns)
                {
                    http += "/";
                }
            }

            http += "&weights=";

            for (int X = 1; X <= Storage.TotalColumns; X++)
            {
                for (int Y = 1; Y <= Storage.TotalRows; Y++)
                {
                    foreach (Stack stack in Storage.ListStack.ToList())
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
                    if (Y != Storage.TotalRows)
                    {
                        http += ",";
                    }
                }
                if (X != Storage.TotalColumns)
                {
                    http += "/";
                }
            }

            return http;
        }
    }
}
