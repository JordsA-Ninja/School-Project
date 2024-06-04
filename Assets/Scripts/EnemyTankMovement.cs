﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{
    public Transform m_Turret;
    private bool m_Follow;
    public float m_CloseDistance = 8f;
    private NavMeshAgent m_NavAgent;
    private Transform m_Target;
    // Start is called before the first frame update
    void Awake()
    {
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Follow == false)
        {
            return;
        }
        MoveTowards();
        TurretLook();
    }
    void MoveTowards()
    {
        float distance = (m_Target.position - transform.position).magnitude;
        if(distance > m_CloseDistance)
        {
            m_NavAgent.SetDestination(m_Target.position);
            m_NavAgent.isStopped = false;
        }
        else
        {
            m_NavAgent.isStopped = true;
        }
    }

    private void OnTrigggerEntre(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = true;
        }
    }
    private void onTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = false;
        }
    }

    void TurretLook()
    {
        if (m_Turret != null)
        {
            m_Turret.LookAt(m_Target);
        }
    }
}
