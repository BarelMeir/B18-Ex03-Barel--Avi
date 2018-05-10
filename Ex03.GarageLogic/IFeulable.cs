using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    interface IFeulable
    {
        void AddFuel(eEnergyType i_EnergyType, float i_AmountToAdd);
    }
}
