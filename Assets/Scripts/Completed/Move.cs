using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   [SerializeField] Vector3 goal = new Vector3(4,0,2);
   [SerializeField] private float _speed = 2f;

   private void LateUpdate()
   {
   this.transform.Translate(goal.normalized * Time.deltaTime * _speed);
   
   }
}
