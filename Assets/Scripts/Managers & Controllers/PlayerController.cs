using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
        
    private Score[] scores;
    
    [ClientRpc]
    public void RpcSetScore(float score) {
        TurnManager.instance.activePlayers[TurnManager.instance.CurrentPlayer()].GetComponent<Score>().CmdSetScore(score);
    }
    
}
