using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControllers : MonoBehaviour
{
    [SerializeField] private GameObject DoorStepper;
    private SliderStepper doorStepper;
    [SerializeField] private GameObject LuminosityStepper;
    private SliderStepper luminosityStepper;
    [SerializeField] private GameObject BoxsizeButtonGroup;
    private BoxsizeButtonGroup boxsizeButtonGroup;

    [SerializeField] private GameObject BoxSmall;
    [SerializeField] private GameObject BoxMedium;
    [SerializeField] private GameObject BoxLarge;

    [SerializeField] public GameObject boxAnchor;

    private Box boxSmall;
    private Box boxMedium;
    private Box boxLarge;

    private bool controllersAreShown;

    private void Awake()
    {
        boxSmall = BoxSmall.GetComponent<Box>();
        boxMedium = BoxMedium.GetComponent<Box>();
        boxLarge = BoxLarge.GetComponent<Box>();
        doorStepper = DoorStepper.GetComponent<SliderStepper>();
        luminosityStepper = LuminosityStepper.GetComponent<SliderStepper>();
        boxsizeButtonGroup = BoxsizeButtonGroup.GetComponent<BoxsizeButtonGroup>();

        controllersAreShown = true;
    }
    private void Start()
    {
        ShowBoxLarge();
    }
    private void Update()
    {
        AdaptSoundscapeToDoorOpening();
    }

    void AdaptSoundscapeToDoorOpening()
    {
        if (doorStepper.GetStepperOpeningPercentage() > 98)
        {
            GameManager.Instance.soundscape.volume = 0.01f;
        }
        else if (doorStepper.GetStepperOpeningPercentage() > 70)
        {
            GameManager.Instance.soundscape.volume = 0.02f;
        }
        else
        {
            GameManager.Instance.soundscape.volume = 0.04f;
        }
    }

    public float GetDoorStepperOpeningPercentage()
    {
        return doorStepper.GetStepperOpeningPercentage();
    }

    public float GetLuminosityStepperOpeningPercentage()
    {
        return luminosityStepper.GetStepperOpeningPercentage();
    }

    public void HideAllBoxes()
    {
        boxSmall.Hide();
        boxMedium.Hide();
        boxLarge.Hide();
    }
    public void ShowBoxSmall()
    {
        HideAllBoxes();
        boxSmall.Show();
    }
    public void ShowBoxMedium()
    {
        HideAllBoxes();
        boxMedium.Show();
    }
    public void ShowBoxLarge()
    {
        HideAllBoxes();
        boxLarge.Show();
    }
    

    // !!!!!!!!!!!!!!!!!!! Trouver un moyen de désactiver les fonctions des controllers sans desactiver le gameobjct dans son ensemble !!!!!!!!!!!!!!!!!!!!!!!!
    private void HideBoxControllers()
    {
        doorStepper.Hide();
        luminosityStepper.Hide();
        boxsizeButtonGroup.Hide();
    }
    private void ShowBoxControllers()
    {
        doorStepper.Show();
        luminosityStepper.Show();
        boxsizeButtonGroup.Show();
    }
    public void ShowOrHideControllers()
    {
        if (controllersAreShown)
        {
            HideBoxControllers();
            controllersAreShown = false;
        }
        else
        {
            ShowBoxControllers();
            controllersAreShown = true;
        }
    }
}
