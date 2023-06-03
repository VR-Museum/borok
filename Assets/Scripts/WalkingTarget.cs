using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts
{
    public class WalkingTarget : MonoBehaviour {
        private Transform curDestination;
        private int curDestinationInd;
        private NavMeshAgent navMesh;
        private RaycastHit hitInfo;
        private bool reverse = false;
        public Transform[] waypoints;
        //private Transform[] safeWaypoints;
        public bool seismicDanger = false;
        private Ray ray;


        private void Start()
        {
            //safeWaypoints = new Transform[waypoints.Length - 5];
            navMesh = GetComponent<NavMeshAgent>();
            curDestinationInd = 0;
            ray = new Ray(waypoints[curDestinationInd].position, new Vector3(0, -1, 0));
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Vector3 targetPosition = hitInfo.point;
                navMesh.SetDestination(targetPosition);
            }
            /*for (int i = 0; i < safeWaypoints.Length; i++)
            {
                safeWaypoints[i] = waypoints[i];
            }
            safeWaypoints[0] = waypoints[32];
            safeWaypoints[1] = waypoints[33];
            safeWaypoints[2] = waypoints[34];
            safeWaypoints[3] = waypoints[35];
            safeWaypoints[4] = waypoints[36];*/

        }

        private void Update()
        {
            if (seismicDanger == true)
            {
                waypoints[0] = waypoints[32];
                waypoints[1] = waypoints[33];
                waypoints[2] = waypoints[34];
                waypoints[3] = waypoints[35];
                waypoints[4] = waypoints[36];
            }
            float dist = navMesh.remainingDistance;
            if (dist != Mathf.Infinity && navMesh.pathStatus == NavMeshPathStatus.PathComplete && !navMesh.pathPending && navMesh.remainingDistance < 0.01f)
            {
                if (!reverse)
                {
                    if(curDestinationInd != waypoints.Length-6)
                    {
                        curDestinationInd += 1;
                    } else
                    {
                        curDestinationInd -= 1;
                        reverse = true;
                    }

                } else
                {
                    if (curDestinationInd != 0)
                    {
                        curDestinationInd -= 1;
                    }
                    else
                    {
                        curDestinationInd += 1;
                        reverse = false;
                    }

                }
                Debug.Log("Waypoint: " + waypoints[curDestinationInd]);
                ray = new Ray(waypoints[curDestinationInd].position, new Vector3(0, -1, 0));
                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                {
                    //Debug.Log("waypoints[curDestinationInd].position: " + waypoints[curDestinationInd].position);
                    //Debug.Log("targetPosition: " + hitInfo.point);
                    Vector3 targetPosition = hitInfo.point;
                    navMesh.SetDestination(targetPosition);
                }
            }
        }

        private void SetRandomNavMeshAgentDestination()
        {
            int waypointIndex = Random.Range(0, waypoints.Length);
            curDestination = waypoints[waypointIndex];
            navMesh.SetDestination(curDestination.position);
            //Debug.Log("Waypoint: " + waypoints[waypointIndex]);
        }
    }
}

