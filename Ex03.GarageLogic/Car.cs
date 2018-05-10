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

        internal Car(string i_ModelName, string i_LicenseNumber, float i_EnergyLeftPrecentage, float i_MaxEnergyCapacity,
            eCarColor i_CarColor, int i_DoorsAmount) : base(i_ModelName, i_LicenseNumber, i_EnergyLeftPrecentage, i_MaxEnergyCapacity)
        {
            try
            {
                m_CarColor = i_CarColor;
                if (i_DoorsAmount < 2 || i_DoorsAmount > 5)
                {
                    throw new ValueOutOfRangeException(2, 5);
                }
                m_DoorsAmount = i_DoorsAmount;
            }
            catch (FormatException exception)
            {
                throw new FormatException(exception.Message);
            }
            catch (ArgumentException exception)
            {
                throw new ArgumentException(exception.Message);
            }
            catch (ValueOutOfRangeException)  //TODO may be should delete this block because of the "if" above.
            {
                throw new ValueOutOfRangeException(2,5);
            }
        }

        internal eCarColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        internal int DoorsAmount
        {
            get { return m_DoorsAmount; }
        }

        

    }
}
