using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] GameObject box;
    BoxControllers boxControllers;

    private void Awake()
    {
        boxControllers = box.GetComponent<BoxControllers>();
    }

    private void Update()
    {
        AdaptSceneLightningToDoorOpening();
    }

    void AdaptSceneLightningToDoorOpening()
    {
        float doorOpeningPercentage = boxControllers.GetDoorStepperOpeningPercentage();

        if (doorOpeningPercentage > 90)
        {
            RenderSettings.ambientIntensity = ((doorOpeningPercentage / 100) - 1) * -1;
        }
        else
        {
            RenderSettings.ambientIntensity = 1;
        }
    }
}
