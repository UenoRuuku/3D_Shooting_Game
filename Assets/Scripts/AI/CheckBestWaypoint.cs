using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using UnityEngine.SocialPlatforms.Impl;

// 更新最佳位置
public class CheckBestWaypoint : Node
{
    private Transform _transform;
    private Animator _animator;

    public CheckBestWaypoint(Transform transform)
    {
        _transform = transform;
        //_animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Check();
        return NodeState.SUCCESS;
    }

    void Check()
    {
        float bestScore = 0;

        Weapon weapon = (Weapon)GetData("Weapon");
        float aggression = (float)GetData("Aggression");
        foreach (Transform waypoint in GameManager.instance.waypoints)
        {
            if (Vector3.Distance(waypoint.position, _transform.position) < (float)GetData("WaypointRange"))
            {
                float offensiveScore = 10 / Mathf.Abs(weapon.bestFireDistance - Vector3.Distance(waypoint.position, GameManager.instance.player.position));
                // TODO 血量低则defensiveScore高，且需要Clamp吗？
                float defensiveScore = 0;
                float score = offensiveScore * aggression + defensiveScore * (1 - aggression);

                // TODO Delete Debug.Log
                //Debug.Log(waypoint.gameObject.name + ": " + score);

                if (score > bestScore)
                {
                    bestScore = score;
                    parent.parent.SetData("BestWaypoint", waypoint);
                    parent.parent.SetData("BestScore", score);
                }
            }
        }
    }
}
