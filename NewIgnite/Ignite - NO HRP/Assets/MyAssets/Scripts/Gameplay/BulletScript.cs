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
        if (collision.gameObject.tag == "IgnoreCollision")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
            return;
        }
        if (collision.gameObject.GetComponent<PlayerIA>() != null)
        {
            collision.gameObject.GetComponent<PlayerIA>().Damage(damage);
            if (collision.gameObject.GetComponent<Shaker>() != null)
            {
                GameObject.Find("Canvas/ScoreTest").GetComponent<Scoretest>().addScore(50);
                collision.gameObject.GetComponent<Shaker>().StartShake(0.3f, 0.2f, 0f, 0.2f);
                collision.gameObject.GetComponent<Shaker>().FadeBetween(Color.white, collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color"), 0.3f);

                // Sound play
                if(collision.gameObject.GetComponent<PlayerIA>().health <= 0)
                {
                    GameObject.Find("Camera").GetComponent<SoundPlayer>().playSound("Dead");
                    GameObject.Find("Canvas/ScoreTest").GetComponent<Scoretest>().addScore(300);
                } else
                {
                    GameObject.Find("Camera").GetComponent<SoundPlayer>().playSound("Hitmarker");
                }

            } else
            {
                Debug.LogWarning("No hay Shake en " + collision.gameObject.name);
            }
            
        }
        Destroy(this.gameObject);

    }
}
