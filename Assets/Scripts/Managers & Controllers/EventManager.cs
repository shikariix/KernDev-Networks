using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EventManager : NetworkBehaviour{

    public delegate void EventWithoutParameters();
    [SyncEvent]
    public static event EventWithoutParameters EventTimeHitZero;

    [ClientRpc]
    public static void RpcEndTimer() {
        EventTimeHitZero();
    }
}
