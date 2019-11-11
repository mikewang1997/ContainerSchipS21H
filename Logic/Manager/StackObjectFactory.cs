using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class StackObjectFactory
    {
        public static IStackObject Build(IObject objectToFactory, List<IStack> stacksInFrontAndBehindOfCurrentStack, int yAxisToAssign)
        {
            IStackObject stackObject = null;
            //if (objectToFactory is IContainer)
            //{
            //    IContainer container = (IContainer)objectToFactory;
            //    if (container is NormalContainer)
            //    {
            //        stackObject = new NormalStackContainer(container);
            //    }
            //    if (container.ContainerType == EnumContainerType.Cooled)
            //    {
            //        stackObject = new CooledStackContainer(container, yAxisToAssign);
            //    }
            //    if (container.ContainerType == EnumContainerType.Valuable)
            //    {
            //        stackObject = new ValuableStackContainer(container, stacksInFrontAndBehindOfCurrentStack);
            //    }
            //}
            IContainer objectToIContainer = (IContainer)objectToFactory;
            if (objectToFactory is NormalContainer)
            {
                stackObject = new NormalStackContainer(objectToIContainer);
            }
            if (objectToFactory is CooledContainer)
            {
                stackObject = new CooledStackContainer(objectToIContainer, yAxisToAssign);
            }
            if (objectToFactory is ValuableContainer)
            {
                stackObject = new ValuableStackContainer(objectToIContainer, stacksInFrontAndBehindOfCurrentStack);
            }
            return stackObject;
        }
    }
}
