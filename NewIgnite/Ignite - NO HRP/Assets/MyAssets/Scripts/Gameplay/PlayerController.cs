using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public InternalPlayerController internalPlayer;

    public GameObject bullet;
    public Vector3 bulletOffset;
    public GameObject weapon;

    private int cargador;

    void Start()
    {
        cargador = internalPlayer.cargador;
    }

    public void RequestCmdFire()
    {
        CmdFire();
    }

    [Command]
    public void CmdFire()
    {
        Quaternion q = weapon.transform.rotation;
        var bulleti = Instantiate(bullet, weapon.transform.position, q);
        bulleti.SetActive(true);
        Transform t = bulleti.transform;
        t.Translate(bulletOffset);

        NetworkServer.Spawn(bulleti);

        // Destroy the bullet after 2 seconds
        Destroy(bulleti, 2.0f);
    }

    [ClientRpc]
    public void RpcGetDamage(int damage)
    {
        // Hacer daño SyncVar bla bla bla...
        Debug.Log("jj");
        internalPlayer.GetComponent<Shaker>().GetDamageAnimation();
    }

    void Update()
    {
        cargador = internalPlayer.cargador;
        internalPlayer.isLocal = isLocalPlayer;
    }

}
