using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTextbox;
    ScoreKeeper scoreKeeper;

    // The Awake method is called when the script instance is being loaded
    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>(); // finds and assigns the first instance of ScoreKeeper in the scene to the scoreKeeper variable
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreTextbox.text = "Final Score:\n" + scoreKeeper.GetScore(); // sets the text of the scoreText component to display the player's score by getting the score from the scoreKeeper and formatting it
    }
}
