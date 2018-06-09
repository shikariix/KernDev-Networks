using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float secondsLeft = 10;
    private bool countDown = false;
    private bool canSendScore = true;

    private NoteController nc;

    void Start() {
        nc = gameObject.GetComponent<NoteController>();
    }

    void Update() {
        if (countDown) {
            secondsLeft -= Time.deltaTime;
        }
        if (secondsLeft <= 0) {
            countDown = false;
            secondsLeft = 0;
            if (canSendScore) { 
                EventManager.EndTimer();
                canSendScore = false;
            }
        }
        timerText.text = secondsLeft.ToString();
    }

    public void StartCountDown() {
        countDown = true;
    }
}
