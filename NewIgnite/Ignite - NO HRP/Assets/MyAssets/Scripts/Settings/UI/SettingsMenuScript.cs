using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour {

    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @" + resolutions[i].refreshRate + "hz";
            options.Add(option);

            // TODO: Mas de una resolucion repetida wtf?

            if(resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality (int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }

    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen, res.refreshRate);
    }

    public void resetAllToDefaultSettings()
    {
        PlayerPrefs.SetString("Account/Username", "");
        PlayerPrefs.SetString("Account/Password", "");
        PlayerPrefs.SetInt("Account/AutoLogIn", 0);
        PlayerPrefs.SetInt("TutorialDone", 0);

        PlayerPrefs.Save();

        Debug.Log("Reseted!");
    }

}
