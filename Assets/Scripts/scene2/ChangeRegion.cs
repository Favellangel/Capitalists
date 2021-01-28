using UnityEngine;

public class ChangeRegion : MonoBehaviour
{
    ChangePositionSelected changePositionSelected;
    GameObject[] regions = new GameObject[4];
    int shownRegion;

    void Start()
    {
        for (int i = 0; GameObject.Find("Container" + (i + 1) + "Region"); i++)
            regions[i] = GameObject.Find("Container" + (i + 1) + "Region");
        shownRegion = 0;
        changePositionSelected = GameObject.Find("Selected").GetComponent<ChangePositionSelected>();
    }

    public void On_Click(int numRegion)
    {
        shownRegion = numRegion - 1; // масив начинается с 0, а номера регионов с 1
        SetLayerParent();
        SetLayerChilds();
        changePositionSelected.ChangePosition(shownRegion);
    }

    private void SetLayerParent()
    {
        for (int i = 0; i < regions.Length; i++)
        {
            if (i == shownRegion)
                regions[i].layer = 8;
            else
                regions[i].layer = 30;
        }
    }    

    private void SetLayerChilds()
    {
        for (int i = 0; i < regions.Length; i++)
        {
            if (i == shownRegion)
                SetLayers(i, 8);
            else
                SetLayers(i, 30);
        }
    }

    private void SetLayers(int index, int layer)
    {
        foreach (Transform child in regions[index].transform)
        {
            child.gameObject.layer = layer;
            child.GetChild(0).gameObject.layer = layer;
        }
    }
}
