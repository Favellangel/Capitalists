using UnityEngine;
using UnityEngine.UI;

public class TxtColorChangeEffect : MonoBehaviour
{
    Color color;
    Color defColor;

    void Start()
    {
        color = gameObject.GetComponent<Text>().color;
        defColor = color;
    }

    public void ChangeColor(Color color)
    {
        this.color = color;
    }

    public void SetByDefault()
    {
        this.color = defColor;
    }
}
