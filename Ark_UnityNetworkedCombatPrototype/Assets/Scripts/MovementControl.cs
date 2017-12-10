using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
using UnityEngine.Networking;
using UnityEngine;

public class MovementControl : NetworkBehaviour {
=======
using UnityEngine;

public class MovementControl : MonoBehaviour {
>>>>>>> Stashed changes
    private const float PLAYER_SPEED = 4f;
    private const float MAX_VALUE = 50f;
    private const float MIN_VALUE = -50f;

    private Vector3 _camOffset;

    public Camera cam;
    public Camera miniMapCam;

    void Start () {
        _camOffset = cam.transform.position - transform.position;
	}
	
	void Update () {
<<<<<<< Updated upstream
		if (!isLocalPlayer)
			return;
=======
>>>>>>> Stashed changes
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        Vector3 playerPosition = transform.position;

        if (Input.GetKey("w"))
        {
            if (playerPosition.z < MAX_VALUE)
            {
                playerPosition.z += PLAYER_SPEED * Time.deltaTime;
            }
        }
        if (Input.GetKey("s"))
        {
            if (playerPosition.z > MIN_VALUE)
            {
                playerPosition.z -= PLAYER_SPEED * Time.deltaTime;
            }
        }
        if (Input.GetKey("a"))
        {
            if (playerPosition.x > MIN_VALUE)
            {
                playerPosition.x -= PLAYER_SPEED * Time.deltaTime;
            }
        }
        if (Input.GetKey("d"))
        {
            if (playerPosition.x < MAX_VALUE)
            {
                playerPosition.x += PLAYER_SPEED * Time.deltaTime;
            }
        }

        transform.position = playerPosition;
        cam.transform.position = transform.position + _camOffset;
        miniMapCam.transform.position = new Vector3(transform.position.x, miniMapCam.transform.position.y, transform.position.z);
    }

    private void UpdateRotation()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            Quaternion calculatedRotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            transform.rotation = new Quaternion(0f, calculatedRotation.y, 0f, calculatedRotation.w);
        }
    }
}
