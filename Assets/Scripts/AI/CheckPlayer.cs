using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

// �ж�Player�Ƿ���AlertRange�ڻ�SphereCast������Player�Ƿ񱻷���
// ������Player�㿴��Player
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
            Debug.Log("����Player");

            return NodeState.SUCCESS;
        }
        else
        {
            // TODO Delete Debug.Log
            Debug.Log("��δ����Player");

            return NodeState.FAILURE;
        }
    }

}
