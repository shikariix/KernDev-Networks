using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

    internal static int playerId = -1;
    public GameObject playersListTransform;

    //UI elements
    public Text scoreText;
    public Text nameText;

    //Player data
    public static string username;
    public static string session;
    
    [SyncVar] private string uname;

    public PlayerController controller;

    void Awake() {
        playersListTransform = GameObject.FindWithTag("PlayersList");
        if (!TurnManager.instance.activePlayers.Contains(this)) { 
            playerId = TurnManager.Register(this);
        }
        CmdSendNameToServer(username);
        controller = FindObjectOfType<PlayerController>();
    }

    void OnEnable() {
        transform.SetParent(playersListTransform.transform, false);

    }

    void Update() {
        if (!isLocalPlayer) {
            return;
        }
        //manage input
        for (int i = 0; i < 4; i++) {
            string keyCode = "Button" + (i+1);
            if (Input.GetButtonDown(keyCode)) {
                CmdCheckInput(i);
            }
        }
    }

    [Command]
    public void CmdCheckInput(int index) {
        GameController.instance.RpcCheckTrigger(index, playerId);
    }

    [Command]
    public void CmdUpdateScore(int score) {
        scoreText.text = score.ToString();
    }

    [Command]
    public void CmdSendNameToServer(string nameToSend) {
        RpcDisplayUsername(nameToSend);
    }

    [ClientRpc]
    void RpcDisplayUsername(string name) {
        uname = name;
        nameText.text = uname;
    }

    public int GetID() {
        return playerId;
    }
}
