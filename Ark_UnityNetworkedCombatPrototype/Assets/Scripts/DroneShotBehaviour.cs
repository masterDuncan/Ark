using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneShotBehaviour : MonoBehaviour {
    public GameObject playerShieldHitPrefab;
    public GameObject playerHitPrefab;
    private const float EXPLOSION_TTL = 1f;
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
                //Destroy(other.gameObject);
                // SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
                GameObject hit = GameObject.Instantiate(playerHitPrefab, gameObject.transform.position, transform.rotation) as GameObject;
                GameObject.Destroy(hit, EXPLOSION_TTL);
            } else {
                GameObject hit = GameObject.Instantiate(playerShieldHitPrefab, gameObject.transform.position, transform.rotation) as GameObject;
                GameObject.Destroy(hit, EXPLOSION_TTL);
            }
        }

        if (other.tag != "IsDrone")
        {
            Destroy(gameObject);
        }
    }
}
