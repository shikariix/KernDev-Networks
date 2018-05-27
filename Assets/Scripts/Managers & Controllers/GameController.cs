using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private PlayerController playerController;
    private NoteController noteController;

    public SuccessTrigger[] triggers;

	// Use this for initialization
	void Start () {
        playerController = GetComponent<PlayerController>();
        noteController = GetComponent<NoteController>();
	}
	

	void Update () {

        //manage input
        for (int i = 0; i < triggers.Length; i++) {
            string keyCode = "Button" + (i+1);
            if (Input.GetButtonDown(keyCode) && triggers[i].IsNoteNear()) {
                playerController.SetScore(triggers[i].GetScore());
                TurnManager.NextTurn();
                noteController.DeactivateNote(triggers[i].GetNearNote());
            }
        }
    }
}
