using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject Clear = null;
    [SerializeField] private GameObject Fail = null;
    public void GameClear()
    {
        Clear.SetActive(true);
    }

    public void GameFail()
    {
        Fail.SetActive(true);
    }
}
