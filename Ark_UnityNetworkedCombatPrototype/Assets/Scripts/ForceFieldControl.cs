using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldControl : MonoBehaviour {
    private const float FORCE_FIELD_DURATION = 1.5f;
    private const float COST = 10f;
    private const float EXPLOSION_TTL = 1f;
    public GameObject playerActivateForcefieldPrefab;

    private bool _forceFieldActive = false;
    private float _passedTime = 0f;
    private EnergyControl _energyControl;

    public GameObject forceField;

    void Start () {
        _energyControl = GetComponent<EnergyControl>();
        UpdateForceField(false);
    }
	
	void Update () {
        if (_forceFieldActive)
        {
            _passedTime += Time.deltaTime;
            if (_passedTime < FORCE_FIELD_DURATION)
            {
                return;
            }

            UpdateForceField(false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject activating = GameObject.Instantiate(playerActivateForcefieldPrefab, new Vector3(transform.position.x + 0.2f, transform.position.y + 1.6f, transform.position.z), transform.rotation) as GameObject;
            GameObject.Destroy(activating, EXPLOSION_TTL);
            if (!_energyControl.DeductEnergy(COST))
            {
                return;
            }
            _passedTime = 0f;
            UpdateForceField(true);
        }
    }

    private void UpdateForceField(bool enable)
    {
        forceField.SetActive(enable);
        _forceFieldActive = enable;
    }

    public bool IsForceFieldActive()
    {
        return _forceFieldActive;
    }
}
