using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button pauseButton;

	void Start ()
    {
        PlayerState.IsAlive = true;
        Time.timeScale = 1f;
        var button = pauseButton.GetComponent<Button>();
        button.onClick.AddListener(PauseGame);

        var token = PlayerPrefs.GetString("token");

        if(string.IsNullOrEmpty(token))
            SceneManager.LoadScene(0); //if we're missing the token go back to the main menu

    }

    private void PauseGame()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return;
        }
        Time.timeScale = 0f;
    }

}
