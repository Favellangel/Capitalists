using UnityEngine.SceneManagement;

public static class garbageCollector
{
    public static void FreeMemory()
    {
        Players.all.Destroy();
    }

    public static void ChangeScene()
    {
        SceneManager.UnloadSceneAsync("GameScene");
        SceneManager.LoadScene("MainMenu");
    }
}
