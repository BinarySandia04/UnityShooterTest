using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuAccountSlider : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler {

    public float holdingPosX;
    public float speed = 5f;
    [Space]
    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI pointsText;
    // WIP public TextMeshProUGUI killsText;
    // WIP public TextMeshProUGUI deathsText;

    private float originalX;

    // originalX < holdingPosX

    private bool coroutinening;
    private bool textSetUps = false;

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

    void SetUpTexts()
    {
        // Ñe
        Debug.Log("Ñe la data me ha llegado y es: " + UserAccountManagement.Data);

        usernameText.text = UserAccountManagement.playerUsername;
        levelText.text = "Level! " + UserAccountDataTranslator.GetTranslatedData(UserAccountManagement.Data, "[LEVEL]");
        pointsText.text = "Points! " + UserAccountDataTranslator.GetTranslatedData(UserAccountManagement.Data, "[POINTS]");
    }

    void Update()
    {
        if (UserAccountManagement.dataIsSetUp && !textSetUps)
        {
            textSetUps = true;
            SetUpTexts();
        }

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
