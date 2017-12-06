using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyControl : MonoBehaviour {
    private const float MAX_ENERGY = 100f;
    private const float ENERGY_INCREASE_DELAY = 0.05f;

    private float _passedTime = 0f;
    private float _currentEnergy;

    public Slider eneryBar;

    void Start () {
        _currentEnergy = MAX_ENERGY;
        eneryBar.value = _currentEnergy;
    }
	
	void Update () {
        _passedTime += Time.deltaTime;
        if (_passedTime > ENERGY_INCREASE_DELAY)
        {
            _passedTime -= ENERGY_INCREASE_DELAY;
            if (_currentEnergy < MAX_ENERGY)
            {
                _currentEnergy++;
                eneryBar.value = _currentEnergy;
            }
        }
    }

    public bool DeductEnergy(float amount)
    {
        if (amount > _currentEnergy)
        {
            return false;
        }

        _currentEnergy -= amount;
        eneryBar.value = _currentEnergy;
        return true;
    }
}
