using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    const float GAME_DURATION = 240.0f;
    public static Timer instance;
    public static float timeRemaining;
    [SerializeField] TextMeshPro timeText;
    private void Awake() {
        instance = this;
        timeRemaining = GAME_DURATION;
    }

    private void Update() {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0) {
            SceneManager.LoadScene("Leaderboard");
        }
        timeText.text = "Remaining\ntime: " + (timeRemaining).ToString();
    }    
}
