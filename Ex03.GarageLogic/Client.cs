using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Client
    {
        private string m_Name;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;
        private Vehicle.eVehicleType m_VehicleType;

        public Client(string i_ClientName, string i_ClientPhoneNumber, string io_ModelName,
            string io_LicenseNumber, Vehicle.eVehicleType io_VehicleType, List<Vehicle.Wheel> io_Wheels,
            Engine.eEngineType io_EngineType, float ioEenergyLeft,
            List<object> io_UniqueParametersList)
        {
            try
            {
                // set local fields
                m_Name = i_ClientName;
                m_PhoneNumber = i_ClientPhoneNumber;
                m_VehicleType = io_VehicleType;
                m_Vehicle = Factory.MakeVehicle(io_ModelName,
                    io_LicenseNumber, io_VehicleType, io_Wheels,
                    io_EngineType, ioEenergyLeft,
                    io_UniqueParametersList);
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public string OwnerName
        {
            get { return m_Name; }
        }

        public override string ToString()
        {
            return string.Format(@"Client Name: {0}
Client Phone Number: {1}", 
                m_Name,
                m_PhoneNumber);
        }
    }
}