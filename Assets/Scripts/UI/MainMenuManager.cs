using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button start;
    public Button credits;
    public Button quit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start.onClick.AddListener(StartGame);
        credits.onClick.AddListener(OpenCredits);
        quit.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    void OpenCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
