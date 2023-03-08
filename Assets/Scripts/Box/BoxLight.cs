using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLight : MonoBehaviour
{
    [SerializeField] private GameObject BoxContainer;
    private BoxControllers boxControllers;
    private Light boxLight;

    private void Awake()
    {
        boxControllers = BoxContainer.GetComponent<BoxControllers>();
        boxLight = GetComponent<Light>();
    }

    private void Update()
    {
        AdaptBoxLightningToBoxSlidder();
    }

    void AdaptBoxLightningToBoxSlidder()
    {
        float sliderOpeningPercentage = boxControllers.GetLuminosityStepperOpeningPercentage();
        float maxValue = 3f;
        float minValue = 0.5f;
        maxValue = maxValue - minValue;
        boxLight.intensity = (((maxValue * sliderOpeningPercentage) / 100)) + minValue;
    }
}
