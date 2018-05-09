using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private int currentPlayer = 1;
    public const int MAX_PLAYERS = 4;

    private int[] scores;
    public Text[] scoreTexts;

    void Start() {
        scores = new int[MAX_PLAYERS];
        for (int i = 0; i < MAX_PLAYERS; i++) {
            scoreTexts[i].text = scores[i].ToString();
        }
    }

    public int CurrentPlayer() {
        return currentPlayer;
    }

    public void UpdatePlayer() {
        if (++currentPlayer > MAX_PLAYERS) {
            currentPlayer = 1;
        }
    }

    public void SetScore(float score) {
        scores[currentPlayer - 1] += (int)score;
        scoreTexts[currentPlayer - 1].text = scores[currentPlayer - 1].ToString();
    }
}
