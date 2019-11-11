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
            if (objectToFactory is IContainer)
            {
                IContainer container = (IContainer)objectToFactory;
                if (container.ContainerType == EnumContainerType.Normal)
                {
                    stackObject = new NormalStackContainer(objectToFactory.WeightKG);
                }
                if (container.ContainerType == EnumContainerType.Cooled)
                {
                    stackObject = new CooledStackContainer(objectToFactory.WeightKG, yAxisToAssign);
                }
                if (container.ContainerType == EnumContainerType.Valuable)
                {
                    stackObject = new ValuableStackContainer(objectToFactory.WeightKG, stacksInFrontAndBehindOfCurrentStack);
                }
            }
            return stackObject;
        }
    }
}
