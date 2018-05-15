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

        public bool ContainsLicenseNumber(string i_LicenseNumber)
        {
            return m_Clients.ContainsKey(i_LicenseNumber);
        }

        public void AddClient(string io_ClientName, string io_lientPhoneNumber, string io_ModelName,
            string io_LicenseNumber, Vehicle.eVehicleType io_VehicleType, string io_WheelsManufacture, float io_WheelsAirPressure,
            Engine.eEngineType io_EngineType, float io_EenergyLeft,
            List<object> io_UniqueParametersList)
        {
            try
            {
                List<Vehicle.Wheel> wheels = setAllWheels(io_WheelsManufacture, io_WheelsAirPressure, io_VehicleType);
                Client newClient = new Client(io_ClientName, io_lientPhoneNumber, io_ModelName, io_LicenseNumber,
                    io_VehicleType, wheels, io_EngineType, io_EenergyLeft, io_UniqueParametersList);

                m_Clients.Add(io_LicenseNumber,newClient);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static List<Vehicle.Wheel> setAllWheels(string i_WheelsManufacture, float i_WheelsAirPressure, Vehicle.eVehicleType i_VehicleType)
        {
            List<Vehicle.Wheel> wheels = new List<Vehicle.Wheel>();

            switch (i_VehicleType)
            {
                case Vehicle.eVehicleType.Car:
                    for (int i = 0; i < 4; i++)
                    {
                        wheels.Add(new Vehicle.Wheel(i_WheelsManufacture, i_WheelsAirPressure, 32));
                    }
                    break;
                case Vehicle.eVehicleType.Motorcycle:
                    for (int i = 0; i < 2; i++)
                    {
                        wheels.Add(new Vehicle.Wheel(i_WheelsManufacture, i_WheelsAirPressure, 30));
                    }
                    break;
                case Vehicle.eVehicleType.Truck:
                    for (int i = 0; i < 12; i++)
                    {
                        wheels.Add(new Vehicle.Wheel(i_WheelsManufacture, i_WheelsAirPressure, 28));
                    }
                    break;
                default:
                    throw new ArgumentException();
            }

            return wheels;
        }
    }
}
