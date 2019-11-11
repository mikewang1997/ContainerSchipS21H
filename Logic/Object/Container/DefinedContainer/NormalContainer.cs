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
            SetTypeToNormal();
        }
        public NormalContainer(IContainer container) : base(container)
        {
            SetTypeToNormal();
        }
        private void SetTypeToNormal()
        {
            ContainerType = EnumContainerType.Normal;
        }
    }
}
