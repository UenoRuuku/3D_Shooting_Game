using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform _transform;
    private Animator _animator;

    public TaskGoToTarget(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        PickWaypoint();
        return NodeState.SUCCESS;
    }

    void PickWaypoint()
    {
        Transform bestWaypoint = null;
        float maxValue = 0;

        Weapon weapon = (Weapon)GetData("Weapon");
        float aggression = (float)GetData("Aggression");
        foreach (Transform waypoint in GameManager.instance.waypoints)
        {
            if (Vector3.Distance(waypoint.position, _transform.position) < (float)GetData("FovRange")){
                // 1 ~ 10
                float a = 5 / Mathf.Clamp(Mathf.Abs(weapon.bestFireDistance - Vector3.Distance(waypoint.position, GameManager.instance.player.position)), .5f, 5f);
                // 1 ~ 10
                float d = 0;
                float value = a * aggression + d * (1 - aggression);
                bestWaypoint = value > maxValue ? waypoint : bestWaypoint;
            }
        }
    }
}
