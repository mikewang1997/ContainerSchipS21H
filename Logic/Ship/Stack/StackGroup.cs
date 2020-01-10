using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class StackGroup
    {
        private List<Stack> _ListStack;
        public IList<Stack> ListStack { get { return _ListStack; } }

        public StackGroup(IList<Stack> listStack, Coordinate startCoordinate, Coordinate endCoordinate)
        {
            _ListStack = GetListStackFromStartCoordinateAndEndCoordinate(listStack, startCoordinate,endCoordinate);
        }

        public StackGroup(List<Stack> ListStack)
        {
            _ListStack = ListStack;
        }

        private List<Stack> GetListStackFromStartCoordinateAndEndCoordinate(IList<Stack> listStack, Coordinate startCoordinate, Coordinate endCoordinate)
        {
            List<Stack> resultListStack = new List<Stack>();
            for (int x = startCoordinate.X; x <= endCoordinate.X; x++)
            {
                for (int y = startCoordinate.Y; y <= endCoordinate.Y; y++)
                {
                    foreach (Stack stackInList in listStack)
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
