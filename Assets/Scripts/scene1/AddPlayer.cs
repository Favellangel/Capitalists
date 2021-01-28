using UnityEngine;

public class AddPlayer : MonoBehaviour
{
    GameObject btnAddPlayer3;
    GameObject containerPlayer3;

    void Start()
    {
        btnAddPlayer3 = GameObject.Find("BtnAddPlayer3");
        containerPlayer3 = GameObject.Find("Container Player3");
        containerPlayer3.SetActive(false);
    }

    public void BtnAddPlayer3()
    {
        btnAddPlayer3.SetActive(false);
        containerPlayer3.SetActive(true);
    }
}
