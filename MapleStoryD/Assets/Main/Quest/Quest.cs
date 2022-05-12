using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI QuestCompleteCnt;
    [SerializeField] private GameObject _Quest;
    private int cnt = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<DataManager.Instance.playerData.QuestKill.Length; i++)
        {
            int killMax = int.Parse(QuestInfoManager.Instance.QuestList[i].Kill) * DataManager.Instance.playerData.QuestLv[i];
            if (DataManager.Instance.playerData.QuestKill[i]>= killMax)
            {
                cnt+=1;
            }
        }
        QuestCompleteCnt.text = cnt.ToString();
        if(cnt>0)
            this.GetComponent<Animator>().enabled = true;
        else
            this.GetComponent<Animator>().enabled = false;
    }

    public void QuestButton()
    {
        _Quest.SetActive(true);
    }
}
