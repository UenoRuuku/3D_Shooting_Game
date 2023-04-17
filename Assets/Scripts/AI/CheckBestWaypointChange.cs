using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class CheckBestWaypointChange : Node
{
    private Transform _transform;
    private Animator _animator;

    public CheckBestWaypointChange(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        CheckWaypoints();
        return NodeState.SUCCESS;
    }

    bool CheckWaypoints()
    {
        Transform bestWaypoint = (Transform)GetData("BestWaypoint");
        float bestScore = (float)GetData("BestWaypointScore");

        Weapon weapon = (Weapon)GetData("Weapon");
        float aggression = (float)GetData("Aggression");
        foreach (Transform waypoint in GameManager.instance.waypoints)
        {
            if (Vector3.Distance(waypoint.position, _transform.position) < (float)GetData("FovRange"))
            {
                // 1 ~ 10
                float offensiveScore = 5 / Mathf.Clamp(Mathf.Abs(weapon.bestFireDistance - Vector3.Distance(waypoint.position, GameManager.instance.player.position)), .5f, 5f);
                // TODO Ѫ������defensiveScore��
                // 1 ~ 10
                float defensiveScore = 0;
                float score = offensiveScore * aggression + defensiveScore * (1 - aggression);
                if (score > bestScore)
                {
                    bestWaypoint = waypoint;
                    bestScore = score;
                    SetData("BestWaypoint", waypoint);
                    SetData("BestWaypointScore", score);
                    return true;
                }
            }
        }

        return false;
    }
}
