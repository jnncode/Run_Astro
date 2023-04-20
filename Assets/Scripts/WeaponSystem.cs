using UnityEngine;
using System.Collections;

public class WeaponSystem : MonoBehaviour {
    public GameObject[] weapons; // array of weapon prefabs
    private int currentWeaponIndex; 

    public void Start() {
        currentWeaponIndex = 0;
        SwitchWeapon(currentWeaponIndex);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0); // knife
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1); // pistol
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2); // assault
        }

    }

    public void SwitchWeapon(int weaponIndex) {
        weapons[currentWeaponIndex].SetActive(false); // deactivate current
        weapons[weaponIndex].SetActive(true); // activate new
        currentWeaponIndex = weaponIndex;
    }
}