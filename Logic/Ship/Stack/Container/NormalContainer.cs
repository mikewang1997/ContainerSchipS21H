using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class NormalContainer : BaseContainer
    {
        public NormalContainer(int weightKG ) : base(weightKG, EnumContainerType.Normal, new DefaultContainerRules())
        {

        }
    }
}
