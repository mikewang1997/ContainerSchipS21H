using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ValuableContainerRules : ICanJoin
    {
        //Business Rule: Need to check if there is in front and behind a valuable container in current stack
        public bool CanObjectJoin(BaseContainer item)
        {
            return false;
        }

        public bool CanJoinStack(CanJoinParams canJoin)
        {
           // int amountOfJoinableSides = 0;
            bool resultCanJoin = true;

            foreach (Stack s in canJoin.StacksInFrontAndBehind)
            {
                int heightCount = s.ListObject.Count();
                int currentHeightCount = canJoin.Stack.ListObject.Count()+1;

                //if (currentHeightCount > heightCount)
                //{
                //    amountOfJoinableSides -= 1;
                //}
                //if (heightCount >= currentHeightCount)
                //{
                //    amountOfJoinableSides += 1;
                //}
                if (heightCount == currentHeightCount)
                {
                    resultCanJoin = false;
                }
            }
            //if (amountOfJoinableSides > 0 | amountOfJoinableSides == 0)
            //{
            //    resultCanJoin = true;
            //}
            return resultCanJoin;
        }
    }
}
