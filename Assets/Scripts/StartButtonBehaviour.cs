using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonBehaviour : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
