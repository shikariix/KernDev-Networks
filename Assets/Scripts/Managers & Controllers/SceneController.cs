using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    
    public void PlayGame() {
        SceneManager.LoadScene("Main");
    }

    public void JoinLobby() {
        SceneManager.LoadScene("Lobby");
    }

    public void Login() {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("You cant quit in the editor!");
    }
}
