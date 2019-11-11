using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class StackManager : IStackManager
    {
        public IManager Manager { get; private set; }
        public IShip Ship { get; private set; }
        public IBalancer ShipBalancer { get; private set; }

        public StackManager(IManager manager, IShip ship)
        {
            Manager = manager;
            Ship = ship;
            ShipBalancer = new ShipBalancer(GetListStackInSections().ToList());
        }
        public void AssignObjects(IList<IObject> listObjects)
        {
            foreach (IObject objectToAssign in listObjects)
            {
                foreach (IStack stackToUse in ShipBalancer.GetStackGroupLowestWeight().ListStack)
                {
                    IStackObject stackObject = StackObjectFactory.Build(objectToAssign, GetStacksInFrontAndBehindOfStack(stackToUse), stackToUse.Coordinate.Y);
                    if (stackToUse.DoesObjectFitInStack(objectToAssign.WeightKG))
                    {
                        if (stackToUse.AddObject(stackObject))
                        {
                            break;
                        }
                        
                    }
                }
            }
            Console.WriteLine(Ship.ListStack);
        }

        public List<IStack> GetStacksInFrontAndBehindOfStack(IStack currentStack)
        {
            List<IStack> resultStacksInFrontAndBehind = new List<IStack>();
            foreach (IStack stack in Ship.ListStack)
            {
                if (stack.Coordinate.X == currentStack.Coordinate.X)
                {
                    if (currentStack.Coordinate.Y + 1 == stack.Coordinate.Y || currentStack.Coordinate.Y - 1 == stack.Coordinate.Y)
                    {
                        resultStacksInFrontAndBehind.Add(stack);
                    }
                }
            }
            return resultStacksInFrontAndBehind;
        }

        public IList<IStackGroup> GetListStackInSections()
        {
            List<IStackGroup> resultListStackGroup = new List<IStackGroup>();
            for (int X = 1; X <= Ship.TotalColumns; X+=Ship.TotalColumns/2)
            {
                //check if ship is odd number
                if (Ship.TotalColumns%2 > 0)
                {
                    if ((Ship.TotalColumns / 2) + 1 == X)
                    {
                        resultListStackGroup.Add(new StackGroup(Ship.ListStack, new Coordinate(X, 1), new Coordinate(X, Ship.TotalRows)));
                    }
                }
                else
                {
                    resultListStackGroup.Add(new StackGroup(Ship.ListStack, new Coordinate(X, 1), new Coordinate(X+Ship.TotalColumns/2-1, Ship.TotalRows)));
                }
            }
            return resultListStackGroup;
        }
        public void AssignShipToManageStack(IShip ship)
        {
            Ship = ship;
        }
        public void CanObjectJoin()
        {
            throw new NotImplementedException();
        }
    }
}
