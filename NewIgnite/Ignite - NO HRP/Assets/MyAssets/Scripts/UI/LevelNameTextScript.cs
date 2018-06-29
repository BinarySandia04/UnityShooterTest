using TMPro;
using UnityEngine;

public class LevelNameTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject settings = GameObject.Find("Settings/MapPropieties");
        if(settings == null)
        {
            Debug.LogWarning("No hay un Settings/MapPropieties definido!");
        }
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.text = settings.GetComponent<LevelSettings>().propiedades.mapName;
	}
	
}
