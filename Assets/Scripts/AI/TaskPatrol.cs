using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using UnityEngine.AI;

public class TaskPatrol : Node
{
    private Transform _transform;
    private Animator _animator;
    private Transform[] _patrolWaypoints;

    private int _currentWaypointIndex = 0;

    private float _waitTime = 1f; // in seconds
    private float _waitCounter = 0f;
    private bool _waiting = false;

   
    public TaskPatrol(Transform transform, Transform[] patrolWaypoints)
    {
        _transform = transform;
        //_animator = transform.GetComponent<Animator>();
        _patrolWaypoints = patrolWaypoints;
    }

    public override NodeState Evaluate()
    {
        NavMeshAgent agent = _transform.GetComponent<NavMeshAgent>();

        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waiting = false;
                //_animator.SetBool("Walking", true);
            }
        }
        else
        {
            Transform wp = _patrolWaypoints[_currentWaypointIndex];
            if (Vector3.Distance(_transform.position, wp.position) < 1f)
            {
                Vector3 currentRotation = _transform.rotation.eulerAngles;
                currentRotation.x = 0f;
                _transform.rotation = Quaternion.Euler(currentRotation);

                _transform.LookAt(GameManager.instance.player);
                _transform.position = wp.position;
                _waitCounter = 0f;
                _waiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _patrolWaypoints.Length;
                //_animator.SetBool("Walking", false);
            }
            else
            {
                agent.SetDestination(wp.position);
                //_transform.position = Vector3.MoveTowards(_transform.position, wp.position, (float)GetData("Speed") * Time.deltaTime);
                _transform.LookAt(wp.position);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
