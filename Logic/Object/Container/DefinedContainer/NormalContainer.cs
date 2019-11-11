using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class NormalContainer : Container
    {
        public NormalContainer(int weightKG) : base(weightKG)
        {
            ContainerType = EnumContainerType.Normal;
        }
    }
}
