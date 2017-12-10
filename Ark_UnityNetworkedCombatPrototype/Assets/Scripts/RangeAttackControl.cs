using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeAttackControl : MonoBehaviour {
<<<<<<< Updated upstream
    private const float COST = 20f;
=======
    private const float COST = 10f;
    private const float EXPLOSION_TTL = 1f;
    public GameObject playerShootingPrefab;
>>>>>>> Stashed changes

    private int _droneKillAmount;
    private EnergyControl _energyControl;

<<<<<<< Updated upstream
    public GameObject playerShotPrefab;
=======
    public GameObject bulletPrefab;
>>>>>>> Stashed changes
    public Text droneKillsText;

    void Start() {
        _droneKillAmount = 0;
        PlayerPrefs.SetInt("DroneKills", _droneKillAmount);
        _energyControl = GetComponent<EnergyControl>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
<<<<<<< Updated upstream
=======
            GameObject shooting = GameObject.Instantiate(playerShootingPrefab, new Vector3(transform.position.x + 0.2f, transform.position.y + 1.6f, transform.position.z), transform.rotation) as GameObject;
            GameObject.Destroy(shooting, EXPLOSION_TTL);
>>>>>>> Stashed changes
            if (!_energyControl.DeductEnergy(COST))
            {
                return;
            }
<<<<<<< Updated upstream
			GameObject bullet = GameObject.Instantiate(playerShotPrefab, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), transform.rotation) as GameObject;
=======
            GameObject bullet = GameObject.Instantiate(bulletPrefab, new Vector3(transform.position.x + 0.2f, transform.position.y+1.6f, transform.position.z), transform.rotation) as GameObject;
>>>>>>> Stashed changes
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
