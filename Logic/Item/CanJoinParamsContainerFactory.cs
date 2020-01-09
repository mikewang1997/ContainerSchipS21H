using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    //niet in gebruik
    public static class CanJoinParamsContainerFactory
    {
        public static CanJoinParams Build(BaseContainer container, Stack stack, List<Stack> stackInFrontAndBehind)
        {
            CanJoinParams canJoinParamsResult = null;
            if (container.ContainerType == EnumContainerType.Valuable)
            {
                canJoinParamsResult = new CanJoinParams(stack, stackInFrontAndBehind);
            }
            else
            {
                canJoinParamsResult = new CanJoinParams(stack);
            }
            return canJoinParamsResult;
        }
    }
}
