using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{
    public void SceneChange()
    {
        PlayerData save = new PlayerData();
        if (DataManager.Instance.slotData._Slot == 0)
            return;

        if (DataManager.Instance.SlotNumber == 1)
            save = DataManager.Instance.playerData_1;
        else if (DataManager.Instance.SlotNumber == 2)
            save = DataManager.Instance.playerData_2;
        else if (DataManager.Instance.SlotNumber == 3)
            save = DataManager.Instance.playerData_3;
        else if (DataManager.Instance.SlotNumber == 4)
            save = DataManager.Instance.playerData_4;
        else
            return;
        DataManager.Instance.playerData = save;
        SoundManager.Instance.PlaySFXSound("GameStart");
        SceneManager.LoadScene("MainScene");
    }
}
