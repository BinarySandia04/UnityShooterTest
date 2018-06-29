using System.Collections;
using UnityEngine;

public class WeaponLookAtMouse : MonoBehaviour {

    public GameObject bullet;

    public GameObject hitObject;

    public Vector3 bulletOffset;

    private bool reshot = true;

	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
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
        if (Input.GetKey(KeyCode.Mouse0) && reshot)
        {
            StartCoroutine(fire(bullet.GetComponent<BulletScript>().waitTime));
        }
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        Quaternion q = transform.rotation;
        var bulleti = Instantiate(bullet, transform.position, q);
        Transform t = bulleti.transform;
        t.Translate(bulletOffset);
       

        // Destroy the bullet after 2 seconds
        Destroy(bulleti, 2.0f);
        reshot = false;
    }

    IEnumerator fire(float seconds)
    {
        Fire();
        yield return new WaitForSeconds(seconds);
        reshot = true;
    }

}
