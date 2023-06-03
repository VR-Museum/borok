using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Graph : MonoBehaviour
{
    public float scale;
    public GameObject[] XDivision;
    public GameObject dumpTruck;

    private float timer = 0;
    //private float timerBefore = 0;
    private Vector3[] Points;
    private float speed;
    private LineRenderer lineRenderer;
    private int positionCount = 1;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = positionCount;
        lineRenderer.SetPosition(positionCount - 1, transform.position + new Vector3(0, dumpTruck.GetComponent<UnityEngine.AI.NavMeshAgent>().speed * scale, 0));
    }

    void Update()
    {
        timer += Time.deltaTime;
        //timer += Time.fixedDeltaTime;
        //if (timer - timerBefore >= 1f)
        if (Convert.ToInt32(timer) >= positionCount)
        {
            if (timer >= 120)
            {
                timer = 0;
                //timerBefore = timer;
                positionCount = 1;
                lineRenderer.positionCount = positionCount;
                lineRenderer.SetPosition(positionCount - 1, transform.position + new Vector3(timer * 0.385f, dumpTruck.GetComponent<UnityEngine.AI.NavMeshAgent>().speed * scale, timer * 0.385f));
                for(int i = 0; i < XDivision.Length; i++)
                {
                    string text = XDivision[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
                    int res = Convert.ToInt32(text) + 120;
                    XDivision[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = res.ToString();
                }
            }
            else
            {
                positionCount++;
                lineRenderer.positionCount = positionCount;
                lineRenderer.SetPosition(positionCount - 1, transform.position + new Vector3(timer * 0.385f, dumpTruck.GetComponent<UnityEngine.AI.NavMeshAgent>().speed * scale, timer * 0.385f));
                //timerBefore = timer;
            }
        }
    }
}
