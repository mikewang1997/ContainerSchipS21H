using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IStorageArea
    {
        int TotalColumns { get; }
        int TotalRows { get; }
        IList<Stack> ListStack { get; }
        int GetTotalWeight();
        bool AssignObjects(List<IItem> items);
        List<Stack> GetStacksInFrontAndBehindOfStack(Stack currentStack);
    }
}
