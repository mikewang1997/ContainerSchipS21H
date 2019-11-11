using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ValuableStackContainer : ValuableContainer, IStackContainer
    {
        //Business Rule: Need to check if there is in front and behind a valuable container in current stack
        List<IStack> StackInFrontAndBehind { get; set; }
        public ValuableStackContainer(int weight, List<IStack> stackInFrontAndBehind) : base(weight)
        {
            StackInFrontAndBehind = stackInFrontAndBehind;
        }

        public bool CanObjectJoin()
        {
            return false;
        }

        public bool CanJoinStack()
        {
            foreach (IStack stack in StackInFrontAndBehind)
            {
                foreach (IContainer container in stack.ListObject)
                {
                    if (container.ContainerType == EnumContainerType.Valuable)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
