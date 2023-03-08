using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Renderer[] renderers;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void Hide()
    {
        foreach (Renderer r in renderers) { r.enabled = false; }
    }
    public void Show()
    {
        foreach (Renderer r in renderers) { r.enabled = true; }
    }
}
