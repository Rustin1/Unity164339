using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvl : MonoBehaviour
{
    private static bool win = false;
    public static bool getWin()
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

    // Metoda do ³adowania sceny po jej indeksie
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
