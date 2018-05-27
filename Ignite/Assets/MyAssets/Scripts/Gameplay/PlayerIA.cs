using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIA : MonoBehaviour {

    public float health;
    public GameObject muerte;

    public Transform donde;

    private void Start()
    {
        donde = transform;
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
