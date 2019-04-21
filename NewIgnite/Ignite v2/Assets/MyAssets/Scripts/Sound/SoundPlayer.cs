using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	public void playSound(string sound)
    {
        try
        {
            GameObject sn = transform.Find("Sounds").Find(sound).gameObject;
            if(sn.GetComponent<AudioSource>() != null)
            {
                sn.GetComponent<AudioSource>().Play();
            }
        } catch
        {
            Debug.LogWarning(sound + " no existe!");
        }
    }
}
