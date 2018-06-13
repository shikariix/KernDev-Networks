using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    private PlayerController playerController;

    public SuccessTrigger[] triggers;


    public static GameController instance;
    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        playerController = GetComponent<PlayerController>();
        
    }
    
    [ClientRpc]
    public void RpcCheckTrigger(int index, int playerId) {
        if (triggers[index].IsNoteNear() && playerId == TurnManager.instance.CurrentPlayer()) {
            playerController.RpcSetScore(triggers[index].GetScore());
            TurnManager.NextTurn();
            triggers[index].GetNearNote().DeactivateNote();
        }
    }
    
}
