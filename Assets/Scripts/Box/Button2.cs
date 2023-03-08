using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    Renderer[] renderers;
    MeshCollider meshCollider;
    BoxCollider boxCollider;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
        meshCollider = GetComponentInChildren<MeshCollider>();
        boxCollider = GetComponentInChildren<BoxCollider>();
    }

    public void Hide()
    {
        foreach (Renderer r in renderers) { r.enabled = false; }
        meshCollider.enabled = false;
        boxCollider.enabled = false;
    }
    public void Show()
    {
        foreach (Renderer r in renderers) { r.enabled = true; }
        meshCollider.enabled = true;
        boxCollider.enabled = true;
    }
}
