using UnityEngine;

public class OrbCenterScript : MonoBehaviour {

	void Start () {
		
	}

    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 0));
    }
}
