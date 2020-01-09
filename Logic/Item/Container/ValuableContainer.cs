using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ValuableContainer : BaseContainer
    {
        public ValuableContainer(int weightKG ) : base(weightKG, EnumContainerType.Valuable, new ValuableContainerRules())
        {

        }
    }
}
