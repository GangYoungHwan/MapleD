using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundScrolling : MonoBehaviour
{
    [SerializeField] GameObject[] m_BackGrounds = null;
    [SerializeField] Transform[] Target = null;
    [SerializeField] float m_speed = 0f;
    [SerializeField] private int TargetNum = 0;
    [SerializeField] private float TargetLength = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(-Target[TargetNum].localPosition.x, 0, 0);
        for(int i = 0; i<m_BackGrounds.Length; ++i)
        {
            Vector3 BackGrounds = new Vector3(m_BackGrounds[i].transform.localPosition.x, 0, 0);
            m_BackGrounds[i].transform.localPosition = Vector3.MoveTowards(BackGrounds, target, Time.deltaTime * m_speed);
            //if(m_BackGrounds[i].transform.localPosition.x > -Target[TargetNum].localPosition.x)
            //m_BackGrounds[i].transform.Translate(new Vector3(-m_speed, 0,0));
        }
    }

    public void TargetNum0()
    {
        TargetNum = 0;
    }
    public void TargetNum1()
    {
        TargetNum = 1;
    }
    public void TargetNum2()
    {
        TargetNum = 2;
    }
    public void TargetNum3()
    {
        TargetNum = 3;
    }
}
