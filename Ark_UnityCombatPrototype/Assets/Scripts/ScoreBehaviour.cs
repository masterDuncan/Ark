using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour {
    public Text droneKillsText;

    void Start () {
        int droneKills = PlayerPrefs.GetInt("DroneKills");
        droneKillsText.text = "YOU KILLED  " + droneKills.ToString() + "  DRONES";
    }
	
	void Update () {
	}
}
