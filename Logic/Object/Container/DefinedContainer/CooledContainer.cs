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
            SetTypeToCooled();
        }
        public CooledContainer(IContainer container) : base(container)
        {
            SetTypeToCooled();
        }
        private void SetTypeToCooled()
        {
            ContainerType = EnumContainerType.Cooled;
        }
    }
}
