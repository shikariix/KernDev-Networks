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
        EventManager.timeHitZero += CmdRemoveAllNotes;
        EventManager.timeHitZero += StopTime;
    }

    void OnDisable() {
        EventManager.timeHitZero -= CmdRemoveAllNotes;
        EventManager.timeHitZero -= StopTime;
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

    [Command]
    public void CmdDeactivateNote(GameObject note) {
        activeNotes.Dequeue();
        note.SetActive(false);
    }

    [Command]
    public void CmdRemoveAllNotes() {
        foreach(GameObject obj in activeNotes) {
            obj.SetActive(false);
        }
        activeNotes.Clear();
    }

    [Command]
    void CmdSpawnNote() {
        Color col = GetColor();
        GameObject note = notePool.GetObject(col);
        activeNotes.Enqueue(note);
        note.GetComponent<SpriteRenderer>().material.color = col;
        NetworkServer.Spawn(note);
    }

    Color GetColor() {
        randomNote = Random.Range(0, 4);
        switch (randomNote) {
            case 0:
                return Color.blue;
            case 1:
                return Color.green;
            case 2:
                return Color.yellow;
            case 3:
                return Color.red;
            default:
                return Color.blue;
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
