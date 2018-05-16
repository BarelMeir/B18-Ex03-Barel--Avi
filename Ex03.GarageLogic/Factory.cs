using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        internal static Vehicle MakeVehicle(string io_ModelName,
            string io_LicenseNumber, Vehicle.eVehicleType io_VehicleType, List<Wheel> io_Wheels,
            Engine.eEngineType io_EngineType, float ioEenergyLeft,
            List<object> io_UniqueParametersList)
        {
            Vehicle newVehicle;
            try
            {
                switch (io_VehicleType)
                {
                    case Vehicle.eVehicleType.Car:
                        newVehicle = makeCar(io_ModelName,
                            io_LicenseNumber, io_Wheels,
                            io_EngineType, ioEenergyLeft,
                            io_UniqueParametersList);
                        break;
                    case Vehicle.eVehicleType.Motorcycle:
                        newVehicle = makeMotorcycle(io_ModelName,
                            io_LicenseNumber, io_Wheels,
                            io_EngineType, ioEenergyLeft,
                            io_UniqueParametersList); 
                        break;
                    case Vehicle.eVehicleType.Truck:
                        newVehicle = makeTruck(io_ModelName,
                            io_LicenseNumber, io_Wheels,
                            io_EngineType, ioEenergyLeft,
                            io_UniqueParametersList);
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

        private static Car makeCar(string io_ModelName,
            string io_LicenseNumber, List<Wheel> io_Wheels,
            Engine.eEngineType io_EngineType, float ioEenergyLeft,
            List<object> io_UniqueParametersList)
        {
            try
            {
                return new Car(io_ModelName,
                    io_LicenseNumber, io_Wheels,
                    io_EngineType, ioEenergyLeft,
                    io_UniqueParametersList);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static Motorcycle makeMotorcycle(string io_ModelName,
            string io_LicenseNumber, List<Wheel> io_Wheels,
            Engine.eEngineType io_EngineType, float ioEenergyLeft,
            List<object> io_UniqueParametersList)
        {
            try
            {
                return new Motorcycle(io_ModelName,
                    io_LicenseNumber, io_Wheels,
                    io_EngineType, ioEenergyLeft,
                    io_UniqueParametersList);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static Truck makeTruck(string io_ModelName,
            string io_LicenseNumber, List<Wheel> io_Wheels,
            Engine.eEngineType io_EngineType, float ioEenergyLeft,
            List<object> io_UniqueParametersList)
        {
            try
            {
                return new Truck(io_ModelName,
                    io_LicenseNumber, io_Wheels,
                    io_EngineType, ioEenergyLeft,
                    io_UniqueParametersList);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
