using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Score : NetworkBehaviour {

    [SyncVar (hook = "OnScoreChanged")] public int score = 0;
    private Player p;
    
    public Text scoreText;

    void Start() {
        p = GetComponent<Player>();
        scoreText.text = score.ToString();
    }
    
    public void SetScore(float amount) {
        score += (int)amount;
    }
    
    public void OnScoreChanged(int score) {
        scoreText.text = score.ToString();
    }
}
