using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRangedAttack : MonoBehaviour {
    private const float SHOT_DELAY = 2.2f;
    private const float SHOT_TTL = 0.35f;
    private const float EXPLOSION_TTL = 1f;

    public GameObject droneShootingPrefab;
    private float _passedTime = -SHOT_DELAY;

    public GameObject shotPrefab;

    void Start () {
	}
	
	void Update () {
        _passedTime += Time.deltaTime;
        if (_passedTime > SHOT_DELAY)
        {
            _passedTime -= SHOT_DELAY;
            Shoot();
        }
	}

    private void Shoot()
    {
        GameObject shooting = GameObject.Instantiate(droneShootingPrefab, new Vector3(transform.position.x + 0.2f, transform.position.y + 1.0f, transform.position.z), transform.rotation) as GameObject;
        GameObject.Destroy(shooting, EXPLOSION_TTL);
        GameObject bullet = GameObject.Instantiate(shotPrefab, new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z), transform.rotation) as GameObject;
        GameObject.Destroy(bullet, SHOT_TTL);
    }
}
