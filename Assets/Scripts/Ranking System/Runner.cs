using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner
{
    public string name { get; set; }
    public int activeWaypointIndex { get; set; }
    public float distanceToWaypoint { get; set; }

    public override string ToString()
    {
        return activeWaypointIndex + "__" + name;
    }

}
