using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CooledContainer : Container
    {
        public CooledContainer(int weightKG) : base(weightKG)
        {
            ContainerType = EnumContainerType.Cooled;
        }
    }
}
