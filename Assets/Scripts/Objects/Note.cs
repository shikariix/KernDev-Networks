using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    private SpriteRenderer sr;
    private NoteController controller;
    private PlayerController playerController;
    
	// Use this for initialization
	void Awake () {
        sr = GetComponent<SpriteRenderer>();
        controller = FindObjectOfType<NoteController>();
        playerController = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position -= transform.right / 8;
        if (transform.position.x < -10) {
            //make an event here to avoid tons of references?
            //break combo, go to next player & remove note
            TurnManager.NextTurn();
            controller.DeactivateNote(gameObject);
        }
	}

    public void SetColor(Color col) {
        sr.color = col;
    }
}
