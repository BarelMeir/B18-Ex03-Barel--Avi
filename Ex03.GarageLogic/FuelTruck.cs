using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelTruck : Vehicle
    {
        private bool m_IsToxic;
        private float m_MaxWeight;

        internal FuelTruck(string i_ModelName, string i_LicenseNumber, float i_EnergyLeftPrecentage, float i_MaxEnergyCapacity, bool i_IsToxic, float i_MaxWeight) : base(i_ModelName, i_LicenseNumber, i_EnergyLeftPrecentage, i_MaxEnergyCapacity)
        {
            m_IsToxic = i_IsToxic;
            m_MaxWeight = i_MaxEnergyCapacity;
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

    }
}
