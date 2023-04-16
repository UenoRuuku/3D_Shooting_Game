using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public float m_MoveSpeed, m_RotateSpeed;
    
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float _horizontalMove = Input.GetAxis("Horizontal");
        float _verticalMove = Input.GetAxis("Vertical");

        _rigidbody.velocity = transform.forward * _verticalMove * m_MoveSpeed + transform.right * _horizontalMove * m_MoveSpeed;

        float _horizontal = Input.GetAxis("Mouse X");
        Vector3 _transformAngles = transform.eulerAngles;
        _transformAngles.y += _horizontal * m_RotateSpeed;
        transform.eulerAngles = _transformAngles;
    }
}
