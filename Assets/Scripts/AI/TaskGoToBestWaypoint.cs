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
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        return NodeState.SUCCESS;
    }
}
