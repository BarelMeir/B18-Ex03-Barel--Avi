using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class MotorCycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            B1,
            B2
        }

        private eLicenseType m_LicenseType;
        private int m_MotorVolume;

        internal MotorCycle(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_MaxEnergyCapacity, eEnergyType i_EnergyType, LinkedList<Wheel> i_Wheels,
            eVehicleType i_VehicleType, eLicenseType i_LicenseType, int i_MotorVolume) : base(i_ModelName, i_LicenseNumber, i_CurrentEnergy, i_MaxEnergyCapacity, i_EnergyType, i_Wheels)
        {
            if (i_MotorVolume < 1)
            {
                throw new ValueOutOfRangeException(1, Int32.MaxValue);
            }

            try
            {
                m_LicenseType = i_LicenseType;
                m_MotorVolume = i_MotorVolume;
            }
            catch (FormatException exception)
            {
                throw exception;
            }
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int MotorVolume
        {
            get { return m_MotorVolume; }
        }
    }
}
