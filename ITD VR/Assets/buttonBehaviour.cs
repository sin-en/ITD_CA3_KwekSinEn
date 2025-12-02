using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonBehaviour : MonoBehaviour
{
    [SerializeField]
    public int sceneIndex;

    public TMPro.TextMeshProUGUI errormsg;
    public TMPro.TMP_InputField passwordInput;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void CheckPassword()
    {
        if (passwordInput.text == "123456")
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            StartCoroutine(ShowErrorMessage());
        }
    }

    IEnumerator ShowErrorMessage()
    {
        errormsg.text = "Incorrect Password. Try Again.";
        yield return new WaitForSeconds(5);
        errormsg.text = "";
    }
}
