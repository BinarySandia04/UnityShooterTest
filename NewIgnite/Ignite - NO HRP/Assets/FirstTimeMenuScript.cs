using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstTimeMenuScript : MonoBehaviour {

    public GameObject loadManager;

    private void Start()
    {
        // Aparece el menu si tutorialDone esta en 0. (o sin asignar)
        if (PlayerPrefs.GetInt("TutorialDone") != 1)
        {
            gameObject.SetActive(true);
        } else
        {
            gameObject.SetActive(false);
        }
    }
    public void yes()
    {
        PlayerPrefs.SetInt("TutorialDone", 1);
        PlayerPrefs.Save();

        loadManager.GetComponent<LoadScript>().LoadLevel("Tutorial");
        // Cargar tutorial
    }
    public void no()
    {
        PlayerPrefs.SetInt("TutorialDone", 1);
        PlayerPrefs.Save();

        this.gameObject.SetActive(false);
        // Poner algo de desvanecimiento
    }
}
