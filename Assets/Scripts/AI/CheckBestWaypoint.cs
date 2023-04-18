using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

// �������λ�ò����AI�Ƿ���δ���ﵱǰ���λ��
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
        return Check() ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    bool Check()
    {
        Transform bestWaypoint = (Transform)GetData("BestWaypoint");
        float bestScore = (float)GetData("BestScore");

        Weapon weapon = (Weapon)GetData("Weapon");
        float aggression = (float)GetData("Aggression");
        foreach (Transform waypoint in GameManager.instance.waypoints)
        {
            if (Vector3.Distance(waypoint.position, _transform.position) < (float)GetData("WaypointRange"))
            {
                float offensiveScore = 5 / Mathf.Clamp(Mathf.Abs(weapon.bestFireDistance - Vector3.Distance(waypoint.position, GameManager.instance.player.position)), .5f, 5f);
                // TODO Ѫ������defensiveScore�ߣ����clamp��1-10
                float defensiveScore = 0;
                float score = offensiveScore * aggression + defensiveScore * (1 - aggression);
                if (score > bestScore)
                {
                    bestWaypoint = waypoint;
                    bestScore = score;
                    parent.parent.SetData("BestWaypoint", waypoint);
                    parent.parent.SetData("BestScore", score);
                }
            }
        }

        return Vector3.Distance(bestWaypoint.position, _transform.position) > .001f;
    }
}
