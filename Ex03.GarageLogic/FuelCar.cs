using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelCar : Car , IFuelable
    {

        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_MaxEnergyCapacity, eEnergyType i_EnergyType, LinkedList<Wheel> i_Wheels,
            eCarColor i_CarColor, int i_DoorsAmount) : base(i_ModelName, i_LicenseNumber, i_CurrentEnergy, i_MaxEnergyCapacity, i_EnergyType, i_Wheels, eVehicleType.FueledCar, i_CarColor, i_DoorsAmount) { } 

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
