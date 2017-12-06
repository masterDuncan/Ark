using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour {
    private const float DRONE_SPAWN_DELAY = 1f;
    private const int DRONE_SPAWN_AMOUNT = 1;

    private float _passedTime = 0f;

    public GameObject dronePrefab;

    void Start () {
	}
	
	void Update () {
        _passedTime += Time.deltaTime;
        if (_passedTime > DRONE_SPAWN_DELAY)
        {
            _passedTime -= DRONE_SPAWN_DELAY;
            Spawn();
        }
    }

    private void Spawn()
    {
        for (int i= 0; i<DRONE_SPAWN_AMOUNT; i++)
        {
            GameObject drone = GameObject.Instantiate(dronePrefab, GetRandomPosition(), Quaternion.identity) as GameObject;
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPosition, out hit, 10, 1);
        return hit.position;
    }
}
