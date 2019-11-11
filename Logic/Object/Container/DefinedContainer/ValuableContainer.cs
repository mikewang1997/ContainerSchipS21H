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
            SetTypeToValuable();
        }
        public ValuableContainer(IContainer container) : base(container)
        {
            SetTypeToValuable();
        }
        private void SetTypeToValuable()
        {
            ContainerType = EnumContainerType.Valuable;
        }
    }
}
