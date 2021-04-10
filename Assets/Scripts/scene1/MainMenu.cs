using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject localGameSettings;
    [SerializeField] private Text assembly;

    List<string> nicks = new List<string>();

    void Start()
    {
        assembly.text = "v " + "0.0.3.5";
    }

    private void ExportData()
    {
        GameInfo.startCapital = GameInfo.GetDataOfType<Int32>("SliderStartCapital");
        GameInfo.movingTime = GameInfo.GetDataOfType<Int32>("SliderTime");
        // передаем масив имен игроков в стат класс
        for (int i = 0; GameObject.Find("PlayerName" + (i + 1)); i++)
            GameInfo.namePlayers.Enqueue(nicks[i]);
        GetPlayerColors();
    }

    private void GetPlayerColors()
    {
        int i = 1;
        GameObject tmp;
        Image img;
        while (GameObject.Find("Color Player" + i))
        {
            tmp = GameObject.Find("Color Player" + i);
            img = tmp.GetComponent<Image>();
            GameInfo.colors.Enqueue(img.color);
            ++i;
        }
    }

    public void StartLocalGameSettings()
    {
        mainMenu.SetActive(false);
        localGameSettings.SetActive(true);
    }

    public void StartGame()
    {
        // получаем масив имен игроков
        for (int i = 1; GameObject.Find("PlayerName" + i); i++)
            nicks.Add(GameInfo.GetDataOfType<string>("PlayerName" + i));
        // проверяем ники на коректность
        if (NickChecker.IsCorrect(nicks))
        {
            ExportData();
            SceneManager.LoadScene("GameScene");
            SceneManager.UnloadSceneAsync("MainMenu");
            return;
        }
        else
        {
            nicks.Clear();
            print(Txt.NickUncorrect); // иначе выдать сообщение "ник слишком длинный или написан не коректно"
        }        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
