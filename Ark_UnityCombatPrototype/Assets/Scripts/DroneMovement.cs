using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMovement : MonoBehaviour {
    private const float MIN_DISTANCE_TO_PLAYER = 5f;

    private GameObject _player;

	void Start () {
        _player = GameObject.FindGameObjectWithTag("IsPlayer");
    }
	
	void Update () {
        UpdateRotation();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (_player.gameObject == null || _player.transform == null)
        {
            return;
        }

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (Vector3.Distance(transform.position, _player.transform.position) > MIN_DISTANCE_TO_PLAYER)
        {
            if (agent.isStopped)
            {
                agent.isStopped = false;
            }
            agent.destination = _player.transform.position;
        }
        else
        {
            agent.isStopped = true;
        }
    }

    private void UpdateRotation()
    {
        if (_player.gameObject == null || _player.transform == null)
        {
            return;
        }
        
        Vector3 targetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y + 1, _player.transform.position.z );
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        Quaternion calculatedRotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        transform.rotation = new Quaternion(0f, calculatedRotation.y, 0f, calculatedRotation.w);
    }
}
