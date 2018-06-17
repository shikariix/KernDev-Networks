using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    
    public List<int> scores;
    private List<string> sessions;

    void Start() {
        scores = new List<int>();
        sessions = new List<string>();
    }
    
    public void AddPlayer(string session, int score) {
        Debug.Log("Amount of players: " + scores.Count);
        sessions.Add(session);
        scores.Add(score);
    }

    void OnEnable() {
        EventManager.EventTimeHitZero += CallSaveData;
    }
    void OnDisable() {
        EventManager.EventTimeHitZero -= CallSaveData;
    }


    public void CallSaveData() {
        Debug.Log("Scores to send: " + scores.Count);
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData() {
        for(int i = 0; i < scores.Count; i++) {
            Debug.Log("Score " + i + ": " + scores[i]);
        WWWForm form = new WWWForm();
        form.AddField("Score", scores[i]);
        form.AddField("gameid", 6);

        WWW www = new WWW("http://studenthome.hku.nl/~sarah.steenhuis/database/addscore.php?PHPSESSID=" + sessions[i], form);
        yield return www;

        if (www.text[0] == '0') {
            Debug.Log("Score saved.");
        }
        else {
            Debug.Log("Save failed. Error no." + www.text);
        }
        }

        //FindObjectOfType<MyNetworkManager>().ServerChangeScene("Menu");
    }
    
    [ClientRpc]
    public void RpcSetScore(float score, int playerIndex) {
        //scores[playerIndex] += (int)score;
        TurnManager.instance.activePlayers[playerIndex].GetComponent<Score>().SetScore(score);
    }
    
}
