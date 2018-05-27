using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


    private NoteController noteController;

    private int[] scores;
    private GameObject[] playersList;
    public Text[] scoreTexts;

    void Start() {
        scores = new int[TurnManager.MAX_PLAYERS];
        for (int i = 0; i < TurnManager.MAX_PLAYERS; i++) {
            scoreTexts[i].text = scores[i].ToString();
        }
        
    }

    void Update() {
        //display the players & their scores
    }

    public void SetScore(float score) {
        scores[TurnManager.instance.CurrentPlayer()] += (int)score;
        scoreTexts[TurnManager.instance.CurrentPlayer()].text = scores[TurnManager.instance.CurrentPlayer()].ToString();
    }
}
