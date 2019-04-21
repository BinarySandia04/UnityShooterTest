using UnityEngine;

public class ExitFromAGame : MonoBehaviour {

	public void ExitGame()
    {
        GameObject NetworkManager = GameObject.Find("_NetworkManager");
        if(NetworkManager != null)
        {
            CustomNetworkManager cnm = NetworkManager.GetComponent<CustomNetworkManager>();
            if(cnm != null)
            {
                cnm.dontDestroyOnLoad = false;
                cnm.StopClient();
                Destroy(NetworkManager);
            } else
            {
                Debug.Log("Se ha encontrado _NetowrkManager, pero wat");
            }
        } else
        {
            Debug.LogWarning("No hay networkManager! No se puede salir! AAAAAAAAAAAh");
        }
    }

}
