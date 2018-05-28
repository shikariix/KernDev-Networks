using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Score : NetworkBehaviour {

    [SyncVar] public int score = 0;
    private Player p;

    void Start() {
        p = GetComponent<Player>();
    }

    public void SetScore(float amount) {
        score += (int)amount;
        p.UpdateScore(score.ToString());
    }
}
