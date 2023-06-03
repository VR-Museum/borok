using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Scripts
{
    public class SeismicSensor : MonoBehaviour
    {
        private float timer = 0;
        private bool timerReached = false;
        private float seismic = 0;
        private string str;
        public Material[] materials;
        public GameObject sensor;
        public GameObject sesmicRedLight;
        public GameObject sesmicOrangeLight;
        public bool stay = false;
        public GameObject StayAlarm;
        public TMP_Text text;
        

        void Update()
        {
            timer += Time.deltaTime;
            if (timerReached == false && timer >= 7 && timer < 21)
            {
                seismic = Random.Range(1.0f, 2.0f);
                str = "Сейсмодатчик - " + seismic.ToString("f1");
                text.text = str;
                sensor.GetComponent<MeshRenderer>().material = materials[1];
                sesmicOrangeLight.SetActive(true);
                timerReached = true;
            } else if (timerReached == true && timer >= 21 && timer < 40)
            {
                seismic = 0;
                str = "Сейсмодатчик - " + seismic.ToString("f1");
                text.text = str;
                sensor.GetComponent<MeshRenderer>().material = materials[0];
                sesmicOrangeLight.SetActive(false);
                timerReached = false;
            } else if (timerReached == false && timer >= 40 && timer < 50)
            {
                seismic = Random.Range(2.0f, 5.0f);
                str = "Сейсмодатчик - " + seismic.ToString("f1");
                text.text = str;
                sensor.GetComponent<MeshRenderer>().material = materials[2];
                sesmicRedLight.SetActive(true);
                timerReached = true;
            } else if (timerReached == true && timer >= 50 && timer < 55)
            {
                seismic = 0;
                str = "Сейсмодатчик - " + seismic.ToString("f1");
                text.text = str;
                sensor.GetComponent<MeshRenderer>().material = materials[0];
                sesmicRedLight.SetActive(false);
                timerReached = false;
            }
            else if (timerReached == false && timer >= 55 && timer < 65) 
            {
                stay = true;
                StayAlarm.SetActive(true);
            } else if (timer >= 65)
            {
                timer = 0;
                stay = false;
                StayAlarm.SetActive(false);
            }
        }

        public float GetSeismic()
        {
            return seismic;
        }
    }
}

