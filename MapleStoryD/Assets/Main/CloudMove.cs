using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    [SerializeField] private Transform[] m_Clouds = null;
    [SerializeField] private float m_speed = 0f;

    float m_leftPosX = 0f;
    float m_rightPosX = 0f;

    void Start()
    {
        float _length = m_Clouds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        m_leftPosX = _length;
        m_rightPosX = _length * m_Clouds.Length;
    }

    void Update()
    {
        for(int i=0; i< m_Clouds.Length; ++i)
        {
            m_Clouds[i].position += new Vector3(-m_speed, 0, 0) * Time.deltaTime;

            if(m_Clouds[i].position.x< -m_leftPosX)
            {
                Vector3 pos = m_Clouds[i].position;
                pos.Set(pos.x + m_rightPosX, pos.y, pos.z);
                m_Clouds[i].position = pos;
            }
        }
    }
}
