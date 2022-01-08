using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
   [SerializeField] private GameObject[] waypoints;
   private int currentWaypoint = 0;

   [SerializeField]private float speed = 1f;
   [SerializeField] private float accuracy = 1f;
   [SerializeField] private float rotationSpeed = 0.5f;

   private void Start()
   {
      waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
   }

   private void LateUpdate()
   {
      if (waypoints.Length == 0){return; }

      Vector3 lootAtGoal = new Vector3(waypoints[currentWaypoint].transform.position.x, transform.position.y,
         waypoints[currentWaypoint].transform.position.z);
      Vector3 direction = lootAtGoal - transform.position;
      transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime * rotationSpeed);

      if (direction.magnitude < accuracy)
      {
         currentWaypoint++;
         if (currentWaypoint >= waypoints.Length)
         {
            currentWaypoint = 0;
         }
      }
      transform.Translate(0,0,speed*Time.deltaTime);
   }
}
