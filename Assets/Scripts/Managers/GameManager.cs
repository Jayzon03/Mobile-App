using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public BaseEnemy[] enemies = new BaseEnemy[2];
    public GameObject enemyPrefab;
    [SerializeField] float spawnRate;
    bool gameStarted = false;
    int score = 0;
    public GameObject tapText;
    Vector2 screenPos;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Player player;
  


    void SpawnEnemy()
    {
        float randomX = Random.Range(0f, 1f);
        Vector2 viewPortPos = new Vector2(randomX, 1f);
        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewPortPos);
        int randomEnemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[randomEnemyIndex], worldPos, Quaternion.identity);
        score++;
        UpdateText(score);
        player.dodgerAttributes.SetScore(score);

    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, spawnRate);

    }

    private void Update()
    {
        if (transform.GetComponent<InputSystem>().IsPressing(out screenPos) && !gameStarted)
        {

            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);  
        }

    }
    void UpdateText(int score)
    {
        scoreText.text = score.ToString();
    }
}
