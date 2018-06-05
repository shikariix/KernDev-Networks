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

    void OnEnable() {
        transform.SetParent(playersListTransform.transform, false);
        //set this position from the parent object
        transform.position = new Vector3(transform.position.x, transform.position.y + playerId, transform.position.z);
    }


    public void UpdateScore(string score) {
        scoreText.text = score;
    }

}
