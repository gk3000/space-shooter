using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance; // A static variable to hold the singleton instance of ScoreKeeper

    int score;

    void Awake()
    {
        ManageSingleton(); // It calls ManageSingleton to ensure that only one instance of ScoreKeeper exists
    }

    void ManageSingleton()
    {
        if (instance != null) // If an instance of ScoreKeeper already exists (instance != null), it deactivates and destroys the current GameObject
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else // If no instance exists, it sets the instance to this instance and marks the GameObject to not be destroyed when loading a new scene with DontDestroyOnLoad
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        //Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
