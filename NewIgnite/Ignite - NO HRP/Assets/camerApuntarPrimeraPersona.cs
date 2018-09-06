using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerApuntarPrimeraPersona : MonoBehaviour {
    
    private float initialX = -0.2f;
    private int initialFov = 80;

    private float finalX = 0;
    private int finalFov = 50;

    private float currentX;
    private int currentFov;

    public GameObject scope;
    public GameObject cameraWithFirst;

    void Start()
    {
        currentX = initialX;
        currentFov = initialFov;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if(currentX < finalX)
            {
                currentX += 0.01f;
                scope.SetActive(false);
            } else
            {
                if(cameraWithFirst.GetComponent<CameraFollowerPlayer>().firstPerson) scope.SetActive(true);
            }
            if(currentFov > finalFov)
            {
                currentFov--;
            }
        } else
        {
            scope.SetActive(false);
            if (currentX > initialX)
            {
                currentX -= 0.01f;
            }
            if(currentFov < initialFov)
            {
                currentFov++;
            }
        }

        transform.localPosition = new Vector3(currentX, transform.localPosition.y, transform.localPosition.z);
        GetComponent<Camera>().fieldOfView = currentFov;
    }

}
