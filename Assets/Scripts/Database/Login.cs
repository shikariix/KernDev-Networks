using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {
    
    public InputField passwordField;
    public InputField emailField;
    public Button submitButton;

    public void CallLogin() {
        StartCoroutine(UserLogin());
    }

    IEnumerator UserLogin() {

        WWWForm form = new WWWForm();
        form.AddField("Email", emailField.text);
        form.AddField("Password", passwordField.text);
        WWW www = new WWW("http://studenthome.hku.nl/~sarah.steenhuis/database/login.php", form);
        yield return www;

        if (www.text[0] == '0') {
            DBManager.username = www.text.Split('\t')[1];
            DBManager.session = www.text.Split('\t')[2];

            //DBManager.score = int.Parse(www.text.Split('\t')[1]);
            Debug.Log("User logged in succesfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else {
            Debug.Log("User login failed. Error no." + www.text);
        }
    }

    public void VerifyInputs() {
        submitButton.interactable = (emailField.text.Length >= 8 && passwordField.text.Length >= 8);

    }
}
