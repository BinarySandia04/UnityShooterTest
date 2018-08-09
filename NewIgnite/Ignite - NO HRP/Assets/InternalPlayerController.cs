using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InternalPlayerController : NetworkBehaviour
{
    public TextMeshProUGUI ammoText;

    public GameObject bullet;

    public Slider reloadingBar;
    public float multiplier = 1f;

    public float smoothSpeed = 0.125f;
    public float airControl = 0.5f;

    public float jumpMultiplier = 3f;
    public float camDistanceMultiplier = 3f;

    public bool isLocal = true;

    private bool onGround = false;

    public bool dontLad = false; // TODO: Haz colisionadores independientes para asi hacer funcionar bien el sistema de ladders

    private bool grounded = false; // TODO: Este solo detecta si esta en el suelo para desactivar aircontrol. onGround solo es para saltar

    public int cargador = 20;

    private bool reshot = true;
    public bool reloading = false;

    public GameObject camara;

    void Start()
    {
        ammoText.text = cargador + " / " + gameObject.GetComponent<PlayerPropieties>().totalAmmo;

        GameObject[] myObjects;
        myObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in myObjects)
        {
            if (obj.GetComponent<IgnoreCollisionScript>() != null)
            {
                Physics.IgnoreCollision(obj.GetComponent<Collider>(), GetComponent<Collider>());
            }

        }
    }



    // Update is called once per frame
    void Update()
    {
        if (!isLocal)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Mouse0) && reshot && !reloading)
        {
            StartCoroutine(fire(bullet.GetComponent<BulletScript>().waitTime));
        }

        if (!camara.GetComponent<CameraFollowerPlayer>().start)
        {


            Rigidbody rb = GetComponent<Rigidbody>();


            if (Input.GetKey(KeyCode.W))
            {
                if (grounded == true)
                {
                    rb.velocity = rb.velocity + Vector3.forward * multiplier;
                }
                else
                {
                    rb.velocity = rb.velocity + Vector3.forward * multiplier * airControl;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (grounded == true)
                {
                    rb.velocity = rb.velocity + Vector3.back * multiplier;
                }
                else
                {
                    rb.velocity = rb.velocity + Vector3.back * multiplier * airControl;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (grounded == true)
                {
                    rb.velocity = rb.velocity + Vector3.left * multiplier;
                }
                else
                {
                    rb.velocity = rb.velocity + Vector3.left * multiplier * airControl;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (grounded == true)
                {
                    rb.velocity = rb.velocity + Vector3.right * multiplier;
                }
                else
                {
                    rb.velocity = rb.velocity + Vector3.right * multiplier * airControl;
                }
            }


            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
            {
                dontLad = false;
            }
            else
            {
                dontLad = true;
            }


            if (Input.GetKey(KeyCode.Space) && onGround)
            {
                rb.AddForce(Vector3.up * jumpMultiplier, ForceMode.VelocityChange);

                onGround = false;
                grounded = false;

            }

            // Estas lineas hacen que el cubo no sea un MRUA infinito de Ferran.

            if (rb.velocity.x > multiplier)
            {
                Vector3 vel = rb.velocity;
                vel.x = multiplier;
                rb.velocity = vel;
            }
            if (rb.velocity.z > multiplier)
            {
                Vector3 vel = rb.velocity;
                vel.z = multiplier;
                rb.velocity = vel;
            }
            if (rb.velocity.x < multiplier * -1)
            {
                Vector3 vel = rb.velocity;
                vel.x = multiplier * -1;
                rb.velocity = vel;
            }
            if (rb.velocity.z < multiplier * -1)
            {
                Vector3 vel = rb.velocity;
                vel.z = multiplier * -1;
                rb.velocity = vel;
            }

            // Ya esta lel xdxd

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            onGround = true;
        }

        if (collision.gameObject.tag == "IgnoreCollision")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }

        if (collision.gameObject.GetComponent<LadderScript>() != null)
        {
            ladear(collision.collider);

        }
        if (collision.gameObject.GetComponent<BulletScript>() == null)
        {
            grounded = true;
        }

    }

    public void ladear(Collider collision)
    {
        if (dontLad == false && collision.gameObject.GetComponent<LadderScript>() != null) transform.Translate(Vector3.up * collision.gameObject.GetComponent<LadderScript>().ladderGap);
    }



    IEnumerator fire(float seconds)
    {
        PlayerController pc = transform.parent.GetComponent<PlayerController>();
        
        ammoText.text = cargador + " / " + gameObject.GetComponent<PlayerPropieties>().totalAmmo;

        // Create the Bullet from the Bullet Prefab
        if (cargador == 0)
        {
            StartCoroutine(reload(5));
            yield return null;
        }
        else
        {
            cargador--;
        }

        reshot = false;

        pc.RequestCmdFire();

        yield return new WaitForSeconds(seconds);

        reshot = true;

    }

    IEnumerator reload(float seconds)
    {
        reloading = true;

        for (float i = 0; i < seconds; i += 0.05f)
        {
            yield return new WaitForSeconds(0.05f);
            float progress = Mathf.Clamp01(i / seconds);
            reloadingBar.value = progress;
        }

        cargador = gameObject.GetComponent<PlayerPropieties>().GetNewMagazineOf(20);
        reloading = false;
    }
}
