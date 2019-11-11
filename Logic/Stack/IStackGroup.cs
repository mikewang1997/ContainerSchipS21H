using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IStackGroup
    {
        IList<IStack> ListStack { get; }
        int GetTotalWeightKG();
    }
}
