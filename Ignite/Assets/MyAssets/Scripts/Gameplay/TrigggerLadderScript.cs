using UnityEngine;

public class TrigggerLadderScript : MonoBehaviour {

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<PlayerController>())
        {
            player.GetComponent<PlayerController>().ladear(other);
        }
    }

}
