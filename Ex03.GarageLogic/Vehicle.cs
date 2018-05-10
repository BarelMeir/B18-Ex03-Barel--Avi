using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Ex03.GarageLogic
{

    public abstract class Vehicle
    {
        public enum eEnergyType
        {
            Octan96,
            Octan98,
            Electric
        }

        public enum eRepairStatus
        {
            InProgress,
            Completed,
            Paid
        }

        private class Wheel
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
                try 
                {
                    m_CurrentAirPressure += i_MountToInflate;
                }
                catch(ValueOutOfRangeException)
                {
                    throw new ValueOutOfRangeException();
                }
            }
        }

        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyLeftPrecentage;
        private float m_MaxEnergyCapacity;
        private LinkedList<Wheel> m_Wheels;
        private eRepairStatus m_RepairStatus;
        private eEnergyType m_EnergyType;

        internal Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeftPrecentage, float i_MaxEnergyCapacity)
        {
            try
            {
                m_ModelName = i_ModelName;
                m_LicenseNumber = i_LicenseNumber;
                m_EnergyLeftPrecentage = i_EnergyLeftPrecentage;
                m_MaxEnergyCapacity = i_MaxEnergyCapacity;
                // TODO ADD WHEELS LIST 
            }
            catch (FormatException exception)
            {
                throw new FormatException(exception.Message);
            }
            catch (ArgumentException exception)
            {
                throw new ArgumentException(exception.Message);
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
            get { return m_EnergyLeftPrecentage; }
            set { m_EnergyLeftPrecentage = value; }
        }

        public float MaxEnergyCapacity
        {
            get { return m_MaxEnergyCapacity; }
            set { m_MaxEnergyCapacity = value; }
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

    }
}
