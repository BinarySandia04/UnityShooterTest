using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour {

    private float ColorFadetime;

    private Color Color1;
    private Color Color2;

    private bool fading;

    public float time;

	public IEnumerator Shake(float duration, float magnitudeX, float magnitudeY, float magnitudeZ)
    {
        Debug.Log("Shaking!");

        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        time = 0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitudeX;
            float y = Random.Range(-1f, 1f) * magnitudeY;
            float z = Random.Range(-1f, 1f) * magnitudeZ;

            transform.localPosition = new Vector3(x + transform.localPosition.x, y + transform.localPosition.y, z + transform.localPosition.z);

            elapsed += Time.deltaTime;

            yield return null;

        }

        transform.localPosition = originalPos;
    }

    public void StartShake(float duration, float magnitudeX, float magnitudeY, float magnitudeZ)
    {

            StartCoroutine(Shake(duration, magnitudeX, magnitudeY, magnitudeZ));
       
        
    }

    public void GetDamageAnimation()
    {
        StartShake(0.3f, 0.2f, 0f, 0.2f);
        FadeBetween(Color.red, Color.white, 0.3f);
    }

    public void FadeBetween(Color color1, Color color2, float time)
    {
        time = 0f;

        Color1 = color1;
        Color2 = color2;
        ColorFadetime = time;

        fading = true;
        time = 0f;
    }

    void Update()
    {
        if (fading)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(Color1, Color2, time));
            time += Time.deltaTime;
        }
    }

    IEnumerator WaitEndColorLerp()
    {
        yield return new WaitForSeconds(ColorFadetime);
        fading = false;
        
    }
}
