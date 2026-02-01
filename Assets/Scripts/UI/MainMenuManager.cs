using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button start;
    public Button quit;

    public Texture2D cursorTexture;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start.onClick.AddListener(StartGame);
        quit.onClick.AddListener(QuitGame);
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
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
