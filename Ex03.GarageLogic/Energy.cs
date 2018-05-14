using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Energy
    {
        private enum eEnergyType
        {
            Electricity,
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }

        private float m_CurrentEnergy;
        private float m_MaxEnergyCapacity;
        private float m_EnergyPercentgeLeft;

        public float MaxEnergyCapacity
        {
            get { return m_MaxEnergyCapacity; }
        }

        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
        }

        public float EnergyPercentgeLeft
        {
            get { return m_EnergyPercentgeLeft; }
        }


        public void AddEnergy(eEnergyType i_EnergyType, float i_AmountToAdd)
        {
            if (Ex03.GarageLogic.Vehicle.EnergyType != i_EnergyType)
            {
                throw new ArgumentException();
            }

            if (m_CurrentEnergy + i_AmountToAdd > m_MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergyCapacity);
            }

            try
            {
                m_CurrentEnergy += i_AmountToAdd;
                m_EnergyPercentgeLeft = (m_CurrentEnergy * 100) / m_MaxEnergyCapacity;
            }
            catch (FormatException exception)
            {
                throw exception;
            }

        }

    }
}
