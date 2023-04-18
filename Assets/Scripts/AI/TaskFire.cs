using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFire : Node
{
    private Transform _transform;
    private Animator _animator;

    public TaskFire(Transform transform)
    {
        _transform = transform;
        //_animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        // TODO Delete Debug.Log
        Debug.Log("…‰±¨");
        return NodeState.SUCCESS;
    }
}
