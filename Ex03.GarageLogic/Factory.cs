using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        internal static Vehicle MakeVehicle(List<object> io_ParametersList)
        {
            // list order : 0. vehicleType ; 1. i_lisence number ; 2. modelName ; 3. energyLeft ;  4. maxEnergy ; 5. <wheels> ; 6. unique param one. ; 7. unique param two.
            Vehicle newVehicle;
            try
            {
                Vehicle.eVehicleType vehicleType = (Vehicle.eVehicleType) io_ParametersList[0];

                switch (vehicleType)
                {
                    case Vehicle.eVehicleType.ElectricCar:
                        newVehicle = makeElectricCar(io_ParametersList);
                        break;
                    case Vehicle.eVehicleType.ElectricMotorcycle:
                        newVehicle = makeElectricMotorcycle(io_ParametersList);
                        break;
                    case Vehicle.eVehicleType.FueledCar:
                        newVehicle = makeFueledCar(io_ParametersList);
                        break;
                    case Vehicle.eVehicleType.FueledMotorcycle:
                        newVehicle = makeFueledMotorcycle(io_ParametersList);
                        break;
                    case Vehicle.eVehicleType.FueledTruck:
                        newVehicle = makeFueledTruck(io_ParametersList);
                        break;
                    default:
                        throw new ArgumentException();
                }

                return newVehicle;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static ElectricCar makeElectricCar(List<object> io_ParametersList)
        {
            // list order : 0. vehicleType ; 1. i_lisence number ; 2. modelName ; 3. energyLeft ;  4. maxEnergy ; 5. <wheels> ; 6. unique param one. ; 7. unique param two.
            try
            {
                string modelName = (string) io_ParametersList[1];
                string lisenceNumber = (string)io_ParametersList[2];
                float currentEnergy = (float)io_ParametersList[3];
                float maxEnergy = (float)io_ParametersList[4];
                LinkedList<Vehicle.Wheel> wheels = (LinkedList<Vehicle.Wheel>) io_ParametersList[5];
                Car.eCarColor carColor = (Car.eCarColor) io_ParametersList[6];
                int doorsAmount = (int) io_ParametersList[7];

                return new ElectricCar(modelName, lisenceNumber, currentEnergy, maxEnergy, Vehicle.eEnergyType.Electric, wheels, carColor, doorsAmount);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static ElectricMotorcycle makeElectricMotorcycle(List<object> io_ParametersList)
        {
            // list order : 0. vehicleType ; 1. i_lisence number ; 2. modelName ; 3. energyLeft ;  4. maxEnergy ; 5. <wheels> ; 6. unique param one. ; 7. unique param two.
            try
            {
                string modelName = (string)io_ParametersList[1];
                string lisenceNumber = (string)io_ParametersList[2];
                float currentEnergy = (float)io_ParametersList[3];
                float maxEnergy = (float)io_ParametersList[4];
                LinkedList<Vehicle.Wheel> wheels = (LinkedList<Vehicle.Wheel>)io_ParametersList[5];
                MotorCycle.eLicenseType licenseType = (MotorCycle.eLicenseType)io_ParametersList[6];
                int motorVolume = (int)io_ParametersList[7];

                return new ElectricMotorcycle(modelName, lisenceNumber, currentEnergy, maxEnergy, Vehicle.eEnergyType.Electric, wheels, licenseType, motorVolume);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static FuelCar makeFueledCar(List<object> io_ParametersList)
        {
            // list order : 0. vehicleType ; 1. i_lisence number ; 2. modelName ; 3. energyLeft ;  4. maxEnergy ; 5. <wheels> ; 6. unique param one. ; 7. unique param two.
            try
            {
                string modelName = (string)io_ParametersList[1];
                string lisenceNumber = (string)io_ParametersList[2];
                float currentEnergy = (float)io_ParametersList[3];
                float maxEnergy = (float)io_ParametersList[4];
                LinkedList<Vehicle.Wheel> wheels = (LinkedList<Vehicle.Wheel>)io_ParametersList[5];
                Car.eCarColor carColor = (Car.eCarColor)io_ParametersList[6];
                int doorsAmount = (int)io_ParametersList[7];

                return new FuelCar(modelName, lisenceNumber, currentEnergy, maxEnergy, Vehicle.eEnergyType.Octan98, wheels, carColor, doorsAmount);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static FuelMotorcycle makeFueledMotorcycle(List<object> io_ParametersList)
        {
            // list order : 0. vehicleType ; 1. i_lisence number ; 2. modelName ; 3. energyLeft ;  4. maxEnergy ; 5. <wheels> ; 6. unique param one. ; 7. unique param two.
            try
            {
                string modelName = (string)io_ParametersList[1];
                string lisenceNumber = (string)io_ParametersList[2];
                float currentEnergy = (float)io_ParametersList[3];
                float maxEnergy = (float)io_ParametersList[4];
                LinkedList<Vehicle.Wheel> wheels = (LinkedList<Vehicle.Wheel>)io_ParametersList[5];
                MotorCycle.eLicenseType licenseType = (MotorCycle.eLicenseType)io_ParametersList[6];
                int motorVolume = (int)io_ParametersList[7];

                return new FuelMotorcycle(modelName, lisenceNumber, currentEnergy, maxEnergy, Vehicle.eEnergyType.Octan96, wheels, licenseType, motorVolume);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static FuelTruck makeFueledTruck(List<object> io_ParametersList)
        {
            // list order : 0. vehicleType ; 1. i_lisence number ; 2. modelName ; 3. energyLeft ;  4. maxEnergy ; 5. <wheels> ; 6. unique param one. ; 7. unique param two.
            try
            {
                string modelName = (string)io_ParametersList[1];
                string lisenceNumber = (string)io_ParametersList[2];
                float currentEnergy = (float)io_ParametersList[3];
                float maxEnergy = (float)io_ParametersList[4];
                LinkedList<Vehicle.Wheel> wheels = (LinkedList<Vehicle.Wheel>)io_ParametersList[5];
                bool isToxic = (bool)io_ParametersList[6];
                float maxWehight = (float)io_ParametersList[7];

                return new FuelTruck(modelName, lisenceNumber, currentEnergy, maxEnergy, Vehicle.eEnergyType.Electric, wheels, isToxic, maxWehight);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
