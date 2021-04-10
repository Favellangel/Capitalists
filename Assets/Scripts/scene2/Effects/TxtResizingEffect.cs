using System.Collections;
using UnityEngine;
using UnityEngine.UI;

    /// <summary>
    /// Эффект изменения размера и цвета текста
    /// </summary>
public class TxtResizingEffect : MonoBehaviour
{
    Text text;              // текст, над которым выполняется эффект
    int defFontSize;        // стандартный размер 
    Color defColor;         // стандартный цвет текста

    /// <summary>
    /// Инициализация класса
    /// </summary>
    void Start()
    {                
        text = gameObject.GetComponent<Text>();     // находим компонент текста
        if (text == null)
        {
            Debug.Log("Текст не найден");
            Destroy(this);
            return;
        }

        defFontSize = text.fontSize;                // получаем размер текста 
        defColor = text.color;                      // получаем цвет текста
    }

    /// <summary>
    /// запускаем корутин эффекта
    /// </summary>
    public IEnumerator StartEffect(Color color)
    {
        text.color = color;                         // сначала задаем тот цвет, который передаётся  параметром
        while (text.fontSize < (defFontSize + 10)) // пока шрифт, меньше чем первоначальный шрифт + 10
        {            
            text.fontSize += 2;                     // увеличиваем шрифт на 2
            ChangeErrorMsg();
            yield return new WaitForSeconds(0.01f); // задержка
        }

        yield return new WaitForSeconds(0.2f);      // задержка

        while (text.fontSize > defFontSize)         // пока шрифт не вернется в значение по умолчанию
        {
            ChangeErrorMsg();
            text.fontSize -= 2;
            yield return new WaitForSeconds(0.02f); // задержка
        }
        text.color = defColor;                      // в конце, возвращаем цвет, который был по умолчанию
    }

    private void ChangeErrorMsg()
    {
        if (defFontSize == text.fontSize)
            Debug.Log("Изменения размера текста не происходит");
    }
}
