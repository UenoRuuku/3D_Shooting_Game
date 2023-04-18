using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

// 判断Player是否在AlertRange内或被SphereCast到，即Player是否被发现
// 若发现Player便看向Player
public class CheckPlayer : Node
{
    private static int _playerLayerMask = 1 << 6;

    private Transform _transform;
    private Animator _animator;

    public CheckPlayer(Transform transform)
    {
        _transform = transform;
        //_animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Collider[] colliders = Physics.OverlapSphere(
            _transform.position, (float)GetData("AlertRange"), _playerLayerMask);

        Ray ray = new Ray(_transform.position, _transform.forward);

        // TODO Optimize maxDistance
        if (colliders.Length > 0 || 
            Physics.SphereCast(ray, (float)GetData("FOVRadius"), Mathf.Infinity, _playerLayerMask)) {
            _transform.LookAt(GameManager.instance.player);

            // TODO Delete Debug.Log
            Debug.Log("发现Player");

            return NodeState.SUCCESS;
        }
        else
        {
            // TODO Delete Debug.Log
            Debug.Log("尚未发现Player");

            return NodeState.FAILURE;
        }
    }

}
