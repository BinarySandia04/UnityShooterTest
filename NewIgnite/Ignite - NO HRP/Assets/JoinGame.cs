using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour {

    List<GameObject> roomList = new List<GameObject>();

    [SerializeField]
    private Text status;

    [SerializeField]
    private GameObject roomListItemPrefab;

    [SerializeField]
    private Transform roomListParent;

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        RefreshRoomList();
    }

    public void RefreshRoomList()
    {
        ClearRoomList();
        networkManager.matchMaker.ListMatches(0, 20, "", false, 0, 0, OnMatchList);
        status.text = "Loading...";
    }

    public void OnMatchList(bool succes, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        status.text = "";

        if(matches == null)
        {
            status.text = "Error";
            return;
        }

        ClearRoomList();

        foreach(MatchInfoSnapshot info in matches)
        {
            GameObject _roomListItem = Instantiate(roomListItemPrefab);
            _roomListItem.transform.SetParent(roomListParent);

            RoomListItem _roomListItemInfo = _roomListItem.GetComponent<RoomListItem>();
            if(_roomListItemInfo != null)
            {
                _roomListItemInfo.Setup(info, JoinRoom);
            }
            
            // as well as setting up a callback function that will join the game

            roomList.Add(_roomListItem);

        }

        if(roomList.Count == 0)
        {
            status.text = "No rooms found";
        }
    }

    void ClearRoomList()
    {
        for(int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }

        roomList.Clear();
    }

    public void JoinRoom(MatchInfoSnapshot _match)
    {
        Debug.Log("Joining " + _match.name);

        networkManager.matchMaker.JoinMatch(_match.networkId, "", "", "", 0, 0, networkManager.OnMatchJoined);
        ClearRoomList();
        status.text = "Joining...";
    }

}
