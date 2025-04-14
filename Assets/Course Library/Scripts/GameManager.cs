using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public float spawnRate = 1.0f;
    private int score = 0;

    void Start()
    {
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
    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
