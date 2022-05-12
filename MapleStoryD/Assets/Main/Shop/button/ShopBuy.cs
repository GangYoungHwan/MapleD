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
        //메소 or 다이아 타입확인 ->소지금액보다 작은지확인->DataManager에 메소or다이아 차감 스킬exp 추가 ,플레이어데이터에 아바타,아이템 추가
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
