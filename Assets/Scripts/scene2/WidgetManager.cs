using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidgetManager : MonoBehaviour
{
    public Transform canvas;
    public Transform w_CloseGame;

    void Start()
    {
       GameObject tmp = Instantiate(w_CloseGame, canvas).gameObject;
        tmp.SetActive(false);
    }

    public void CreateWidget(Transform widget)
    {
        Instantiate(w_CloseGame, canvas);
    }
}
