using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ValuableContainer : Container
    {
        public ValuableContainer(int weightKG) : base(weightKG)
        {
            ContainerType = EnumContainerType.Valuable;
        }
    }
}
