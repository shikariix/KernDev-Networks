using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    private PlayerController playerController;
    private NoteController noteController;

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
        noteController = GetComponent<NoteController>();
        
    }

    public void CheckTrigger(int index, int playerId) {
        if (triggers[index].IsNoteNear()) {
            playerController.SetScore(triggers[index].GetScore());
            TurnManager.NextTurn();
            triggers[index].GetNearNote().DeactivateNote();
        }
    }

	/*void Update () {
        if (isLocalPlayer) { 
            //manage input
            for (int i = 0; i < triggers.Length; i++) {
                string keyCode = "Button" + (i+1);
                if (Input.GetButtonDown(keyCode) && triggers[i].IsNoteNear()) {
                    playerController.SetScore(triggers[i].GetScore());
                    TurnManager.NextTurn();
                    noteController.CmdDeactivateNote(triggers[i].GetNearNote());
                }
            }
        }
    }*/
}
