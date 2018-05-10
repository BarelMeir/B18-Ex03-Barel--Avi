using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Ex03.GarageLogic
{

    public enum eRepairStatus
    {
        InProgress,
        Completed,
        Paid
    }

    public class Viechale
    {
        private class Wheel
        {
            private string m_ManufactorName;
            private float m_CurrentAirPressure;
            private float m_MaxAirPressure;

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
                if (m_CurrentAirPressure + i_MountToInflate <= m_MaxAirPressure)
                {
                    m_CurrentAirPressure += i_MountToInflate;
                }
                else
                {
                    // TODO exeption
                }
            }
        }

        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyLeftPrecentage;
        private LinkedList<Wheel> m_Wheels;
        private eRepairStatus m_RepairStatus;

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
