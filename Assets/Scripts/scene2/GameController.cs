using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public void ChangeScene()
    {
        SceneManager.UnloadSceneAsync("GameScene");
        SceneManager.LoadScene("MainMenu");
    }
}
