using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NoteObjectPool : NetworkBehaviour {

    public const int MAX_NOTES = 20;
    public GameObject notePrefab;

    public Note[] objects;
    private int currentNote = 0;

    [SerializeField]
    private float xPosition;
    [SerializeField]
    private float yOffset;

    void Start() {
        if (!isServer) {
            return;
        }
        CmdMakeObjects();
    }
    [Command]
    void CmdMakeObjects() {
        objects = new Note[MAX_NOTES];
        for (int i = 0; i < MAX_NOTES; ++i) {
            //this creates the objects all on the same position
            //position should be changed on load

            objects[i] = Instantiate(notePrefab).GetComponent<Note>();
            NetworkServer.Spawn(objects[i].gameObject);
            objects[i].gameObject.SetActive(false);
        }
    }

    //return note as object
    public GameObject GetObject(Color col) {
        //activate current note with position based on random color
        Note note = objects[currentNote];
        Vector3 position = new Vector3 (xPosition, -4, 0);
        if (col == Color.blue) {
            position.y += yOffset * 4;
        }
        else if (col == Color.green) {
            position.y += yOffset * 3;
        }
        else if (col == Color.yellow) {
            position.y += yOffset * 2;
        }
        else if (col == Color.red) {
            position.y += yOffset;
        }
        note.gameObject.transform.position = position;
        note.gameObject.SetActive(true);
        note.SetColor(col);

        //cycle through notes, make sure to loop around
        if (++currentNote == MAX_NOTES) {
            currentNote = 0;
        }

        return note.gameObject;
    }
}
