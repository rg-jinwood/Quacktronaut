using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject deathCanvas;
    public Button playButton;

	void Start ()
    {
        deathCanvas.SetActive(false);
        var button = playButton.GetComponent<Button>();
        button.onClick.AddListener(Reload);
	}

    public void Update()
    {
        if (!PlayerState.IsAlive)
        {
            deathCanvas.SetActive(true);
        }
    }

    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
