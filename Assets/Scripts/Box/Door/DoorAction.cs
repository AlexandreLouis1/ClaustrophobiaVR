using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class DoorAction : MonoBehaviour
{
    [SerializeField] private GameObject DoorStepper;
    private SliderStepper doorStepper;

    [SerializeField] private float maxDoorRotation;
    [SerializeField] private float doorTurningSpeed;


    private void Awake()
    {
        doorStepper = DoorStepper.GetComponent<SliderStepper>();
    }

    private void Update()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, ApplyLevierPositionToTheDoor(maxDoorRotation)), doorTurningSpeed);
    }

    private float ApplyLevierPositionToTheDoor(float maxDoorPosition)
    {
        float openingPercentage = doorStepper.GetStepperOpeningPercentage();
        float newDoorRotation;
        newDoorRotation = (openingPercentage * maxDoorPosition) / 100;

        return -newDoorRotation;
    }
}
