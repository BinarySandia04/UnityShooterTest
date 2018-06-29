using UnityEngine;

public class DownMenuHideAndShow : MonoBehaviour {

    private bool bajando = false;
    private bool subiendo = false;

    private float upY;
    public float downY;

    void Start()
    {
        upY = transform.position.y;
    }

    void Update()
    {
        if(bajando && subiendo)
        {
            bajando = false;
            subiendo = false;
            return;
        }
        if (bajando)
        {
            // Bajar
            if(transform.position.y > downY)
            {
                Vector3 pos = transform.position;
                pos.y = pos.y - 1f;
                transform.position = pos;
            } else
            {
                bajando = false;
            }
        }
        if (subiendo)
        {
            // Subir
            if (transform.position.y < upY)
            {
                Vector3 pos = transform.position;
                pos.y = pos.y + 1f;
                transform.position = pos;
            }
            else
            {
                subiendo = false;
            }
        }
    }

    public void subir()
    {
        if(!bajando && !subiendo)
        {
            subiendo = true;
        }
    }

    public void bajar()
    {
        if (!bajando && !subiendo)
        {
            bajando = true;
        }
    }
}
