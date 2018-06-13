using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Note : NetworkBehaviour {
    
    [SyncVar] Color col;
    	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position -= transform.right / 8;
        GetComponent<SpriteRenderer>().color = col;

        if (!isServer) {
            return;
        }

        if (transform.position.x < -10) {
            //break combo, go to next player & remove note
            TurnManager.NextTurn();
            //controller.CmdDeactivateNote(gameObject);
            DeactivateNote();
        }
	}
    
    
    public void DeactivateNote() {
        NetworkServer.UnSpawn(gameObject);
        gameObject.SetActive(false);
    }

    public void SetColor(Color newColor) {
        col = newColor;
    }
}
