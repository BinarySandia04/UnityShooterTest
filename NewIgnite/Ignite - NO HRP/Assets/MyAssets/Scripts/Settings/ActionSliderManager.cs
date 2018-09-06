using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionSliderManager : MonoBehaviour {

    public bool runing = false;

    [SerializeField]
    private Slider bar;

    [SerializeField]
    private TextMeshProUGUI Text;

    [SerializeField]
    private Image barFill;

    private bool Sliding;
    

    public bool doSliderThings(Color sliderColor, Color textColor, string text, float time, float runMultiplierTime, Action beforeAction, Action afterAction, bool firstPriority)
    {
        if (Sliding)
        {
            return false;
        } else
        {
            Sliding = true;
            if (firstPriority)
            {
                StopAllCoroutines();
            }
            StartCoroutine(DoSliderThings(sliderColor, textColor, text, time, runMultiplierTime, beforeAction, afterAction));
            return true;
        }
    }

    private IEnumerator DoSliderThings(Color sliderColor, Color textColor, string text, float time, float runMultiplierTime, Action beforeAction, Action afterAction)
    {
        // BeforeAction
        beforeAction();

        // Activar
        bar.gameObject.SetActive(true);
        Text.gameObject.SetActive(true);

        barFill.color = sliderColor;
        Text.color = textColor;
        Text.text = text;

        // Setear minvalue y maxvalue
        bar.minValue = 0;
        bar.maxValue = time;

        for(float i = 0; i < time; i += 0.02f)
        {
            yield return new WaitForSecondsRealtime(0.02f);
            if (runing)
            {
                yield return new WaitForSecondsRealtime(0.01f * runMultiplierTime);
                i -= 0.01f;
            }
            bar.value = i;
        }

        bar.value = 0;

        // Desactivar
        bar.gameObject.SetActive(false);
        Text.gameObject.SetActive(false);

        // AfterAction
        afterAction();

        // Esto para el final
        Sliding = false;
        yield return null;
    }

}
