using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject email;
    public GameObject password;
    public Button loginButton;

    private string Email;
    private string Password;

    private void Start()
    {
        var button = loginButton.GetComponent<Button>();
        button.onClick.AddListener(Authenticate);
    }

    private void Authenticate ()
    {
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;

        StartCoroutine(LoginHelper.Login(Email, Password));
    }
}
