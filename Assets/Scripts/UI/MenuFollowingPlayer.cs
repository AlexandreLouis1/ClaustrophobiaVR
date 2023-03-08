using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFollowingPlayer : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] Camera firstPersonCamera;

    [Range(0, 1)]
    [SerializeField] float smoothFactor = 0.060f;

    [SerializeField] float distanceFromCamera = 65;
    [SerializeField] float cameraHeight = 0.5f;
    [SerializeField] float offCenter = 0.5f;

    void Update()
    {
        menuCanvas.transform.rotation = firstPersonCamera.transform.rotation;
        Vector3 cameraCenter = firstPersonCamera.transform.position + firstPersonCamera.transform.forward * distanceFromCamera + firstPersonCamera.transform.up * cameraHeight + firstPersonCamera.transform.right * offCenter;

        Vector3 currentPos = menuCanvas.transform.position;

        menuCanvas.transform.position = Vector3.Lerp(currentPos, cameraCenter, smoothFactor);
    }

    private void OnEnable()
    {
        menuCanvas.transform.position = firstPersonCamera.transform.position;
    }
}
