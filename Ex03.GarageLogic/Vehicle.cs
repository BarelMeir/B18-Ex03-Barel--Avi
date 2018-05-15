using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Ex03.GarageLogic
{

    public abstract class Vehicle
    {
        public enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck
        }

        public enum eRepairStatus
        {
            InProgress,
            Completed,
            Paid
        }

        public class Wheel
        {
            private string m_ManufactorName;
            private float m_CurrentAirPressure;
            private float m_MaxAirPressure;

            internal Wheel(string i_ManufactorName, float i_CurrentAirPressure, float i_MaxAirPressure)
            {
                m_ManufactorName = i_ManufactorName;
                m_CurrentAirPressure = i_CurrentAirPressure;
                m_MaxAirPressure = i_MaxAirPressure;
            }

            public string ManufactorName
            {
                get { return m_ManufactorName; }
                set { m_ManufactorName = value; }
            }

            public float CurrentAirPressure
            {
                get { return m_CurrentAirPressure; }
                set { m_CurrentAirPressure = value; }
            }

            public float MaxAirPressure
            {
                get { return m_MaxAirPressure; }
                set { m_MaxAirPressure = value; }
            }

            internal void Inflate(float i_MountToInflate)
            {
                if (m_CurrentAirPressure + i_MountToInflate > MaxAirPressure)
                {
                    throw new ValueOutOfRangeException(0, m_MaxAirPressure);
                }

                m_CurrentAirPressure += i_MountToInflate; 
            }
        }

        private string m_ModelName;
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        private eRepairStatus m_RepairStatus;
        private Engine m_Engine;

        internal Vehicle(string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels, Engine.eEngineType io_EngineType,
            float io_EnergyLeft, eVehicleType io_VehicleType)
        { 
            try
            {
                m_ModelName = i_ModelName;
                m_LicenseNumber = i_LicenseNumber;
                m_Wheels = i_Wheels;
                m_RepairStatus = eRepairStatus.InProgress;
                m_Engine = new Engine(io_EngineType, io_EnergyLeft, io_VehicleType);
            }
            catch (FormatException exception)
            {
                throw exception;
            }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float EnergyLeftPrecentage
        {
            get { return m_Engine.EnergyPercentgeLeft; }
        }

        public float CurrentEnergy
        {
            get { return m_Engine.CurrentLeftEnergy; }
            set { m_Engine.CurrentLeftEnergy = value; }
        }

        public float MaxEnergyCapacity
        {
            get { return m_Engine.MaxEnergyCapacity; }
        }

        public eRepairStatus RepairStatus
        {
            get { return m_RepairStatus; }
            set { m_RepairStatus = value; }
        }

        public void InflateAllWheels(float io_MountToInflate)
        {
            foreach (Wheel currentWheel in m_Wheels)
            {
                currentWheel.Inflate(io_MountToInflate);
            }
        }

        public void AddEnergy(Engine.eEnergyType i_EnergyType, float i_AmountToAdd)
        {
            try
            {
                m_Engine.AddEnergy(i_EnergyType, i_AmountToAdd);
            }
            catch (FormatException exception)
            {
                throw exception;
            }
            
        }

    }
}
