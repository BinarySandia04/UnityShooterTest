using System.Collections;
using UnityEngine;

public class CameraFollowerPlayer : MonoBehaviour {

    public Transform target;
    public Transform weapon;
    public Transform startTarget;
    public GameObject firstCamera;

    public float smoothSpeed = 0.125f;
    public float smoothStartSpeed = 0.00125f;
    public Vector3 offset;
    public bool look = false;
    public float timeUntilStart = 5f;

    private Vector3 inPos;
    public bool start = true;

    [Space]

    public bool firstPerson = false;

    private Quaternion lastSavedRotation;

    private void Start()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        inPos = smoothedPosition;
        transform.position = startTarget.position;

        StartCoroutine(wait(timeUntilStart));

    }


    void LateUpdate()
    {
        

        if (!start)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (firstPerson)
                {
                    gameObject.GetComponent<Camera>().depth = 0f;
                    firstPerson = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                } else
                {
                    firstPerson = true;
                    weapon.parent.rotation = weapon.localRotation;
                    weapon.rotation = new Quaternion();
                    Vector3 fix = weapon.parent.rotation.eulerAngles;
                    fix.x = 0;
                    weapon.parent.rotation = Quaternion.Euler(fix);
                    gameObject.GetComponent<Camera>().depth = -999f;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                
            }

            Vector3 desiredPosition = target.position + offset;
            if (Input.GetKey(KeyCode.Mouse1))
            {
                float mx = ((Input.mousePosition.x - Screen.currentResolution.width / 2) * 2) / Screen.currentResolution.width;
                float my = ((Input.mousePosition.y - Screen.currentResolution.height / 2) * 2) / Screen.currentResolution.height;
                InternalPlayerController pc = target.GetComponent<InternalPlayerController>();
                if(pc == null)
                {
                    Debug.LogWarning("No hay InternalPlayerController en target!");
                    return;
                }
                float multi = pc.camDistanceMultiplier;
                desiredPosition = desiredPosition + new Vector3(mx * multi, 3, my * multi);
            }
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            if (look)
            {
                transform.LookAt(target);
            }
        } else
        {
            
            // Starting     
            Vector3 smoothedPosiotion = Vector3.Lerp(transform.position, target.position + offset, smoothStartSpeed);
            transform.position = smoothedPosiotion;
        }
        
        
    }

    IEnumerator wait(float seconds)
    {
        start = true;
        yield return new WaitForSeconds(seconds);
        start = false;
    }

}
