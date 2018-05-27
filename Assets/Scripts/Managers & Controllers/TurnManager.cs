using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    //this increments as long as new players arrive
    static int playerId = 0;

    //list variables, so we can have any order of active players, also keeping in mind they might D/C and reconnect
    int currentPlayer = 0;
    List<int> activePlayerIds = new List<int>();
    public const int MAX_PLAYERS = 4;

    public static TurnManager instance;

    void Awake() {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //called from custom networkmanager
    public static void OnClientDisconnect() {
        instance.StartCoroutine(instance.CheckPlayerIds());
    }

    public int CurrentPlayer() {
        return currentPlayer;
    }

    //basically rebuilds all active playerId's from spawned player objects
    //not super efficient, but shouldn't happen too often
    IEnumerator CheckPlayerIds() {
        //if we do this right away, the disconnected player is still present
        yield return new WaitForSeconds(.25f);

        int currentId = activePlayerIds[currentPlayer];

        Debug.Log("RECREATING LIST");
        //rebuild active player list
        Player[] players = FindObjectsOfType<Player>();

        activePlayerIds.Clear();
        foreach (Player p in players) {
            activePlayerIds.Add(p.playerId);
        }

        if (activePlayerIds.Contains(currentId)) {
            currentPlayer = activePlayerIds.IndexOf(currentId);
        }
        else {
            currentPlayer = 0;
        }
    }
    
    /// Player objects register themselves when they are spawned (server-only)
    public static int Register(Player p) {
        instance.activePlayerIds.Add(playerId);
        Debug.Log("Registered player " + playerId);
        return playerId++;
    }


    /// Used by players to determine if it is their turn, only called from server-side objects
	public static bool IsTurn(int id) {
        if (instance.currentPlayer >= instance.activePlayerIds.Count) {
            instance.currentPlayer = 0;
            instance.CheckPlayerIds();
        }
        return instance.activePlayerIds[instance.currentPlayer] == id;
    }
    
    /// Moves the turn to the next player in the list
    /// TODO: Tell clients who's turn it is!
    public static void NextTurn() {
        //if (++instance.currentPlayer >= instance.activePlayerIds.Count) {
        if (++instance.currentPlayer >= MAX_PLAYERS) {
            instance.currentPlayer = 0;
        }
    }
}
