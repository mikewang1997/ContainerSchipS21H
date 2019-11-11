using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ContainerShip : IShip
    {
        public int TotalColumns { get; private set; }

        public int TotalRows { get; private set; }

        private List<IStack> _ListStack;
        public IList<IStack> ListStack {  get{return _ListStack;} }

        public ContainerShip(int totalColumns, int totalRows)
        {
            TotalColumns = totalColumns;
            TotalRows = totalRows;
            InitializeListStacks();
        }
        private void InitializeListStacks()
        {
            _ListStack = new List<IStack>();
            for (int x = 1; x <= TotalColumns; x++)
            {
                for (int y = 1; y <= TotalRows; y++)
                {
                    _ListStack.Add(new Stack(new Coordinate(x, y)));
                }
            }
        }
    }
}
