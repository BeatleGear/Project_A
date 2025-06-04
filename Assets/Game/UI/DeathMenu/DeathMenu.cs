using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;

    public void RestartGame()
    {
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    public void Pause()
    {
        deathMenuUI.SetActive(true);
        //Time.timeScale = 0f;
    }

}
