using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour {

    public Note notePrefab;
    private NoteObjectPool notePool;

    private int randomNote;
    private float timeUntilNextNote;
    private float timePassedSinceLastNote;

    public Queue<GameObject> activeNotes;

	// Use this for initialization
	void Start () {
        SetNewNoteTime();
        notePool = GetComponent<NoteObjectPool>();
        activeNotes = new Queue<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        //randomly spawn different colored notes
        //keep track of active notes
        timePassedSinceLastNote += Time.deltaTime;
        if (timePassedSinceLastNote >= timeUntilNextNote) {
            activeNotes.Enqueue(GetNote());

            SetNewNoteTime();
            timePassedSinceLastNote = 0;
        }
    }

    public void DeactivateNote(GameObject note) {
        activeNotes.Dequeue();
        note.SetActive(false);
    }

    GameObject GetNote() {
        randomNote = Random.Range(0, 4);
        switch (randomNote) {
            case 0:
                return notePool.GetObject(Color.blue);
            case 1:
                return notePool.GetObject(Color.green);
            case 2:
                return notePool.GetObject(Color.yellow);
            case 3:
                return notePool.GetObject(Color.red);
            default:
                return notePool.GetObject(Color.blue);
        }
    }

    void SetNewNoteTime() {
        timeUntilNextNote = Random.Range(2, 8) * 10 * Time.deltaTime;
    }
}
