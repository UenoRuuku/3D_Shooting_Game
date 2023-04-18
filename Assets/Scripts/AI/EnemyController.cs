using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class EnemyController : BehaviorTree.Tree
{
    public Weapon weapon;

    public float alertRange = 10f;
    public float fovRadius = 10f;

    public float waypointRange = 20f;
    public float speed = 1f;

    [Range(0, 1)]
    public float aggression = .5f;

    public Transform[] patrolWaypoints;

    protected override void SetupTree()
    {
        Node root = new Node();

        root.SetData("Weapon", weapon);
        root.SetData("AlertRange", alertRange);
        root.SetData("FOVRadius", fovRadius);
        root.SetData("Waypoints", GameManager.instance.waypoints);
        root.SetData("WaypointRange", waypointRange);
        root.SetData("Speed", speed);
        root.SetData("Aggression", aggression);

        _root = root;
    }
}
