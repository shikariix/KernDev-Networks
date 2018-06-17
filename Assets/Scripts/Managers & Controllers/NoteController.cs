using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NoteController : NetworkBehaviour {

    public Note notePrefab;
    private NoteObjectPool notePool;

    private int randomNote;
    private float timeUntilNextNote;
    private float timePassedSinceLastNote;

    private Color nextNoteColor;

    public Queue<GameObject> activeNotes;

	// Use this for initialization
	void Start () {
        if (!isServer) {
            return;
        }
        StopTime();
        SetNewNoteTime();
        notePool = GetComponent<NoteObjectPool>();
        activeNotes = new Queue<GameObject>();
    }

    void OnEnable() {
        EventManager.EventTimeHitZero += RemoveAllNotes;
        EventManager.EventTimeHitZero += StopTime;
    }

    void OnDisable() {
        EventManager.EventTimeHitZero -= RemoveAllNotes;
        EventManager.EventTimeHitZero -= StopTime;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (!isServer) {
            return;
        }
        //randomly spawn different colored notes
        //keep track of active notes
        timePassedSinceLastNote += Time.deltaTime;
        if (timePassedSinceLastNote >= timeUntilNextNote) {
            CmdSpawnNote();

            SetNewNoteTime();
            timePassedSinceLastNote = 0;
        }
    }
    

    public void RemoveAllNotes() {
        if (!isServer) {
            return;
        }
        foreach(GameObject obj in activeNotes) {
            obj.GetComponent<Note>().DeactivateNote();
        }
        activeNotes.Clear();
    }

    [Command]
    void CmdSpawnNote() {
        RpcGetColor();
        GameObject note = notePool.GetObject(nextNoteColor);
        activeNotes.Enqueue(note);
        NetworkServer.Spawn(note);
    }
    
    [ClientRpc]
    void RpcGetColor() {
        randomNote = Random.Range(0, 4);
        switch (randomNote) {
            case 0:
                nextNoteColor = Color.blue;
                break;
            case 1:
                nextNoteColor = Color.green;
                break;
            case 2:
                nextNoteColor = Color.yellow;
                break;
            case 3:
                nextNoteColor = Color.red;
                break;
            default:
                nextNoteColor = Color.blue;
                break;
        }
    }

    void SetNewNoteTime() {
        timeUntilNextNote = Random.Range(2, 8) * 10 * Time.deltaTime;
    }

    public void StopTime() {
        Time.timeScale = 0;
    }

    public void StartTime() {
        Time.timeScale = 1;

    }
}
