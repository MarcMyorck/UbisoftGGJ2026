using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button start;
    public Button quit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start.onClick.AddListener(StartGame);
        quit.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
