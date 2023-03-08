using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderStepperGrab: MonoBehaviour
{
    private Vector3 minPos;
    private Vector3 maxPos;
    private Vector3 medPos;

    [SerializeField] private GameObject _text;
    private TextMeshPro text;
    private SliderLimiter sliderLimiter;

    [SerializeField] private StartingPositionEnum position;

    private void Awake()
    {
        text = _text.GetComponent<TextMeshPro>();
        sliderLimiter = GetComponent<SliderLimiter>();

        InitializeLimiters();
    }

    private void Update()
    {
        text.text = Math.Round(GetValue(), 2).ToString();
    }

    public enum StartingPositionEnum
    {
        MinPosition, MidPosition, MaxPosition
    }

    public float GetValue()
    {
        return transform.localPosition.z;
    }

    public float GetMaxValue()
    {
        return sliderLimiter.maxPosition.transform.position.z;
    }

    public float GetMinValue()
    {
        return sliderLimiter.minPosition.transform.position.z;
    }

    private void InitializeLimiters()
    {
        minPos = transform.localPosition;
        maxPos = transform.localPosition;
        medPos = transform.localPosition;
        minPos.z = sliderLimiter.minPosition.transform.position.z;
        maxPos.z = sliderLimiter.maxPosition.transform.position.z;
        medPos.z = sliderLimiter.midPosition.transform.position.z;

        switch (position)
        {
            case StartingPositionEnum.MinPosition:
                transform.localPosition = sliderLimiter.minPosition.transform.localPosition;
                break;
            case StartingPositionEnum.MidPosition:
                transform.localPosition = sliderLimiter.midPosition.transform.localPosition;
                break;
            case StartingPositionEnum.MaxPosition:
                transform.localPosition = sliderLimiter.maxPosition.transform.localPosition;
                break;
            default:
                Debug.LogError("No starting position set for " + transform.name);
                break;
        }
    }
}
