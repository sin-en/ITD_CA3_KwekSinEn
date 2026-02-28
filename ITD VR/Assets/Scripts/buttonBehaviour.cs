using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonBehaviour : MonoBehaviour
{
    public TMPro.TextMeshProUGUI errormsg;
    public TMPro.TMP_InputField passwordInput;
    public TMPro.TextMeshProUGUI successmsg;

    public GameObject loginCanvas;
    public GameObject game;

    public void CheckPassword()
    {
        if (passwordInput.text == "123456")
        {
            Debug.Log("Login Successful!");
            StartCoroutine(ShowSuccessMessage());
        }
        else
        {
            Debug.Log("Incorrect Password. Try Again.");
            StartCoroutine(ShowErrorMessage());
        }
    }
    IEnumerator ShowSuccessMessage()
    {
        successmsg.text = "Login Successful!";
        loginCanvas.SetActive(false);
        game.SetActive(true);
        yield return new WaitForSeconds(2);
        successmsg.text = "";
    }

    IEnumerator ShowErrorMessage()
    {
        errormsg.text = "Incorrect Password. Try Again.";
        yield return new WaitForSeconds(5);
        errormsg.text = "";
    }
}
