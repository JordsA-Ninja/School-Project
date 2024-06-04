
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour

{
    // Start is called before the first frame update

    public float m_MaxLifeTime = 2f;
    public ParticleSystem m_ExplosionParticles;
    public float m_MaxDamage = 34f;
    void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision Other)
    {


        m_ExplosionParticles.transform.parent = null;
        m_ExplosionParticles.Play();
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        Destroy(gameObject);

    }


}
