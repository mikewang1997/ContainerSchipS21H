using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ShipManager : IManager
    {
        public List<IShip> ListShip { get; private set; }
        public List<IStackManager> ListStackManager { get; private set; }

        public ShipManager(List<IShip> listShip)
        {
            ListShip = listShip;
            foreach (IShip ship in ListShip)
            {
                ListStackManager = new List<IStackManager>() { new StackManager(this, ship )};
            };
        }
        public ShipManager()
        {
            ListShip = new List<IShip>();
            ListStackManager = new List<IStackManager>();
        }
        public void AddNewShip(IShip ship)
        {
            ListShip.Add(ship);
            IStackManager newStackManager = new StackManager(this, ship);
            ListStackManager.Add(newStackManager);
        }

        public void AssignObjects(List<IObject> ListObject, IShip ship)
        {
            if (ListShip.Contains(ship))
            {
                foreach (IStackManager stackManager in ListStackManager)
                {
                    if (stackManager.Ship.Equals(ship))
                    {
                        stackManager.AssignObjects(ListObject);
                        break;
                    }
                }
            }
        }

        public string GetStringVisualizer(IShip ship)
        {
            string http = "https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=" + ship.TotalRows + "&width=" + ship.TotalColumns + "&stacks=";
            for (int X = 1; X <= ship.TotalColumns; X++)
            {
                for (int Y = 1; Y <= ship.TotalRows; Y++)
                {
                    foreach (Stack stack in ship.ListStack.ToList())
                    {
                        if (stack.Coordinate.X == X && stack.Coordinate.Y == Y)
                        {
                            foreach (IContainer container in stack.ListObject)
                            {
                                http += (int)container.ContainerType;
                            }
                        }
                    }
                    if (Y != ship.TotalRows)
                    {
                        http += ",";
                    }
                }
                if (X != ship.TotalColumns)
                {
                    http += "/";
                }
            }

            http += "&weights=";

            for (int X = 1; X <= ship.TotalColumns; X++)
            {
                for (int Y = 1; Y <= ship.TotalRows; Y++)
                {
                    foreach (Stack stack in ship.ListStack.ToList())
                    {
                        if (stack.Coordinate.X == X && stack.Coordinate.Y == Y)
                        {
                            for (int numContainer = 0; numContainer < stack.ListObject.Count; numContainer++)
                            {
                                http += stack.ListObject[numContainer].GetTonWeight();
                                if (numContainer != stack.ListObject.Count)
                                {
                                    http += "-";
                                }
                            }
                        }
                    }
                    if (Y != ship.TotalRows)
                    {
                        http += ",";
                    }
                }
                if (X != ship.TotalColumns)
                {
                    http += "/";
                }
            }

            return http;
        }
    }
}
