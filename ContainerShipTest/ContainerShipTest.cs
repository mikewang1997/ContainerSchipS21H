using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;

namespace ContainerShipTest
{
    [TestClass]
    public class ContainerShipTest
    {
        [TestMethod]
        public void AssignObjects()
        {
            //Arrange
            IStorageArea containerShip = new Ship(6, 6);
            List<BaseContainer> containers = new List<BaseContainer>();
            for (int i = 0; i < 10; i++)
            {
                containers.Add(new CooledContainer(26000));
            }
            for (int i = 0; i < 10; i++)
            {
                containers.Add(new NormalContainer(26000));
            }
            for (int i = 0; i < 10; i++)
            {
                containers.Add(new CooledContainer(26000));
            }
            //Act
            containerShip.ObjectAssigner.AssignObjects(containers);
            //Assert
            
        }
    }
}
