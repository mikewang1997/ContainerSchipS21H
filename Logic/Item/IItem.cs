using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IItem
    {
        int WeightKG { get; }
        ICanJoin CanJoin { get; }
        int GetTonWeight();

    }
}
