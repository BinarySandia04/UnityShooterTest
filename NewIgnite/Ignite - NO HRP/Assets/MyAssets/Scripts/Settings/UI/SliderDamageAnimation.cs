using UnityEngine;
using UnityEngine.UI;

public class SliderDamageAnimation : MonoBehaviour {

    public GameObject maloAtached;

    private float updatedHealth = 100f;
    private float current = 100f;

    void Update()
    {
        if(maloAtached.GetComponent<PlayerIA>() != null)
        {
            updatedHealth = maloAtached.GetComponent<PlayerIA>().health;
            if (current > updatedHealth)
            {
                current -= 0.5f;
            }
            GetComponent<Slider>().value = current;
        }
        
    }

}
