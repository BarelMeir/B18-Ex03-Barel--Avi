using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
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

        internal Motorcycle(string io_ModelName,
            string io_LicenseNumber, List<Wheel> io_Wheels,
            Engine.eEngineType io_EngineType, float io_EenergyLeft,
            List<object> io_UniqueParametersList) : base(io_ModelName, io_LicenseNumber, io_Wheels, io_EngineType, io_EenergyLeft, eVehicleType.Car)
        {
            try
            {
                m_LicenseType = (eLicenseType)io_UniqueParametersList[0];
                m_MotorVolume = (int)io_UniqueParametersList[1];

                if (m_MotorVolume < 1)
                {
                    throw new ValueOutOfRangeException(1, Int32.MaxValue);
                }
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
