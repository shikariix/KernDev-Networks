using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    
    public void PlayGame() {
        SceneManager.LoadScene("Main");
    }

    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void GoToLogin() {
        SceneManager.LoadScene("Login");
    }

    public void GoToRegister() {
        SceneManager.LoadScene("Register");
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("You cant quit in the editor!");
    }
}
