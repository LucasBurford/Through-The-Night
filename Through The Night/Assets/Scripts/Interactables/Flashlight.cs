using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light mLight;

    public float energy;
    public float maxEnergy;
    public float energyRate;

    public bool state;
    public bool shouldIncrease;
    public bool shouldDecrease;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!state)
            {
                state = true;
            }
            else if (state)
            {
                state = false;
            }
        }

        if (state)
        {
            shouldDecrease = true;
            shouldIncrease = false;
        }
        else if (!state)
        {
            shouldDecrease = false;
            shouldIncrease = true;
        }

        if (energy <= 0)
        {
            energy = 0;
            state = false;
            shouldIncrease = true;
            shouldDecrease = false;
        }
        else if (energy >= maxEnergy)
        {
            energy = maxEnergy;
            shouldIncrease = false;
            shouldDecrease = true;
        }

        if (shouldIncrease)
        {
            energy += energyRate;
        }
        if (shouldDecrease)
        {
            energy -= energyRate;
        }

        mLight.GetComponent<Light>().enabled = state;
    }
}
