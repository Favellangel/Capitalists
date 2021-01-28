using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPanel : MonoBehaviour
{
    GameObject tmp;
    GameManager gameManager;
    void Start()
    {
        tmp = GameObject.Find("GameObjects");
        gameManager = tmp.GetComponent<GameManager>();
    }

    public void Click_On_BtnExit()
    {
        SceneManager.UnloadSceneAsync("GameScene");
        SceneManager.LoadScene("MainMenu");
        gameManager.players.Destroy();
    }
}
