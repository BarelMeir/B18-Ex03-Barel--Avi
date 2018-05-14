using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<String, Ex03.GarageLogic.Client> m_Clients = new Dictionary<string, Client>();

        public Dictionary<String, Ex03.GarageLogic.Client> Clients
        {
            get { return m_Clients; }
        }
    }
}
