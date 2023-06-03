using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class TemperatureSensor : MonoBehaviour
    {
        private float timer = 0;
        private bool timerReached = false;
        private int temperature = 0;
        public Material[] materials;
        public GameObject sensor;

        void Update()
        {
            timer += Time.deltaTime;
            //Debug.Log("timer: " + timer);
            if (timerReached == false && timer >= 10 && timer < 20)
            {
                sensor.GetComponent<MeshRenderer>().material = materials[1];
                temperature = 1;
                timerReached = true;
            }
            else if (timerReached == true && timer >= 20 && timer < 40)
            {
                sensor.GetComponent<MeshRenderer>().material = materials[0];
                temperature = 0;
                timerReached = false;
            }
            else if (timerReached == false && timer >= 40 && timer < 45)
            {
                sensor.GetComponent<MeshRenderer>().material = materials[1];
                temperature = 1;
                timerReached = true;
            }
            else if (timerReached == true && timer >= 45 && timer < 60)
            {
                sensor.GetComponent<MeshRenderer>().material = materials[0];
                temperature = 0;
                timerReached = false;
            }
            else if (timer >= 60)
            {
                timer = 0;
            }
        }

        public int GetTemperature()
        {
            return temperature;
        }
    }
}