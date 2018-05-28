using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

    internal int playerId = -1;
    public Text scoreText;
    public GameObject playersListTransform;
    

    void Awake() {
        scoreText = GetComponentInChildren<Text>();
        playersListTransform = GameObject.FindWithTag("PlayersList");
    }

    void OnClientConnect() {
        transform.parent = playersListTransform.transform;
    }

    public void UpdateScore(string score) {
        scoreText.text = score;
    }

}
