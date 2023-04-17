using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class EnemyBT : BehaviorTree.Tree
{
    public Weapon weapon;

    public float fovRange = 10f;

    public float speed = 2f;

    [Range(0, 1)]
    public float aggression = .5f;

    protected override void SetupTree()
    {
        Node root = new Selector(//new List<Node>
        //{   
            //new Sequence(new List<Node>
            //{
                //new CheckPlayerInFOVRange(transform),
                //new TaskGoToTarget(transform),
            //})
        //}
        );

        root.SetData("Weapon", weapon);
        root.SetData("FovRange", fovRange);
        root.SetData("Waypoints", GameManager.instance.waypoints);
        root.SetData("Speed", speed);
        root.SetData("Aggression", aggression);

        _root = root;
    }
}
