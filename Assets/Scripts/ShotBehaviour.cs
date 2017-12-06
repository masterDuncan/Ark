using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShotBehaviour : MonoBehaviour {
    private const float PLAYER_PROJECTILE_SPEED = 50f;
    private const float EXPLOSION_TTL = 1f;

    public GameObject explosionPrefab;

    void Start () {
    }
	
	void Update () {
		transform.position += transform.forward * Time.deltaTime * PLAYER_PROJECTILE_SPEED;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IsDrone")
        {
            Destroy(other.gameObject);
            GameObject.FindObjectOfType<RangeAttackControl>().DroneKilled();
            GameObject explosion = GameObject.Instantiate(explosionPrefab, gameObject.transform.position, transform.rotation) as GameObject;
            GameObject.Destroy(explosion, EXPLOSION_TTL);
        }

        if (other.tag != "IsPlayer")
        {
            Destroy(gameObject);
        }
    }
}
