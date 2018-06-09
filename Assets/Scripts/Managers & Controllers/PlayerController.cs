using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
    
    private NoteController noteController;
    
    private Score[] scores;

    void Start() {
        scores = FindObjectsOfType<Score>();
        /*for (int i = 0; i < TurnManager.MAX_PLAYERS; i++) {
            scoreTexts[i].text = scores[i].ToString();
        }*/
        
    }

    void Update() {
        //display the players & their scores
    }

    public void SetScore(float score) {
        scores[TurnManager.instance.CurrentPlayer()].SetScore(score);
        //scoreTexts[TurnManager.instance.CurrentPlayer()].text = scores[TurnManager.instance.CurrentPlayer()].ToString();
    }
}
