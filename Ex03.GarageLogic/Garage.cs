using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<String, Client> m_Clients = new Dictionary<string, Client>();

        public Dictionary<String, Client> Clients
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
                List<Wheel> wheels = setAllWheels(io_WheelsManufacture, io_WheelsAirPressure, io_VehicleType);
                Client newClient = new Client(io_ClientName, io_lientPhoneNumber, io_ModelName, io_LicenseNumber,
                    io_VehicleType, wheels, io_EngineType, io_EenergyLeft, io_UniqueParametersList);

                m_Clients.Add(io_LicenseNumber,newClient);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static List<Wheel> setAllWheels(string i_WheelsManufacture, float i_WheelsAirPressure, Vehicle.eVehicleType i_VehicleType)
        {
            List<Wheel> wheels = new List<Wheel>();

            switch (i_VehicleType)
            {
                case Vehicle.eVehicleType.Car:
                    for (int i = 0; i < 4; i++)
                    {
                        wheels.Add(new Wheel(i_WheelsManufacture, i_WheelsAirPressure, 32));
                    }
                    break;
                case Vehicle.eVehicleType.Motorcycle:
                    for (int i = 0; i < 2; i++)
                    {
                        wheels.Add(new Wheel(i_WheelsManufacture, i_WheelsAirPressure, 30));
                    }
                    break;
                case Vehicle.eVehicleType.Truck:
                    for (int i = 0; i < 12; i++)
                    {
                        wheels.Add(new Wheel(i_WheelsManufacture, i_WheelsAirPressure, 28));
                    }
                    break;
                default:
                    throw new ArgumentException();
            }

            return wheels;
        }
        
        public void updateExistingClient(string i_LisenceNumber, Vehicle.eRepairStatus io_NewRepairStatus)
        {
            Client client = m_Clients[i_LisenceNumber];

            client.Vehicle.RepairStatus = io_NewRepairStatus;
        }

        public List<string> GetAllLicenseNumbers()
        {
            List<string> allLicenseNumbers = new List<string>();

            foreach (string licenseNumber in m_Clients.Keys)
            {
                allLicenseNumbers.Add(licenseNumber);
            }

            return allLicenseNumbers;
        }

        public List<string> GetLicenseNumbersInStatus(Vehicle.eRepairStatus i_RepairStatus)
        {
            List<string> licenseNumbersInRequiredStatus = new List<string>();

            foreach (KeyValuePair<string, Client> licenseClientPair in m_Clients)
            {
                if (licenseClientPair.Value.Vehicle.RepairStatus == i_RepairStatus)
                {
                    licenseNumbersInRequiredStatus.Add(licenseClientPair.Key);
                }
            }

            return licenseNumbersInRequiredStatus;
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            try
            {
                m_Clients[i_LicenseNumber].Vehicle.InflateAllWheelsToMax();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void FuelVehicle(string i_LicenseNumber, Engine.eEnergyType io_FuelType, float io_AddAmount)
        {
            try
            {
                m_Clients[i_LicenseNumber].Vehicle.AddEnergy(io_FuelType, io_AddAmount);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, float io_AddAmount)
        {
            try
            {
                m_Clients[i_LicenseNumber].Vehicle.AddEnergy(Engine.eEnergyType.Electricity, io_AddAmount);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string PrintVehicle(string i_LicenseNumber)
        {
            return string.Format(@"{0}
{1}",
                m_Clients[i_LicenseNumber],
                    m_Clients[i_LicenseNumber].Vehicle);
        }
    }
}
