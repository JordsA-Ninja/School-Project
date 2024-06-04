
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float m_startingHealth = 100f;

    public float m_CurrentHealth;
    private bool m_Dead;

    private void OnEnable()
    {
        m_CurrentHealth = m_startingHealth;
        m_Dead = false;

    }

    void OnDeath()
    {
        m_Dead = true;
        // m_ExplosionParticles.transform.position = transform.position;
        //  m_ExplosionParticles.gameObject.SetActive(true);
        // m_ExplosionParticles.Play();

        //AudioSource.PlayClipAtPoint(m_ExplosionAudio, transform.position);


        gameObject.SetActive(false);
    }

    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;

        if (m_CurrentHealth <= 0 && m_Dead == false)
        {
            OnDeath();
        }
    }




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
