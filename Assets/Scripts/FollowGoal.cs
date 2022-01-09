using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGoal : MonoBehaviour
{
  [SerializeField] private Transform goal;
  [SerializeField] private float speed = 2f;
  [SerializeField] private float accuracy = 1f;
  [SerializeField] private float rotationSpeed = 0.3f;

  private void LateUpdate()
  {
    Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);

    Vector3 direction = lookAtGoal - transform.position;
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),Time.deltaTime * rotationSpeed);
   
     transform.Translate(0,0,speed * Time.deltaTime);
     
  }
}
