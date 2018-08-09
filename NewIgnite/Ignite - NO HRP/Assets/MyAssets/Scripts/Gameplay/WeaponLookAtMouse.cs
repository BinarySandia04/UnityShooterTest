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
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == Player)
            {
                return; // FUCK IT
            }
            Vector3 position;
            if (hit.transform.gameObject.GetComponent<PlayerController>() != null || hit.transform.gameObject.GetComponent<PlayerIA>() != null)
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
