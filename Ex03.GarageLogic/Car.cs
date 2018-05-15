using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
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

        internal Car(string io_ModelName,
            string io_LicenseNumber, List<Wheel> io_Wheels,
            Engine.eEngineType io_EngineType, float io_EenergyLeft,
            List<object> io_UniqueParametersList) : base(io_ModelName, io_LicenseNumber, io_Wheels, io_EngineType, io_EenergyLeft, eVehicleType.Car)
        {
            try
            {
                m_CarColor = (eCarColor)io_UniqueParametersList[0];
                m_DoorsAmount = int.Parse((string)io_UniqueParametersList[1]); 

                if (m_DoorsAmount < 2 || m_DoorsAmount > 5)
                {
                    throw new ValueOutOfRangeException(2, 5);
                }
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

        public override string ToString()
        {
            Console.WriteLine(base.ToString());

            return string.Format(
                @"Car Color: {0}
Doors Amount: {1}",
                m_CarColor,
                m_DoorsAmount);
        }
    }
}

