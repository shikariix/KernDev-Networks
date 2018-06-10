using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EventManager : NetworkBehaviour{

    public delegate void DelegateWithoutParameters();

    public static event DelegateWithoutParameters timeHitZero;

    public static void EndTimer() {
        timeHitZero();
    }
}
