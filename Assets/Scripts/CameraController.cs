using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform m_target;
    private Vector3 m_nextPosition;
    public float m_MovementDampening;
    private Vector3 m_MovementVelocity;

    private void Move()
    {
        m_nextPosition = m_target.position;
        Vector3.SmoothDamp(
            transform.position,
            m_nextPosition,
            ref m_MovementVelocity,
            m_MovementDampening
        );
        transform.position = m_nextPosition;
    }

    void FixedUpdate()
    {
        Move();
    }
}
