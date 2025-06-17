using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider; // A reference to a Slider component used to display the player's health
    [SerializeField] Health playerHealth; // A reference to a Health component (presumably a custom script) that contains the player's health data

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreTextbox; // A reference to a TextMeshProUGUI component used to display the player's score
    ScoreKeeper scoreKeeper; // A reference to a ScoreKeeper script


    // The Awake method is called when the script instance is being loaded
    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>(); // finds and assigns the first instance of ScoreKeeper in the scene to the scoreKeeper variable
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth(); // sets the maximum value of the healthSlider to the player's current health using the GetHealth method from the Health script
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth(); // Sets the slider's value to the player's current health
        scoreTextbox.text = scoreKeeper.GetScore().ToString("000000000"); // Sets the score text to the current score, formatted as a zero-padded string with nine digits
    }
}
