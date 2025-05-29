using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletePanel : MonoBehaviour
{
    public GameObject CompletePanelUI;
    public void EndOfGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void completeLevelSetActive()
    {
        CompletePanelUI.SetActive(true);
    }
}
