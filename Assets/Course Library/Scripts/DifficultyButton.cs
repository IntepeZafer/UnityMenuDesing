using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    public Button button;
    private GameManager gameManager;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(setDificulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void setDificulty()
    {
        gameManager.StartGame();
    }
}
