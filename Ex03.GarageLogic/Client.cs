using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Client
    {
        private string m_Name;
        private string m_PhoneNumber;
        private Vehicle.eRepairStatus m_RepairStatus;
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
                m_RepairStatus = Vehicle.eRepairStatus.InProgress;
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
    }
}