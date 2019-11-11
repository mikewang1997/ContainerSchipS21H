using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IShip
    {
        int TotalColumns { get; }
        int TotalRows { get; }
        IList<IStack> ListStack { get; }
    }
}
