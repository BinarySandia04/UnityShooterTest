using UnityEngine;

[CreateAssetMenu(fileName = "WeaponPreset", menuName = "Aran's Objects/Propiedades de arma")]
public class WeaponPropieties : ScriptableObject {

    public string weaponName;
    [Space]
    public int magazine;
    public int bulletsPerShot;
    [Space]
    public int reloadTime;
    public int fireSpeed;
    [Space]
    public int damage;
    [Space]
    public bool hasScopeWIP;

}
