using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuy : MonoBehaviour
{
    public GameObject BuyUI;
    public GameObject Acquired;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TargetBuy()
    {
        ActiveF();
        BuyUI.SetActive(true);
    }
    public void TargetAcquired()
    {
        ActiveF();
        //�޼� or ���̾� Ÿ��Ȯ�� ->�����ݾ׺��� ������Ȯ��->DataManager�� �޼�or���̾� ���� ��ųexp �߰� ,�÷��̾���Ϳ� �ƹ�Ÿ,������ �߰�
        //Acquired.SetActive(true);
    }

    public void TargetSuccess()
    {
        ActiveF();
    }

    public void TargetClose()
    {
        ActiveF();
    }

    private void ActiveF()
    {
        BuyUI.SetActive(false);
        Acquired.SetActive(false);
    }
}
