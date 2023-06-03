using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Scripts
{
    public class ReactionOnSensors : MonoBehaviour
    {
        public GameObject[] dumpTrucks;
        public TemperatureSensor temperatureSensor;
        public SeismicSensor seismicSensor;

        void Update()
        {
            if (seismicSensor.GetSeismic() != 0)
            {
                for (int i = 0; i < dumpTrucks.Length; i++)
                {
                    dumpTrucks[i].GetComponent<WalkingTarget>().seismicDanger = true;
                    if (temperatureSensor.GetTemperature() != 0)
                    {
                        dumpTrucks[i].GetComponent<NavMeshAgent>().speed = 1f;
                    }
                    if (seismicSensor.GetSeismic() > 2)
                    {
                        dumpTrucks[i].GetComponent<NavMeshAgent>().speed = 0f;
                    }
                }
            } else if (seismicSensor.stay == true)
            {
                for (int i = 0; i < dumpTrucks.Length; i++)
                {
                    dumpTrucks[i].GetComponent<NavMeshAgent>().speed = 0f;
                }
            } else if (temperatureSensor.GetTemperature() != 0)
            {
                for (int i = 0; i < dumpTrucks.Length; i++)
                {
                    dumpTrucks[i].GetComponent<NavMeshAgent>().speed = 1f;
                }
            } else
            {
                for (int i = 0; i < dumpTrucks.Length; i++)
                {
                    dumpTrucks[i].GetComponent<NavMeshAgent>().speed = 2;
                    dumpTrucks[i].GetComponent<WalkingTarget>().seismicDanger = false;
                }
            }
        }
    }
}

