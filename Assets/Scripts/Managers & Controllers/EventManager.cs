using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EventManager : NetworkBehaviour{

    public delegate void EventWithoutParameters();
    [SyncEvent]
    public static event EventWithoutParameters EventTimeHitZero;

    public static void EndTimer() {
        EventTimeHitZero();
    }
}
