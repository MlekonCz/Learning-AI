using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction{OneDirection, BothDirections}
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WaypointManager : MonoBehaviour
{
    [SerializeField] public GameObject[] waypoints;
    [SerializeField] private Link[] links;
    public Graph graph = new Graph();

    private void Start()
    {
        if (waypoints.Length > 0)
        {
            foreach (GameObject wp in waypoints)
            {
                graph.AddNode(wp);
            }

            foreach (Link l in links)
            {
                graph.AddEdge(l.node1, l.node2);
                if (l.dir == Link.direction.BothDirections)
                {
                    graph.AddEdge(l.node2,l.node1);
                }
                
            }
        }
    }

    private void Update()
    {
        graph.debugDraw();
    }
}
