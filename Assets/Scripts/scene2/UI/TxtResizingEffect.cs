using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TxtResizingEffect : MonoBehaviour
{
    Text text;
    int defFontSize;
    Color defColor;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
        defFontSize = text.fontSize;
        defColor = text.color;
    }

    public IEnumerator StartEffect(Color color)
    {
        text.color = color;
        while (text.fontSize <= (defFontSize + 10))
        {
            text.fontSize += 2;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.2f);
        while(text.fontSize >= defFontSize)
        {
            text.fontSize -= 2;
            yield return new WaitForSeconds(0.02f);
        }
        text.color = defColor;
    }

}
