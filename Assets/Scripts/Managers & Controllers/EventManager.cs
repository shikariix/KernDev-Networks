using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EventManager : NetworkBehaviour{

    public static EventManager instance;
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public delegate void DelegateWithoutParameters();
    //[SyncEvent]
    public static event DelegateWithoutParameters EventTimeHitZero;
    
    [ClientRpc]
    public void RpcEndTimer() {
        Debug.Log("Starting event...");
        EventTimeHitZero();
    }
}
