using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TestResizingEffect : MonoBehaviour
{
    public TxtResizingEffect effectClass;

    private Text txt;
    private int fontSize;       
    private Color color;         
    private Font txtFont;

    void Start()
    {
        txt = GetComponent<Text>();
        fontSize = txt.fontSize;
        color = txt.color;
        txtFont = txt.font;

        effectClass.StartCoroutine(routine: effectClass.StartEffect(new Color(0, 1, 1, 1)));

        StartCoroutine(StartTests());
        
    }

    private IEnumerator StartTests()
    {
        yield return new WaitForSeconds(2f);

        Testing();
    }

    private void Testing()
    {
        // раскоментить для проверки
        //txt.fontSize = 100;     
        //txt.color = Color.red; 
        if (fontSize != txt.fontSize) 
            Debug.Log("Размер текста не вернулся в исходное состояние");
        if (txt.fontSize >= 72)
            Debug.Log("Размер текста превысил размер контейнера");
        if (color != txt.color)
            Debug.Log("Цвет текста не вернулся в исходное состояние");
        if (txtFont != txt.font)
            Debug.Log("Шрифт исказился");
    }
}






















// коурутин можно запускать сколько угодно
//заплатка
//effectClass.StopCoroutine(effectClass.StartEffect(new Color()));

// изменение текста можно было вынести наружу. Тогда и параметр пропадает, и лишний код.