using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ValuableStackContainer : ValuableContainer, IStackObject
    {
        //Business Rule: Need to check if there is in front and behind a valuable container in current stack
        List<IStack> StackInFrontAndBehind { get; set; }
        public ValuableStackContainer(IContainer container, List<IStack> stackInFrontAndBehind) : base(container)
        {
            StackInFrontAndBehind = stackInFrontAndBehind;
        }

        public bool CanObjectJoin()
        {
            return false;
        }

        public bool CanJoinStack()
        {
            bool resultCanJoin = false;
            foreach (IStack stack in StackInFrontAndBehind)
            {
                if (stack.ListObject.Count == 0)
                {
                    resultCanJoin = true;
                    break;
                }
                else
                {
                    foreach (IContainer container in stack.ListObject)
                    {
                        if (container.ContainerType == EnumContainerType.Valuable)
                        {
                            return resultCanJoin;
                        }
                    }
                }
            }
            return resultCanJoin;
        }
    }
}
