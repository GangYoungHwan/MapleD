using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove2 : MonoBehaviour
{
    [SerializeField] private Transform[] m_Clouds = null;
    [SerializeField] private float m_speed = 0f;
    void Start()
    {
    }

    void Update()
    {
        for (int i = 0; i < m_Clouds.Length; ++i)
        {
            m_Clouds[i].position += new Vector3(-m_speed, 0, 0) * Time.deltaTime;

            if (m_Clouds[i].position.x < -4.0f)
            {
                Vector3 pos = new Vector3(8,0);
                m_Clouds[i].position = pos;
            }
        }
    }
}
