using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class StackGroup : IStackGroup
    {
        private List<IStack> _ListStack;
        public IList<IStack> ListStack { get { return _ListStack; } }
        //public EnumStackSide Side { get; private set; }
        //public int BeginX { get; set; }

        //public int EndX { get; set; }

        //public int BeginY { get; set; }

        //public int EndY { get; set; }

        public StackGroup(IList<IStack> listStack, ICoordinate startCoordinate, ICoordinate endCoordinate)
        {
            //Side = side;
            //BeginX = beginX;
            //EndX = endX;
            //BeginY = beginY;
            //EndY = endY;
            _ListStack = GetListStackFromStartCoordinateAndEndCoordinate(listStack, startCoordinate,endCoordinate);
        }

        public StackGroup(List<IStack> ListStack)
        {
            _ListStack = ListStack;
        }

        private List<IStack> GetListStackFromStartCoordinateAndEndCoordinate(IList<IStack> listStack, ICoordinate startCoordinate, ICoordinate endCoordinate)
        {
            List<IStack> resultListStack = new List<IStack>();
            for (int x = startCoordinate.X; x <= endCoordinate.X; x++)
            {
                for (int y = startCoordinate.Y; y <= endCoordinate.Y; y++)
                {
                    foreach (IStack stackInList in listStack)
                    {
                        if (stackInList.Coordinate.X == x )
                        {
                            if (stackInList.Coordinate.Y == y)
                            {
                                resultListStack.Add(stackInList);
                                break;
                            }
                        }
                    }
                }
            }
            return resultListStack;
        }

        public int GetTotalWeightKG()
        {
            int totalWeightKG = 0;
            foreach (Stack stack in ListStack)
            {
                totalWeightKG += stack.GetWeightKG();
            }
            return totalWeightKG;
        }
    }
}
