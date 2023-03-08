using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderLimiter : MonoBehaviour
{
    [SerializeField] public GameObject minPosition;
    [SerializeField] public GameObject maxPosition;
    [SerializeField] public GameObject midPosition;

    private void Awake()
    {
        SetMidPosition();
    }
    public Vector3 GetMinPosition()
    {
        return minPosition.transform.localPosition;
    }

    public Vector3 GetMaxPosition()
    {

        return maxPosition.transform.localPosition;
    }
    private void SetMidPosition()
    {
        midPosition.transform.localPosition = maxPosition.transform.localPosition;
        Vector3 correction = (maxPosition.transform.localPosition + new Vector3(1, 1, 1)) - (minPosition.transform.localPosition + new Vector3(1, 1, 1));
        correction = new Vector3(correction.x, correction.y, correction.z / 2);
        midPosition.transform.localPosition = midPosition.transform.localPosition - correction;
    }
}
