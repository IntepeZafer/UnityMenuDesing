using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    // public TextMeshProUGUI scoreText;
    public List<TextMeshProUGUI> textMessages;
    public float spawnRate = 1.0f;
    private int score = 0;
    public bool isGameActive;

    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        updateScore(0);
    }

    IEnumerator SpawnTarget() 
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void GameOver()
    {
        textMessages[1].gameObject.SetActive(true);
        isGameActive = false;
    }
    public void ResrartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        textMessages[0].text = "Score: " + score;
    }
}
