using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IBalancer
    {
        List<IStackGroup> ListStackGroup { get; }
        bool IsInBalance();
        IStackGroup GetStackGroupLowestWeight();
    }
}
