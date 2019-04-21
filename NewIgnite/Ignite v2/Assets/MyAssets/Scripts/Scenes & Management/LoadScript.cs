using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour {

    public GameObject loadScreen;
    public CustomNetworkManager cnm;
    public GameObject slider;

    public void closeApp()
    {
        Application.Quit();
    }

    public void LoadLevel(string name)
    {
        if (name == null) slider.SetActive(false);
        else if(slider != null) slider.SetActive(true);
        loadScreen.gameObject.SetActive(true);

        StartCoroutine(LoadAsyncronously(name));
    }

    private void Start()
    {
        if(cnm != null) cnm.load = this;
        loadScreen.gameObject.SetActive(false);
    }

    IEnumerator LoadAsyncronously (string name)
    {
        Scene origin = SceneManager.GetActiveScene();

        Color c = new Color(0.8f, 0.8f, 0.8f, 0);
        for(float a = 0; a < 1; a+=0.01f)
        {
            c.a = a;
            loadScreen.GetComponent<Image>().color = c;

            yield return new WaitForSeconds(0.005f);
        }

        if (name != null)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(name);
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                loadScreen.transform.Find("Slider").gameObject.GetComponent<Slider>().value = progress;

                yield return null;
            }
        } else
        {
            while(SceneManager.GetActiveScene() == origin)
            {
                yield return new WaitForEndOfFrame();
            }

            c = new Color(0.8f, 0.8f, 0.8f, 1);
            for (float a = 1; a > 0; a -= 0.01f)
            {
                c.a = a;
                loadScreen.GetComponent<Image>().color = c;

                yield return new WaitForSeconds(0.005f);
            }
        }

        

        loadScreen.gameObject.SetActive(false);

        yield return null;
        
    }

}
