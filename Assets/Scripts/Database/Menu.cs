using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Text playerDisplay;

	void Start () {
		if (DBManager.loggedIn) {
            playerDisplay.text = "Player: " + DBManager.username;
        }
	}
}
