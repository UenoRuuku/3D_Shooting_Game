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
        if ((_transform.GetComponent<Shotgun>().currentAmmo <= 0) || (_transform.GetComponent<Character>().GetCurrentHealth() < 30))
        {
            _transform.GetComponent<Character>().ChangeToReload();
        }
        else
        {
            //_transform.GetComponent<Shotgun>().Shoot(); Vector2 需改成V3

            _transform.GetComponent<Shotgun>().currentAmmo -= 1;

            Debug.Log("射爆!,剩余子弹：" + _transform.GetComponent<Shotgun>().currentAmmo);
        }

        // TODO Delete Debug.Log
        return NodeState.SUCCESS;
    }
}
