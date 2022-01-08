using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    [SerializeField] private Transform goal;
    [SerializeField] private float accuracy = 0.1f;
    [SerializeField] private float _speed = 2f;


    private void LateUpdate()
    {
        transform.LookAt(goal.position);
        Vector3 direction = goal.position - this.transform.position;
        Debug.DrawRay(transform.position,direction,Color.red);
        if (direction.magnitude > accuracy)
        {
            this.transform.Translate(direction.normalized * Time.deltaTime * _speed, Space.World);
        }
        
   
    }
}
