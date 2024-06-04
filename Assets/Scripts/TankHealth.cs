using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public float m_startingHealth = 100f;

    private float m_CurrentHealth;
    private bool m_Dead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        m_CurrentHealth = m_startingHealth;
        m_Dead = false;
    }

    public void TakeDamage(float amonunt)
    {
        m_CurrentHealth -= amonunt;

        if(m_CurrentHealth <= 0 && m_Dead == false)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        m_Dead = true;

        gameObject.SetActive(false);
    }
}

