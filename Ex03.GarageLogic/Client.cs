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
        private Vehicle m_ClientVehicle;
        private Vehicle.eVehicleType m_ClientVehicleType;

        public Client(string i_Name, string i_PhoneNumber)
        {
            try
            {
                m_Name = i_Name;
                m_PhoneNumber = i_PhoneNumber;
                m_RepairStatus = Vehicle.eRepairStatus.InProgress;
            }
            catch (FormatException e)
            {
                throw e;
            }
        }
    }
}