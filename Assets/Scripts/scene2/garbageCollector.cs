using UnityEngine.SceneManagement;

public static class garbageCollector
{
    public static void FreeMemory()
    {
        UI.gameManager.enabled = false;
    }

    public static void ChangeScene()
    {
        SceneManager.UnloadSceneAsync("GameScene");
        SceneManager.LoadScene("MainMenu");
    }
}
