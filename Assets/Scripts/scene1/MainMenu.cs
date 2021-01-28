using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject localGameSettings;
    [SerializeField] private Text assembly;

    void Start()
    {
        assembly.text = "v " + "0.0.2.7";
    }

    public void StartLocalGameSettings()
    {
        mainMenu.SetActive(false);
        localGameSettings.SetActive(true);
    }

    public void StartGame()
    {
        // Получение данных для старта игры                             
        GameInfo.startCapital = GameInfo.GetDataOfType<Int32>("SliderStartCapital");
        GameInfo.movingTime = GameInfo.GetDataOfType<Int32>("SliderTime");
        // получаем масив имен игроков
        int i = 1;
        while(GameObject.Find("PlayerName" + i))
            {
            GameInfo.namePlayers.Enqueue(GameInfo.GetDataOfType<string>("PlayerName" + i));
                ++i;
            }
        GetPlayerColors();
        SceneManager.LoadScene("GameScene");
        EditorSceneManager.OpenScene("GameScene");
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GetPlayerColors()
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

}
