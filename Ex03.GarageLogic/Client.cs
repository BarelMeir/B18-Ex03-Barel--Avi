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

        public Client(string i_Name, string i_PhoneNumber, List<object> io_ParametersList)
        {
            // list order : 0. vehicleType ; 1. i_lisence number ; 2. modelName ; 3. energyLeft ;  4. maxEnergy ; 5. <wheels> ; 6. unique param one. ; 7. unique param two.
            try
            {
                // set local fields
                m_Name = i_Name;
                m_PhoneNumber = i_PhoneNumber;
                m_VehicleType = (Vehicle.eVehicleType)io_ParametersList[0]; 
                m_RepairStatus = Vehicle.eRepairStatus.InProgress;
                m_Vehicle = Factory.AddVehicle(io_ParametersList);
            }
            catch (FormatException e)
            {
                throw e;
            }
        }
    }
}