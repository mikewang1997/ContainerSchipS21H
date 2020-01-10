using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ContainerShip : IStorageArea
    {
        public int TotalColumns { get; private set; }
        public int TotalRows { get; private set; }
        public IBalancer Balancer { get; private set; }
        private List<Stack> _ListStack;
        public IList<Stack> ListStack {  get{return _ListStack;} }

        public ContainerShip(int totalColumns, int totalRows, IBalancer balancer)
        {
            TotalColumns = totalColumns;
            TotalRows = totalRows;
            InitializeListStacks();
            Balancer = balancer;
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
    }
}
