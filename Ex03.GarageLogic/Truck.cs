using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_IsToxic;
        private float m_MaxWeight;

        internal Truck(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_MaxEnergyCapacity,
            eEnergyType i_EnergyType, LinkedList<Wheel> i_Wheels, bool i_IsToxic, float i_MaxWeight) : base(i_ModelName,
            i_LicenseNumber, i_CurrentEnergy, i_MaxEnergyCapacity, i_EnergyType, i_Wheels, eVehicleType.FueledTruck)
        {
            try
            {
                m_IsToxic = i_IsToxic;
                m_MaxWeight = i_MaxEnergyCapacity;
            }
            catch (FormatException exception)
            {
                throw exception;
            }
        }

        public bool IsToxic
        {
            get { return m_IsToxic; }
            set { m_IsToxic = value; }
        }

        public float MaxWeight
        {
            get { return m_MaxWeight; }
            set { m_MaxWeight = value; }
        }

        public void AddFuel(eEnergyType io_EnergyType, float i_AmountToAdd)
        {
            try
            {
                AddEnergy(io_EnergyType, i_AmountToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
