using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : MotorCycle, IElectricable
    {
        internal ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy,
            float i_MaxEnergyCapacity, eEnergyType i_EnergyType, LinkedList<Wheel> i_Wheels, eLicenseType i_LicenseType,
            int i_MotorVolume) : base(i_ModelName, i_LicenseNumber, i_CurrentEnergy, i_MaxEnergyCapacity, i_EnergyType,
            i_Wheels, eVehicleType.ElectricMotorcycle, i_LicenseType, i_MotorVolume)
        {
        }

        public void Charge(float i_AmountToAdd)
        {
            try
            {
                AddEnergy(eEnergyType.Electric, i_AmountToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
