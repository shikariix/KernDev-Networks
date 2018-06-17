using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Timer : NetworkBehaviour {

    public Text timerText;
    [SyncVar(hook = "OnChangeTime")] private double secondsLeft = 30;
    private bool countDown = false;
    private bool canSendScore = true;


    //time variables
    double timeOnLastFrame;
    double timePassed;

    void Start() {
        timeOnLastFrame = Network.time;
    }

    void Update() {
        
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
                foreach (Player p in FindObjectsOfType<Player>()) {
                    p.CmdSendPlayerToServer();
                }

                EventManager.instance.RpcEndTimer();
                canSendScore = false;
            }
        }
    }

    void OnChangeTime(double time) {
        timerText.text = time.ToString();
    }

    public void StartCountDown() {
        timeOnLastFrame = Network.time;
        countDown = true;
    }
}
