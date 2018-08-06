using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour {

    public GameObject loadScreen;

    public void LoadLevel(string name)
    {
        loadScreen.gameObject.SetActive(true);

        StartCoroutine(LoadAsyncronously(name));
    }

    private void Start()
    {
        loadScreen.gameObject.SetActive(false);
    }

    IEnumerator LoadAsyncronously (string name)
    {
        Color c = new Color(0.8f, 0.8f, 0.8f, 0);
        for(float a = 0; a < 1; a+=0.01f)
        {
            c.a = a;
            loadScreen.GetComponent<Image>().color = c;

            yield return new WaitForSeconds(0.005f);
        }
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadScreen.transform.Find("Slider").gameObject.GetComponent<Slider>().value = progress;

            yield return null;
        }
    }

}
