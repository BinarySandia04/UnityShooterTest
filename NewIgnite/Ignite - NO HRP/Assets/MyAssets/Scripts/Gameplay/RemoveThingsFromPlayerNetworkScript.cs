using UnityEngine;
using UnityEngine.Networking;

public class RemoveThingsFromPlayerNetworkScript : NetworkBehaviour {

    public GameObject Canvas;
    public GameObject FirstCameraPoint;
    public GameObject Camera;
    public GameObject Player;

	void Update () {
        if (!isLocalPlayer)
        {
            Canvas.SetActive(false);
            FirstCameraPoint.SetActive(false);
            Camera.SetActive(false);

            return;
        }
	}
	
}
