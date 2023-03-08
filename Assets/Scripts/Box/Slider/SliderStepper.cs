using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderStepper : MonoBehaviour
{
    [SerializeField] private GameObject SliderStepperGrab;
    Renderer[] renderers;
    BoxCollider[] boxColliders;

    private SliderStepperGrab sliderStepperGrab;
    private SliderLimiter sliderLimiter;
    private CapsuleCollider capsuleCollider;

    // !!!!!!!!!!!!!!!!!!!!!!! ADD EVENT LISTENER FOR Z AXIS !!!!!!!!!!!!!!!!!!!!!!

    private void Awake()
    {
        sliderLimiter = SliderStepperGrab.GetComponent<SliderLimiter>();
        sliderStepperGrab = SliderStepperGrab.GetComponent<SliderStepperGrab>();
        renderers = GetComponentsInChildren<Renderer>();
        capsuleCollider = sliderStepperGrab.GetComponent<CapsuleCollider>();
        boxColliders = GetComponentsInChildren<BoxCollider>();
    }

    public float GetStepperOpeningPercentage()
    {
        float openingPercentage;
        openingPercentage = Percentage(sliderStepperGrab.GetValue(), sliderLimiter.maxPosition.transform.localPosition.z, sliderLimiter.minPosition.transform.localPosition.z);
        return openingPercentage;
    }

    private float Percentage(float actualPosition, float maxPosition, float minPosition)
    {
        float percentage;
        actualPosition = Mathf.Round((actualPosition + 1) * 100);
        maxPosition = Mathf.Round((maxPosition + 1) * 100);
        minPosition = Mathf.Round((minPosition + 1) * 100);

        actualPosition = actualPosition - minPosition;
        maxPosition = maxPosition - minPosition;
        minPosition = 0;
        percentage = (((actualPosition - minPosition) / maxPosition)) * 100;

        return percentage;
    }

    public void Hide()
    {
        capsuleCollider.enabled = false;
        foreach(Renderer r in renderers) { r.enabled = false; }
        foreach (BoxCollider b in boxColliders) { b.enabled = false; }
    }
    public void Show()
    {
        capsuleCollider.enabled = true;
        foreach (Renderer r in renderers) { r.enabled = true; }
        foreach (BoxCollider b in boxColliders) { b.enabled = true; }
    }
}
