using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLvl : MonoBehaviour
{
    private static bool win = false;

    public static bool GetWin()
    {
        return win;
    }

    // Metoda do ³adowania sceny o nazwie
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadWinSceneByName(string sceneName)
    {
        win = true;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLoseSceneByName(string sceneName)
    {
        win = false;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
