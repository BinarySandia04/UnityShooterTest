using UnityEngine;
using System.Collections;
using DatabaseControl;
using TMPro;

public class UserAccountManagement : MonoBehaviour {

    public static UserAccountManagement instance;

    public TextMeshProUGUI usernameText;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);
    }
    
    public static string playerUsername { get; protected set; }
    public static string playerPassword { get; protected set; }

    public static bool isLoggedIn { get; protected set; }

    public static bool dataIsSetUp { get; protected set; }

    public static string Data { get; protected set; }

    public delegate void OnDataReceivedCallback(string data);

    public void LogOut()
    {
        playerPassword = "";
        playerUsername = "";

        isLoggedIn = false;
    }

    public void LogIn(string username, string password)
    {
        playerUsername = username;
        playerPassword = password;
        usernameText.text = playerUsername;

        isLoggedIn = true;
    }
    public void sendData(string data)
    {
        StartCoroutine(SendData(data));
    }
    public void getData()
    {
        StartCoroutine(GetData());
    }
    IEnumerator GetData()
    {
        IEnumerator e = DCF.GetUserData(playerUsername, playerPassword); // << Send request to get the player's data string. Provides the username and password
        while (e.MoveNext())
        {
            yield return e.Current;
        }
        string response = e.Current as string; // << The returned string from the request

        if (response == "Error")
        {
            Debug.Log("Error");
        }
        else
        {
            Data = response;
            dataIsSetUp = true;
        }
    }
    IEnumerator SendData(string data)
    {
        IEnumerator e = DCF.SetUserData(playerUsername, playerPassword, data); // << Send request to set the player's data string. Provides the username, password and new data string
        while (e.MoveNext())
        {
            yield return e.Current;
        }
        string response = e.Current as string; // << The returned string from the request

        if (response == "Success")
        {
            Debug.Log("Data enviada!");

        }
    }

    public void updateData()
    {
        StartCoroutine(GetData());
    }

    private bool _firstTimeUpdatedData = true;

    void Update()
    {
        if (isLoggedIn && _firstTimeUpdatedData)
        {
            _firstTimeUpdatedData = false;
            updateData();
        }
    }

    void Start()
    {
        dataIsSetUp = false;
    }
}
