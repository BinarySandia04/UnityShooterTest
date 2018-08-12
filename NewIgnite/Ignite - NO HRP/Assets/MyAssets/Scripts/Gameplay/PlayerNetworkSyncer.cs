using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkSyncer : NetworkBehaviour {

    public HealthAndShieldBar barra;
    public CameraFollowerPlayer follow;

	void Update () {
        if (isLocalPlayer)
        {
            barra.Player = gameObject.GetComponent<PlayerPropieties>();
            follow.target = transform;
        }
	}
}
