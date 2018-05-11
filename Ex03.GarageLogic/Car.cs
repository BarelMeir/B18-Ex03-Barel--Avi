using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public enum eCarColor
        {
            Gray,
            Blue,
            White,
            Black
        }

        private eCarColor m_CarColor;
        private int m_DoorsAmount;

        internal Car(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_MaxEnergyCapacity, eEnergyType i_EnergyType, LinkedList<Wheel> i_Wheels,
            eVehicleType i_VehicleType, eCarColor i_CarColor, int i_DoorsAmount) : base(i_ModelName, i_LicenseNumber, i_CurrentEnergy, i_MaxEnergyCapacity, i_EnergyType, i_Wheels, i_VehicleType)
        {
            if (i_DoorsAmount < 2 || i_DoorsAmount > 5)
            {
                throw new ValueOutOfRangeException(2, 5);
            }

            try
            {
                m_CarColor = i_CarColor;
                m_DoorsAmount = i_DoorsAmount;
            }
            catch (FormatException exception)
            {
                throw exception;
            }
        }

        internal eCarColor CarColor
        {
            get { return m_CarColor; }
        }

        internal int DoorsAmount
        {
            get { return m_DoorsAmount; }
        }
    }
}
