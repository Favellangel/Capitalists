﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TxtAppearanceEffect : MonoBehaviour
{
    Text txt;
    [SerializeField] float transition;
    float textTransparence;
    bool invisibility;
    Color32 tmp;
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        textTransparence = txt.color.a * 0;
        invisibility = false;
        tmp = txt.color;
    }

    private void Update()
    {
        if (gameObject.activeSelf)
            StartCoroutine(routine: StartEffect());
        StopCoroutine(routine: StartEffect());
    }

    public IEnumerator StartEffect()
    {
        while (!invisibility)
        {
            if (!invisibility)
            {
                textTransparence += Time.deltaTime * (255.0f / transition * 2);
                if (textTransparence >= 255.0f)
                    invisibility = true;
            }
            txt.color = new Color32(tmp.a, tmp.g, tmp.b, (byte)textTransparence);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        while (invisibility)
        {
            if (invisibility)
            {
                textTransparence -= Time.deltaTime * (255.0f / transition * 2);
                if (textTransparence <= 0.0f)
                    invisibility = false;
            }
            txt.color = new Color32(tmp.a, tmp.g, tmp.b, (byte)textTransparence);
            yield return new WaitForSeconds(0.04f);
        }
        gameObject.SetActive(false);
    }
}