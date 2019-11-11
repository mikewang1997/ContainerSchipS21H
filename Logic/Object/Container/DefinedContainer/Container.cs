﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class Container : IContainer
    {
        public EnumContainerType ContainerType { get; protected set; }

        public int WeightKG {get; protected set; }
        public Container(int weightKG)
        {
            WeightKG = weightKG += 4000;
        }
        public Container(IContainer container)
        {
            WeightKG = container.WeightKG;
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
