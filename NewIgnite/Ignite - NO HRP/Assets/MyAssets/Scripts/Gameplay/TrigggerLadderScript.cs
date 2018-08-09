using UnityEngine;

public class TrigggerLadderScript : MonoBehaviour {

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<InternalPlayerController>())
        {
            player.GetComponent<InternalPlayerController>().ladear(other);
        }
    }

}
