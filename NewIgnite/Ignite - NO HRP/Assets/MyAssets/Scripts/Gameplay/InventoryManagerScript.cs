using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerScript : MonoBehaviour {

	[SerializeField]
    private GameObject Slot1;
    private GameObject Slot1Icon;
    private GameObject Slot1Number;

    [SerializeField]
    private GameObject Slot2;
    private GameObject Slot2Icon;
    private GameObject Slot2Number;

    [SerializeField]
    private GameObject Slot3;
    private GameObject Slot3Icon;
    private GameObject Slot3Number;

    [SerializeField]
    private GameObject Slot4;
    private GameObject Slot4Icon;
    private GameObject Slot4Number;

    [SerializeField]
    private GameObject Slot5;
    private GameObject Slot5Icon;
    private GameObject Slot5Number;

    void Start()
    {
        RegisterObjects();

        Debug.Log("Registrados!");
    }

    private void RegisterObjects()
    {
        Image Slot1Icon = Slot1.transform.Find("Icon").GetComponent<Image>();
        TextMeshProUGUI Slot1Number = Slot1.transform.Find("Number").GetComponent<TextMeshProUGUI>();

        Image Slot2Icon = Slot2.transform.Find("Icon").GetComponent<Image>();
        TextMeshProUGUI Slot2Number = Slot2.transform.Find("Number").GetComponent<TextMeshProUGUI>();

        Image Slot3Icon = Slot3.transform.Find("Icon").GetComponent<Image>();
        TextMeshProUGUI Slot3Number = Slot3.transform.Find("Number").GetComponent<TextMeshProUGUI>();

        Image Slot4Icon = Slot3.transform.Find("Icon").GetComponent<Image>();
        TextMeshProUGUI Slot4Number = Slot3.transform.Find("Number").GetComponent<TextMeshProUGUI>();

        Image Slot5Icon = Slot3.transform.Find("Icon").GetComponent<Image>();
        TextMeshProUGUI Slot5Number = Slot3.transform.Find("Number").GetComponent<TextMeshProUGUI>();
    }

}
