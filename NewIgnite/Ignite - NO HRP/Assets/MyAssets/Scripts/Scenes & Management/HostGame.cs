using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour {
    

    [SerializeField]
    private uint roomSize = 8;

    private string roomName;

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void setRoomName(string _name)
    {
        roomName = _name;
    }

    public void CreateRoom()
    {
        if(roomName != "" && roomName != null)
        {
            Debug.Log("Creando sala: " + roomName + " para " + roomSize + " jugadores.");
            // Create room
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);

        }
    }

    public void TurnOffMatchMaker()
    {
        networkManager.StopMatchMaker();
    }

    public void TurnOnMatchMaker()
    {
        networkManager.StartMatchMaker();
        networkManager.OnStartHost();
    }

    

    

}
