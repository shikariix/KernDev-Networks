using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessTrigger : MonoBehaviour {

    private bool isNoteNear;
    private float noteDistance;
    private GameObject nearNote;

    [SerializeField]
    private float maxScore;
    private float score;

    void Start() {
        score = maxScore;
    }

    void FixedUpdate() {
        if (isNoteNear) {
            score = maxScore - (noteDistance * 150);
        } else {
            score = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        isNoteNear = true;
        nearNote = col.gameObject;
    }
    
    void OnTriggerStay2D(Collider2D col) {
        noteDistance = Vector2.Distance(transform.position, col.gameObject.transform.position);
    }

    void OnTriggerExit2D(Collider2D col) {
        isNoteNear = false;
        nearNote = null;
    }

    //Can I shorten these return functions?
    public bool IsNoteNear() {
        return isNoteNear;
    }

    public float GetScore() {
        return score;
    }

    public GameObject GetNearNote() {
        return nearNote;
    }
}
