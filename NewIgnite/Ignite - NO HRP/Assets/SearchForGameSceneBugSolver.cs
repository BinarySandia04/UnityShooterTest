using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForGameSceneBugSolver : MonoBehaviour {

    private GameObject nm; 
    private GameObject lm;

    private void Start()
    {
        nm = GameObject.Find("_NerworkManager");
        if(nm == null)
        {
            Debug.Log("Mejor busca en internet...");
        }
        lm = GameObject.Find("LoadManager");
        nm.GetComponent<CustomNetworkManager>().load = lm.GetComponent<LoadScript>();
    }

}
