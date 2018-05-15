using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsToxic;
        private float m_MaxWeight;

        internal Truck(string io_ModelName,
            string io_LicenseNumber, List<Wheel> io_Wheels,
            Engine.eEngineType io_EngineType, float io_EenergyLeft,
            List<object> io_UniqueParametersList) : base(io_ModelName, io_LicenseNumber, io_Wheels, io_EngineType, io_EenergyLeft, eVehicleType.Car)
        {
            try
            {
                m_IsToxic = (bool)io_UniqueParametersList[0];
                m_MaxWeight = (float)io_UniqueParametersList[1];

                if (m_MaxWeight <=0 )
                {
                    throw new ValueOutOfRangeException(1,int.MaxValue);
                }
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

        public void AddFuel(Engine.eEnergyType io_EnergyType, float i_AmountToAdd)
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
