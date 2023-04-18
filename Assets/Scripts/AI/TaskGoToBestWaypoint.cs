using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using UnityEngine.AI;

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
        NavMeshAgent agent = _transform.GetComponent<NavMeshAgent>();
        Transform bestWaypoint = (Transform)GetData("BestWaypoint");

        if (Vector3.Distance(_transform.position, bestWaypoint.position) > 1f)
        {
            //_transform.position = Vector3.MoveTowards(_transform.position, bestWaypoint.position, (float)GetData("Speed") * Time.deltaTime);
            agent.SetDestination(bestWaypoint.position);
            _transform.LookAt(bestWaypoint.position);

            // TODO Delete Debug.Log
            Debug.Log(Vector3.Distance(_transform.position, bestWaypoint.position));
            Debug.Log("AI尚未到达最佳位置" + bestWaypoint.gameObject.name + ": " + GetData("BestScore"));
        }
        else
        {
            Vector3 currentRotation = _transform.rotation.eulerAngles;
            currentRotation.x = 0f;
            _transform.rotation = Quaternion.Euler(currentRotation);

            _transform.LookAt(GameManager.instance.player);
            return NodeState.FAILURE;
        }
        return NodeState.RUNNING;
    }
}
