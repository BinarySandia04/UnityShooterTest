using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager {

    public LoadScript load;
    public Scene map;

    public override void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if(map == null) onlineScene = map.name;
        load.LoadLevel(null);
        base.OnMatchCreate(success, extendedInfo, matchInfo);
    }

    public override void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (map == null) onlineScene = map.name;
        load.LoadLevel(null);
        base.OnMatchJoined(success, extendedInfo, matchInfo);
    }

    public override void OnStartHost()
    {
        if (map == null) onlineScene = map.name;
        load.LoadLevel(null);
        base.OnStartHost();

        gameObject.GetComponent<NetworkManagerHUD>().enabled = false;
    }

    public override void OnStartClient(NetworkClient client)
    {
        if (map == null) onlineScene = map.name;
        load.LoadLevel(null);
        base.OnStartClient(client);

        gameObject.GetComponent<NetworkManagerHUD>().enabled = false;
    }

}
