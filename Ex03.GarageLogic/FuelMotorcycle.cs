using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelMotorcycle : MotorCycle, IFuelable
    {
        internal FuelMotorcycle(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy,
            float i_MaxEnergyCapacity, eEnergyType i_EnergyType, LinkedList<Wheel> i_Wheels, eLicenseType i_LicenseType,
            int i_MotorVolume) : base(i_ModelName, i_LicenseNumber, i_CurrentEnergy, i_MaxEnergyCapacity, i_EnergyType,
            i_Wheels, eVehicleType.FueledMotorcycle, i_LicenseType, i_MotorVolume)
        {
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
