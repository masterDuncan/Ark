using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeAttackControl : MonoBehaviour {
    private const float COST = 20f;

    private int _droneKillAmount;
    private EnergyControl _energyControl;

    public GameObject bulletPrefab;
    public Text droneKillsText;

    void Start() {
        _droneKillAmount = 0;
        PlayerPrefs.SetInt("DroneKills", _droneKillAmount);
        _energyControl = GetComponent<EnergyControl>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!_energyControl.DeductEnergy(COST))
            {
                return;
            }
            GameObject bullet = GameObject.Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), transform.rotation) as GameObject;
            GameObject.Destroy(bullet, 0.25f);
        }
    }

    public void DroneKilled()
    {
        _droneKillAmount++;
        droneKillsText.text = _droneKillAmount.ToString();
        PlayerPrefs.SetInt("DroneKills", _droneKillAmount);
    }
}
