using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction{OneDirection, MultipleDirections}
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WaypointManager : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private Link[] links;
    public Graph graph = new Graph();

    private void Start()
    {
        
    }
}
