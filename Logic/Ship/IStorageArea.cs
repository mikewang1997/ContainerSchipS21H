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
        IObjectAssigner ObjectAssigner { get; }
        StorageManager StorageManager { get; }
        int GetTotalWeight();
    }
}
