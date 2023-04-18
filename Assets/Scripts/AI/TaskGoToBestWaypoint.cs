using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskGoToBestWaypoint : Node
{
    private Transform _transform;
    private Animator _animator;

    public TaskGoToBestWaypoint(Transform transform)
    {
        _transform = transform;
        //_animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform bestWaypoint = (Transform)GetData("BestWaypoint");

        if (Vector3.Distance(_transform.position, bestWaypoint.position) > 0.01f)
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position, bestWaypoint.position, (float)GetData("Speed") * Time.deltaTime);
            _transform.LookAt(bestWaypoint.position);

            // TODO Delete Debug.Log
            Debug.Log("AI尚未到达最佳位置" + bestWaypoint.gameObject.name + ": " + GetData("BestScore"));
        }
        else
        {
            return NodeState.FAILURE;
        }
        return NodeState.RUNNING;
    }
}
