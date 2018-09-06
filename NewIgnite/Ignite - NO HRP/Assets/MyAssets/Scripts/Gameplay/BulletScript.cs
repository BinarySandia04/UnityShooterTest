using UnityEngine;

public class BulletScript : MonoBehaviour {

    // Nota importante: este script solo se ejecuta en el servidor.

    public float speed;
    public int damage;
    public float waitTime;

    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "IgnoreCollision")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
            return;
        }
        if(collision.gameObject.GetComponent<InternalPlayerController>() != null)
        {
            collision.transform.parent.GetComponent<PlayerController>().GetDamage(damage);
        }
        if (collision.gameObject.GetComponent<PlayerIA>() != null)
        {
            collision.gameObject.GetComponent<PlayerIA>().Damage(damage);
            if (collision.gameObject.GetComponent<Shaker>() != null)
            {
                GameObject.Find("Canvas/ScoreTest").GetComponent<Scoretest>().addScore(50);
                collision.transform.parent.GetComponent<PlayerController>().GetDamage(0);

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
