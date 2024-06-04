using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    //
    //Variables and Awake function are here
    //
    public float m_MaxLifeTime = 2f;
    public ParticleSystem m_ExplosionParticles;
    public float m_MaxDamage = 34f;
    /*
    private float m_MovementInputValue = 0f;
    private float m_TurnInputValue = 0f;
    private float m_CurrentHealth = m_startingHealth;
    private bool m_Dead = false;
    */

    private void OnEnable()
    {
        // m_Rigidbody.isKinematic = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage(Collision target)
    {
        TankHealth targetHealth = target.transform.GetComponent<TankHealth>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(m_MaxDamage);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Damage(other);
        //Once code is done, we destory the object
        //Explosions
        m_ExplosionParticles.transform.parent = null;
    }
}
