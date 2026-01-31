using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject playerObject;

    public GameObject enemyPrefab;

    public bool isGameOver = false;
    public float gameOverTimer = 0f;
    public float gameOverDelay = 5.0f;
    public GameObject gameOverText;

    public float enemySpawnTimer = 0f;
    public float enemySpawnDelay = 5f;

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

        enemySpawnTimer += Time.deltaTime;
        if (enemySpawnTimer >= enemySpawnDelay)
        {
            spawnEnemy();
            enemySpawnTimer = 0f;
        }
}

public void GameOver()
    {
        isGameOver = true;
        gameOverText.GetComponent<TMP_Text>().enabled = true;
        GameObject.Find("Player/Sprite").GetComponent<SpriteRenderer>().enabled = false;
    }

    public void spawnEnemy()
    {
        GameObject inst = Instantiate(enemyPrefab, RandomPointOnNavMesh(), Quaternion.identity);
    }

    public Vector3 RandomPointOnNavMesh()
    {
        var bounds = NavMesh.CalculateTriangulation();

        int index = Random.Range(0, bounds.vertices.Length);
        return bounds.vertices[index];
    }

}
