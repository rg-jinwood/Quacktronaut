using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	void Start ()
    {
        var token = PlayerPrefs.GetString("token");

        if(string.IsNullOrEmpty(token))
            SceneManager.LoadScene(0); //if we're missing the token go back to the main menu

    }

}
