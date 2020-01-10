using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IBalancingMethod
    {
        //List<StackGroup> ListStackGroup { get; }
        bool IsInBalance(StorageManager storageManager);
        bool IsSinkable(List<StackGroup> listStackGroup);
        void PlaceItems(int TotalRows, int TotalColumns, List<Stack> listStack, List<IItem> itemsToPlace);
    }
}
