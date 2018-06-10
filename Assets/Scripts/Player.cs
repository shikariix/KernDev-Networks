using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

    internal int playerId = -1;
    public Text scoreText;
    public GameObject playersListTransform;

    public static string username;
    public static string session;
    private Score score;

    void Awake() {
        playersListTransform = GameObject.FindWithTag("PlayersList");
        score = GetComponent<Score>();
    }

    void OnEnable() {
        transform.SetParent(playersListTransform.transform, false);
        //set this position from the parent object
        transform.position = new Vector3(transform.position.x, transform.position.y + (playerId * 10), transform.position.z);
    }

    void Update() {
        if (!isLocalPlayer) {
            return;
        }
        //manage input
        for (int i = 0; i < 4; i++) {
            string keyCode = "Button" + (i+1);
            if (Input.GetButtonDown(keyCode)) {
                GameController.instance.CheckTrigger(i, playerId);
            }
        }
    }


    public void UpdateScore(string score) {
        scoreText.text = score;
    }

}
