using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class uidesplegable : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler {

    public float holdingPosX;
    public GameObject rotatingTextYou;
    public float holdingRotation = 0;
    public float speed = 5f;

    private float originalX;

    // originalX < holdingPosX

    private bool coroutinening;

    void Start()
    {
        originalX = GetComponent<RectTransform>().position.x;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        coroutinening = true;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        coroutinening = false;
    }

    void Update()
    {
        if (coroutinening)
        {
            if(GetComponent<RectTransform>().position.x < holdingPosX)
            {

                // Mover pero parriva
                Vector3 vec = GetComponent<RectTransform>().position;
                vec.x = vec.x += speed;
                GetComponent<RectTransform>().position = vec;

            }
            
        } else
        {
            if (GetComponent<RectTransform>().position.x > originalX)
            {

                // Mover pero pabajo
                Vector3 vec = GetComponent<RectTransform>().position;
                vec.x = vec.x -= speed;
                GetComponent<RectTransform>().position = vec;

            }
            
            
        }
    }

}
