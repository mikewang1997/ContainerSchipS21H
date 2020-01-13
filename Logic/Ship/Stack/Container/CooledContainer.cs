using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CooledContainer : BaseContainer
    {
        public CooledContainer(int weightKG) : base(weightKG, EnumContainerType.Cooled, new CooledContainerRules())
        {

        }
    }
}
