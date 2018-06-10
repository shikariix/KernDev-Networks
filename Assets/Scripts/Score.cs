using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Score : NetworkBehaviour {

    [SyncVar] public int score = 0;
    private Player p;

    void Start() {
        p = GetComponent<Player>();
    }

    void OnEnable() {
        EventManager.timeHitZero += CallSaveData;
    }
    void OnDisable() {
        EventManager.timeHitZero -= CallSaveData;
    }

    public void SetScore(float amount) {
        if (!isLocalPlayer) {
            return;
        }
        score += (int)amount;
        p.UpdateScore(score.ToString());
    }

    public void CallSaveData() {
        if (!isLocalPlayer) {
            return;
        }
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData() {
        WWWForm form = new WWWForm();
        form.AddField("Score", score);
        form.AddField("gameid", 6);

        WWW www = new WWW("http://studenthome.hku.nl/~sarah.steenhuis/database/addscore.php?PHPSESSID=" + Player.session, form);
        yield return www;

        if (www.text[0] == '0') {
            Debug.Log("Score saved.");
        } else {
            Debug.Log("Save failed. Error no." + www.text);
        }

        FindObjectOfType<MyNetworkManager>().ServerChangeScene("Menu");
    }
}
