using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour{

    public delegate void TimerEnd();
    public static event TimerEnd timeHitZero;
    
    public static void EndTimer() {
        timeHitZero();
    }
}
