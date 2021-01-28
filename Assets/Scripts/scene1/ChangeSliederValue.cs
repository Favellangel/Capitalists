using UnityEngine;
using UnityEngine.UI;

public class ChangeSliederValue : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;

    Slider slider;
    Text ValueSlider;

    void Start()
    {
        slider = this.GetComponent<Slider>();
        ValueSlider = this.GetComponentInChildren<Text>();
        slider.value = 0;
    }
    void Update()
    {
        ValueSlider.text = CountValueSlider
            (max, min).ToString();
    }

    private int CountValueSlider(int max, int min)
    {
        return (int)(min + (slider.value * (max - min)));
    }
}
