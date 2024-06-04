using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour

{
    Rigidbody m_Rigidbody;
    float m_MovementInputValue;
    float m_TurnInputValue;
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    public Transform m_turretAsset;
    LayerMask m_LayerMask;



    // Start is called before the first frame update

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_LayerMask = LayerMask.GetMask("Ground");
    }

    void Start()
    {

    }


    void TurnTurret()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_LayerMask))
        {
            //Debug.Log(hit.point);

            m_turretAsset.LookAt(hit.point);

            m_turretAsset.eulerAngles = new Vector3(0, m_turretAsset.eulerAngles.y, m_turretAsset.eulerAngles.z);
        }

    }



    // Update is called once per frame
    void Update()
    {

        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
        TurnTurret();
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        Vector3 wantedVelocity = transform.forward * m_MovementInputValue * m_Speed;
        m_Rigidbody.AddForce(wantedVelocity - m_Rigidbody.velocity, ForceMode.VelocityChange);
    }
    void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);

    }



}
