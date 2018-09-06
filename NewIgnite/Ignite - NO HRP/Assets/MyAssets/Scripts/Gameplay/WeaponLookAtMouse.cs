using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WeaponLookAtMouse : NetworkBehaviour {


    public GameObject hitObject;


    public GameObject Player;

    public Camera playerCam;

    // TODO: Poner apartado de propiedades de arma y poner mas armas!

    

	// Update is called once per frame
	void Update () {
        if (!Player.GetComponent<InternalPlayerController>().transform.parent.GetComponent<PlayerController>().isLocalPlayer)
        {
            return;
        }

        if (playerCam.gameObject.GetComponent<CameraFollowerPlayer>().firstPerson)
        {
            // Inserte aqui control de camara
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y") * -1;
            Player.transform.Rotate(0, h, 0);
            transform.Rotate(v, 0, 0);
            return;
        }

        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == Player)
            {
                return; // FUCK IT
            }
            Vector3 position;
            if (hit.transform.gameObject.GetComponent<InternalPlayerController>() != null || hit.transform.gameObject.GetComponent<PlayerIA>() != null)
            {
                position = hit.point;//this is relative to 0,0,0
            } else
            {
                position = hit.point + (Vector3.up / 2);//this is relative to 0,0,0
            }
            //one of coordiantes being always zero for aligned plane
            
            if(hit.transform.gameObject != null)
            {
                hitObject = hit.transform.gameObject;
                if (hit.transform.gameObject.GetComponent<PlayerIA>() != null)
                {
                    hit.transform.gameObject.GetComponent<PlayerIA>().maloCanvas.SetActive(true);
                }
            } else
            {
                hitObject = null;
            }

            transform.LookAt(position);
        }
        
    }


}
