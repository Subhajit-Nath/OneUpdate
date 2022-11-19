using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] private Vector3 m_targetPoint;

    private Vector3 m_initialPoint;
    private float m_targetDistance;
    private bool m_pong;
    private float m_speed = 5f;
    private Transform m_transform;

    private void Awake()
    {
        m_transform = transform;
    }

    private void Start()
    {
        m_targetDistance = Vector3.Distance(m_initialPoint, m_targetPoint);
    }

    public void SetInitialPoint()
    {
        m_initialPoint = m_transform.position;
        m_targetPoint += m_initialPoint;
    }

    public void Move()
    {
        float currentDistance = Vector3.Distance(m_initialPoint, m_transform.position);
        if (m_pong)
        {
            if (currentDistance >= m_targetDistance)
            {
                m_pong = false;
                m_speed = Random.Range(3f, 5f);
                return;
            }
            m_transform.position = Vector3.MoveTowards(m_transform.position, m_targetPoint, Time.deltaTime * m_speed);
        }
        else
        {
            if(currentDistance <= 0.01f)
            {
                m_pong = true;
                m_speed = Random.Range(3f, 5f);
                return;
            }
            m_transform.position = Vector3.MoveTowards(m_transform.position, m_initialPoint, Time.deltaTime * m_speed);
        }
    }
}
