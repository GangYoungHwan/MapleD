using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesoDia : MonoBehaviour
{
    public void Meso()
    {
        DataManager.Instance.playerData.Meso += 100;
    }

    public void Dia()
    {
        DataManager.Instance.playerData.Dia += 100;
    }
}
