using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ContainerAssigner : IObjectAssigner
    {
        public StorageManager StorageManager { get; private set; }

        public ContainerAssigner(StorageManager storageManager)
        {
            StorageManager = storageManager;
        }
        public void AssignObjects(IList<IItem> listObjects)
        {
            foreach (BaseContainer containerToAssign in listObjects)
            {
                bool isAssigned = false;
                //foreach (StackGroup stackGroupToUse in StorageManager.GetStackGroupSortedOnWeightASC().ToList())
                //{
                //    //bool canBeAssigned = true;
                //    if (isAssigned)
                //    {
                //        break;
                //    }
                //    //foreach (Stack stackToUse in stackGroupToUse.ListStack.ToList())
                //    //{
                //    //foreach (Stack stackToUse in StorageManager.SortStacksByWeightASC(stackGroupToUse))
                //    //{
                //    //    List<Stack> stacksInFrontAndBehind = StorageManager.GetStacksInFrontAndBehindOfStack(stackToUse);

                //    //    ////very bad code
                //    //    //Stack dummyStack = new Stack(stackToUse.Coordinate, stackToUse.ListObject, stackToUse.HasPower); 
                //    //    //dummyStack.AddObject(containerToAssign);

                //    //    //for (int i = 0; i < stacksInFrontAndBehind.Count; i++)
                //    //    //{
                //    //    //    List<Stack> stacksInFrontAndBehind2 = StorageManager.GetStacksInFrontAndBehindOfStack(stacksInFrontAndBehind[i]);
                //    //    //    for (int x = 0; x < stacksInFrontAndBehind2.Count; x++)
                //    //    //    {
                //    //    //        if (stacksInFrontAndBehind2[x] == stackToUse)
                //    //    //        {
                //    //    //            stacksInFrontAndBehind2[x] = dummyStack;
                //    //    //        }
                //    //    //    }

                //    //    //    CanJoinParams canJoinParams2 = new CanJoinParams(stacksInFrontAndBehind[i], stacksInFrontAndBehind2);

                //    //    //    foreach (BaseContainer con in stacksInFrontAndBehind[i].ListObject)
                //    //    //    {
                //    //    //        if (!con.CanJoin.CanJoinStack(canJoinParams2))
                //    //    //        {
                //    //    //            canBeAssigned = false;
                //    //    //        }
                //    //    //    }
                //    //    //}

                //    //    CanJoinParams canJoinParams = new CanJoinParams(stackToUse, stacksInFrontAndBehind);
                //    //    if (!containerToAssign.CanJoin.CanJoinStack(canJoinParams))
                //    //    {
                //    //        continue;
                //    //        //canBeAssigned = false;
                //    //    }
                //    //    //if (canBeAssigned)
                //    //    //{
                //    //        isAssigned = stackToUse.AddObject(containerToAssign);
                //    //    //}
                //    //    //CanJoinParams canJoinParams = CanJoinParamsContainerFactory.Build(containerToAssign, stackToUse, StorageManager.GetStacksInFrontAndBehindOfStack(stackToUse));
                //    //    if (isAssigned)
                //    //    {
                //    //        break;
                //    //    }
                //    //}
                //}
            }
        }
    }
}
