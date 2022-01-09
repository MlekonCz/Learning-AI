using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
   //[SerializeField] private GameObject[] waypoints;
   [SerializeField] private UnityStandardAssets.Utility.WaypointCircuit _circuit;
   private int currentWaypoint = 0;

   [SerializeField]private float speed = 1f;
   [SerializeField] private float accuracy = 1f;
   [SerializeField] private float rotationSpeed = 0.5f;

   // private void Start()
   // {
   //    waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
   // }

   private void LateUpdate()
   {
      if (_circuit.Waypoints.Length == 0){return; }

      Vector3 lootAtGoal = new Vector3(_circuit.Waypoints[currentWaypoint].transform.position.x, transform.position.y,
         _circuit.Waypoints[currentWaypoint].transform.position.z);
      Vector3 direction = lootAtGoal - transform.position;
      transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime * rotationSpeed);

      if (direction.magnitude < accuracy)
      {
         currentWaypoint++;
         if (currentWaypoint >= _circuit.Waypoints.Length)
         {
            currentWaypoint = 0;
         }
      }
      transform.Translate(0,0,speed*Time.deltaTime);
   }
}
