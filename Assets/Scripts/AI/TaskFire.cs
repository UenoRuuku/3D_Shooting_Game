using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFire : Node
{
    private Transform _transform;
    private Animator _animator;

    private Weapon CurrentW;

    public TaskFire(Transform transform)
    {
        _transform = transform;
        WeaponSwitcher w = _transform.GetComponent<WeaponSwitcher>();
        CurrentW = w.GetCurrentWeapon();
        //_animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        if ((CurrentW.currentAmmo <= 0) || (_transform.GetComponent<Character>().GetCurrentHealth() < 30))
        {
            _transform.GetComponent<Character>().ChangeToReload();
        }
        else
        {
            _transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
            //_transform.GetComponent<Shotgun>().Shoot(new Vector2(_transform.forward.x, _transform.forward.z));
            //CurrentW.currentAmmo -= 1;
            CurrentW.aiShootDir = -_transform.position + GameObject.FindGameObjectWithTag("Player").transform.position;
            CurrentW.AiShootCommand(true);
            Debug.Log("AI Shoot");// + _transform.GetComponent<Shotgun>().currentAmmo);
        }
        // TODO Delete Debug.Log1
        return NodeState.SUCCESS;
    }
}
