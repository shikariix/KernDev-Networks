using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Timer : NetworkBehaviour {

    public Text timerText;
    [SyncVar]
    private double secondsLeft = 30;
    private bool countDown = false;
    private bool canSendScore = true;

    private NoteController nc;


    //time variables
    double timeOnLastFrame;
    double timePassed;

    void Start() {
        nc = gameObject.GetComponent<NoteController>();
        timeOnLastFrame = Network.time;
    }

    void Update() {
        timerText.text = secondsLeft.ToString();

        if (!isServer) {
            return;
        }

        if (countDown) {
            timePassed = Network.time - timeOnLastFrame;
            secondsLeft -= timePassed;
            timeOnLastFrame = Network.time;
        }
        if (secondsLeft <= 0) {
            countDown = false;
            secondsLeft = 0;
            if (canSendScore) { 
                EventManager.EndTimer();
                canSendScore = false;
            }
        }
    }

    public void StartCountDown() {
        countDown = true;
    }
}
