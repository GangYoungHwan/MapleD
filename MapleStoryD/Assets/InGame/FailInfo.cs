using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FailInfo : MonoBehaviour
{
    [SerializeField] private Text StageText = null;
    private int Stage = 0;
    void Start()
    {
        Stage = DataManager.Instance.SpotNumber;
        StageText.text = Stage.ToString();
        Time.timeScale = 0;
    }

    public void OKbutton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
}
