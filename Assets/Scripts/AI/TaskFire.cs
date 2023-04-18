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
            //_transform.GetComponent<Shotgun>().Shoot(new Vector2(_transform.forward.x, _transform.forward.z));
            _transform.GetComponent<Shotgun>().currentAmmo -= 1;

            Debug.Log("Éä±¬!,Ê£Óà×Óµ¯£º" + _transform.GetComponent<Shotgun>().currentAmmo);
        }
        // TODO Delete Debug.Log
        return NodeState.SUCCESS;
    }
}
