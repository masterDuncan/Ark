using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldControl : MonoBehaviour {
    private const float FORCE_FIELD_DURATION = 3f;
    private const float COST = 50f;

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

        if (Input.GetKey(KeyCode.LeftControl))
        {
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
