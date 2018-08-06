using UnityEngine;
using System.Collections;
using DatabaseControl;

public class UserAccountManagement : MonoBehaviour {

    public static UserAccountManagement instance;

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

    public static string LoggedIn_Data { get; protected set; }

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

        isLoggedIn = true;
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
            Debug.Log(response);
            LoggedIn_Data = response;
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
}
