using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputMap input;

    private void OnEnable()
    {
        input = new InputMap();
        input.ActionMap.Enable();

        input.ActionMap.Menu.started += _ => SetMenu();
    }

    private void OnDisable()
    {
        input.ActionMap.Menu.started -= _ => SetMenu();

        input.ActionMap.Disable();
    }

    private void SetMenu()
    {
        MenuManager.Instance.ShowOrHideMenu();
    }
}
