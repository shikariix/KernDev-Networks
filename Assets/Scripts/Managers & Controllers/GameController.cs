using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    private PlayerController playerController;
    private NoteController noteController;

    //time variables
    //double timeOnLastFrame = Network.time;
    //double timePassed;

    public SuccessTrigger[] triggers;

	// Use this for initialization
	void Start () {
        playerController = GetComponent<PlayerController>();
        noteController = GetComponent<NoteController>();
        //timeOnLastFrame = Network.time;
    }
	

	void Update () {
        //timePassed = Network.time - timeOnLastFrame;
        //timeOnLastFrame = Network.time;


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
}
