using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject PlayerObject;

	void Start ()
    {
        StartLevel();
	}

    public void StartLevel()
    {
        Instantiate(PlayerObject);
    }
}
