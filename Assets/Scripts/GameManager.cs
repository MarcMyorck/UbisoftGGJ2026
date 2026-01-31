using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameObject playerObject;

    public bool isGameOver = false;
    public float gameOverTimer = 0f;
    public float gameOverDelay = 5.0f;
    public GameObject gameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = Object.FindFirstObjectByType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGameOver)
        {
            gameOverTimer += Time.deltaTime;
            if (gameOverTimer >= gameOverDelay)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.GetComponent<TMP_Text>().enabled = true;
        GameObject.Find("Player/Sprite").GetComponent<SpriteRenderer>().enabled = false;
    }
}
