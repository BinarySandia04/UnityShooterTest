using UnityEngine;

public class PlayerIA : MonoBehaviour {

    public float health;
    public GameObject muerte;

    public GameObject maloCanvas;

    public Transform donde;

    private float maxHealth;

    public float getMaxHealth()
    {
        return maxHealth;
    }

    private void Start()
    {
        donde = transform;
        maxHealth = health;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if(health < 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        donde.position = transform.position;
        GameObject death = Instantiate(muerte, donde, true);

        death.transform.parent = null;
        death.transform.position = transform.position;

        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);

        foreach(Collider objetoCercano in colliders)
        {
            Rigidbody rb = objetoCercano.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(200f, death.transform.position, 20f);
            }
        }

        Debug.Log("Muerto!");

        gameObject.SetActive(false);
    }

}
