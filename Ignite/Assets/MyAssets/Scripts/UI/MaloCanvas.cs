using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]

public class MaloCanvas : MonoBehaviour {

    public bool malo;
    [Space]
    public string playerName;
    public Color playerNameColor;
    public Color playerColor;
    [Space]
    public Slider barraDeVida;
    public GameObject sliderFill;
    public GameObject Malo;
    [Space]
    public TextMeshProUGUI nameText;
    [Space]
    [SerializeField]
    private float fadeAwayTime;

    private float elapsed = 0f;
    private float time = 0f;
    private bool coroutined = false;

    private Vector3 offset = new Vector3(0.0f, 3f, 0.0f);

    void Start()
    {
        
        if (malo)
        {
            nameText.text = "Malo";
            nameText.color = Color.red;
            if(sliderFill.GetComponent<Image>() != null)
            {
                sliderFill.GetComponent<Image>().color = playerColor;
            } else
            {
                Debug.LogWarning("Slider Fill debe ser una imagen!");
            }
        } else
        {
            nameText.text = playerName;
            nameText.color = playerNameColor;
            if (sliderFill.GetComponent<Image>() != null)
            {
                sliderFill.GetComponent<Image>().color = playerColor;
            }
            else
            {
                Debug.LogWarning("Slider Fill debe ser una imagen!");
            }
        }
    }

    void Update()
    {
        if(transform.parent != null)
        {
            transform.parent.gameObject.GetComponent<PlayerIA>().maloCanvas = gameObject;
            transform.parent = null;
        }
        transform.position = Malo.transform.position + offset;

        barraDeVida.value = Malo.GetComponent<PlayerIA>().health / Malo.GetComponent<PlayerIA>().getMaxHealth();
        if(Malo.GetComponent<PlayerIA>().health <= 0)
        {
            if(elapsed != 0f)
            {
                elapsed -= 0.05f;
                GetComponent<CanvasGroup>().alpha = elapsed;
            }
        }

        WeaponLookAtMouse pointer;

        if(GameObject.Find("/Player/Weapon").GetComponent<WeaponLookAtMouse>() == null)
        {
            Debug.LogWarning("El objeto " + Malo.name + " no tiene asignado el puntero del arma del jugador!");
        } else
        {
            pointer = GameObject.Find("/Player/Weapon").GetComponent<WeaponLookAtMouse>();

            if (pointer.hitObject == Malo)
            {
                GetComponent<CanvasGroup>().alpha += 0.1f;
            }
            else
            {
                GetComponent<CanvasGroup>().alpha -= 0.1f;
            }
        }

    }
}
