using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsManager : MonoBehaviour {
    
    [SerializeField] private GameObject[] enableOnPerformance;
    [Space]
    [SerializeField] private GameObject[] enableOnMedium;
    [Space]
    [SerializeField] private GameObject[] enableOnQuality;

    void Start()
    {
        foreach (GameObject g in enableOnPerformance)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in enableOnMedium)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in enableOnQuality)
        {
            g.SetActive(false);
        }
        Debug.Log("Todo desactivado. Cargando configuracion grafica...");
        StartCoroutine(EnableAndDisableGameObjects());
    }

    IEnumerator EnableAndDisableGameObjects()
    {
        if (QualitySettings.GetQualityLevel() == 0)
        {
            // PERFORMANCE
            Debug.Log("Nivel de calidad grafica: 1");

            // ENABLE
            foreach (GameObject g in enableOnPerformance)
            {
                g.SetActive(true);
            }
        }
        if (QualitySettings.GetQualityLevel() == 1)
        {
            // MEDIUM
            Debug.Log("Nivel de calidad grafica: 2");

            // ENABLE
            foreach (GameObject g in enableOnMedium)
            {
                g.SetActive(true);
            }
        }
        if (QualitySettings.GetQualityLevel() == 2)
        {
            // QUALITY
            Debug.Log("Nivel de calidad grafica: 3");

            // ENABLE
            foreach (GameObject g in enableOnQuality)
            {
                g.SetActive(true);
            }
        }

        Debug.Log("Cargado!");
        yield return null;
    }
}
