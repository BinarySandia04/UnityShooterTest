using TMPro;
using UnityEngine;
using UnityEngine.Networking.Match;
public class RoomListItem : MonoBehaviour {

    public delegate void JoinRoomDelegate(MatchInfoSnapshot _match);
    private JoinRoomDelegate joinRoomCallback;

    [SerializeField]
    private TextMeshProUGUI roomNameText;

    [SerializeField]
    private TextMeshProUGUI roomMapText;

    [SerializeField]
    private TextMeshProUGUI roomPlayersText;
    

    private MatchInfoSnapshot match;

    public void Setup(MatchInfoSnapshot _match, JoinRoomDelegate _joinRoomCallback)
    {
        match = _match;
        joinRoomCallback = _joinRoomCallback;

        roomNameText.text = match.name;
        roomMapText.text = "Map: Default";
        roomPlayersText.text = "Players: ( " + match.currentSize + " / " + match.maxSize + " )";

    }

    public void JoinRoom()
    {
        joinRoomCallback.Invoke(match);
    }
}
