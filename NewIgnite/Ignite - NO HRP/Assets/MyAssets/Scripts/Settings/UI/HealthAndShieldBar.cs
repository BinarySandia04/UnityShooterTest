using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndShieldBar : MonoBehaviour {

    public TextMeshProUGUI Number;
    public float originalNumberX = 225f;
    [Space]
    public GameObject HealthSlider;
    public GameObject ShieldSlider;
    [Space]
    public PlayerPropieties Player;

    private float healthSliderOffset;

    // Update is called once per frame
    void FixedUpdate()
    {
        healthSliderOffset = HealthSlider.GetComponent<RectTransform>().position.x;

        RectTransform numberTransform = Number.gameObject.GetComponent<RectTransform>();
        Vector3 numberDesiredPosition = numberTransform.position;

        float shield = Player.shield;
        float health = Player.health;

        GameObject background = HealthSlider.transform.Find("Background").gameObject;
        if(background == null)
        {
            Debug.LogWarning("NO HAY BACKGROUND DENTRO DE " + HealthSlider.name + "!");
            return;
        }

        if (shield + health > 100f)
        {
            numberDesiredPosition.x = ((shield + health)) + healthSliderOffset + 60;
            background.SetActive(false);
        }
        else
        {
            numberDesiredPosition.x = 160 + healthSliderOffset;
            background.SetActive(true);
        }

        numberTransform.position = numberDesiredPosition;

        Number.text = (Player.health + Player.shield) + "";

        RectTransform shieldRect = ShieldSlider.GetComponent<RectTransform>();
        // 65.5 - 165.7
        // 0 - 100
        // 50 - y?
        // y65.5 = 50 * 165.7
        // y = (value * 165.7) / 65.5
        Vector3 shieldDesiredPos = shieldRect.position;
        shieldDesiredPos.x = health + healthSliderOffset;
        shieldRect.position = shieldDesiredPos;

        Slider healthSliderComponent = HealthSlider.GetComponent<Slider>();
        Slider shieldSliderComponent = ShieldSlider.GetComponent<Slider>();

        healthSliderComponent.value = health / 100f;
        shieldSliderComponent.value = shield / 100f;

        
    }
}
