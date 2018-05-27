using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed;
    public float damage;
    public float waitTime;

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerIA>() != null)
        {
            collision.gameObject.GetComponent<PlayerIA>().Damage(damage);
            if (collision.gameObject.GetComponent<Shaker>() != null)
            {
                collision.gameObject.GetComponent<Shaker>().StartShake(0.3f, 0.2f, 0f, 0.2f);
                collision.gameObject.GetComponent<Shaker>().FadeBetween(Color.white, Color.red, 0.3f);
                Debug.Log("Shaked!");
            } else
            {
                Debug.LogWarning("No hay Shake en " + collision.gameObject.name);
            }
        }
        Debug.Log("Ola");
        Destroy(this.gameObject);
    }
}
