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
        foreach (WaypointGroup waypointGroup in GameManager.instance.waypointGroups)
        {
            if (Vector3.Distance(waypointGroup.cover.position, _transform.position) < (float)GetData("WaypointRange"))
            {
                waypointGroup.Regrade();
                foreach (Waypoint waypoint in waypointGroup.waypoints)
                {
                    float offensiveScore = 10 / Mathf.Abs(weapon.bestFireDistance - Vector3.Distance(waypoint.transform.position, GameManager.instance.player.position));
                    // TODO 血量低则defensiveScore高，且需要Clamp吗？
                    float defensiveScore = 0;
                    float score = waypoint.score + offensiveScore * aggression + defensiveScore * (1 - aggression);

                    // TODO Delete Debug.Log
                    //Debug.Log(waypoint.transform.gameObject.name + ": " + score);

                    if (score > bestScore)
                    {
                        bestScore = score;
                        parent.parent.SetData("BestWaypoint", waypoint.transform);
                        parent.parent.SetData("BestScore", score);
                    }
                }
            }
        }
    }
}
