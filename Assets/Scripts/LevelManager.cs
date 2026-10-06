using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Play");
    }

    public void GameOver()
    {
        StartCoroutine(WaitDie("Game Over", 2));
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitDie(string sceneName, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}
