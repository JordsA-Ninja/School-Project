using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public float m_LaunchForce = 30f;
    private bool m_CanShoot;

    public float m_ShootDelay = 1f;
    private float m_ShootTimer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_CanShoot == true)
        {

            m_ShootTimer -= Time.deltaTime;
            if (m_ShootTimer <= 0)
            {
                m_ShootTimer = m_ShootDelay;
                Fire();

            }

        }
    }

    private void Awake()
    {
        m_CanShoot = false;
    }

    void Fire()

    {
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation);
        shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            m_CanShoot = true;
        }

    }


    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            m_CanShoot = false;
        }


    }


}
