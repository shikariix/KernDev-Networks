using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Score : NetworkBehaviour {

    [SyncVar] public int score = 0;


    public void SetScore(float score) {
        score += (int)score;
    }
}
