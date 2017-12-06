using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneShotBehaviour : MonoBehaviour {
    private const float DRONE_PROJECTILE_SPEED = 30f;

    void Start () {
	}

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * DRONE_PROJECTILE_SPEED;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IsPlayer")
        {
            if (!other.gameObject.GetComponent<ForceFieldControl>().IsForceFieldActive())
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
            }    
        }

        if (other.tag != "IsDrone")
        {
            Destroy(gameObject);
        }
    }
}
