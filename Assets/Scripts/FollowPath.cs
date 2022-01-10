using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour
{
  
    [SerializeField] private GameObject _waypointManager;
    private GameObject[] _waypoints;
    private NavMeshAgent _navMeshAgent;
    private void Start()
    {
        _waypoints = _waypointManager.GetComponent<WaypointManager>().waypoints;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,100,100), "GoToHeli"))
        {
            Debug.Log("heli");
            GoToHeli();
        }
        if (GUI.Button(new Rect(0,100,100,100), "GoToRuins"))
        {
           GoToRuin();
        }
    }

    public void GoToHeli()
    {
        _navMeshAgent.SetDestination(_waypoints[0].transform.position);
    }

    public void GoToRuin()
    {
        _navMeshAgent.SetDestination(_waypoints[15].transform.position);
    }

    private void LateUpdate()
    {
      
        
    }
    
    
    
    
    
    
    
}
