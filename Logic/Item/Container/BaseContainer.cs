using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class BaseContainer : IItem
    {
        public EnumContainerType ContainerType { get; private set; }
        public int WeightKG { get; private set; }
        public ICanJoin CanJoin { get; private set; }
        public BaseContainer(int weightKG, EnumContainerType containerType, ICanJoin canJoin)
        {
            WeightKG = weightKG += 4000;
            ContainerType = containerType;
            CanJoin = canJoin;
        }
        public BaseContainer(int weightKG)
        {
            WeightKG = weightKG;
        }
        public int GetTonWeight()
        {
            return WeightKG / 1000;
        }
        public override string ToString()
        {
            return "Type: " + ContainerType.ToString() + " | Ton: " + GetTonWeight();
        }
    }
}
