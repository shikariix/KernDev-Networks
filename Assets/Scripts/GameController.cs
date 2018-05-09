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
        //make this a for loop?
        if (Input.GetKeyDown(KeyCode.Alpha1) && triggers[0].IsNoteNear()) {
            playerController.SetScore(triggers[0].GetScore());
            playerController.UpdatePlayer();
            noteController.DeactivateNote(triggers[0].GetNearNote());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) {
            playerController.UpdatePlayer();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && triggers[1].IsNoteNear()) {
            playerController.SetScore(triggers[1].GetScore());
            playerController.UpdatePlayer();
            noteController.DeactivateNote(triggers[1].GetNearNote());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            playerController.UpdatePlayer();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && triggers[2].IsNoteNear()) {
            playerController.SetScore(triggers[2].GetScore());
            playerController.UpdatePlayer();
            noteController.DeactivateNote(triggers[2].GetNearNote());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            playerController.UpdatePlayer();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && triggers[3].IsNoteNear()) {
            playerController.SetScore(triggers[3].GetScore());
            playerController.UpdatePlayer();
            noteController.DeactivateNote(triggers[3].GetNearNote());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            playerController.UpdatePlayer();
        }
    }
}
