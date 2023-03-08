using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPersonnalisationMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    public void Return()
    {
        MenuManager.Instance.CloseMenu(MenuManager.Instance.boxConfigurationMenu);
        MenuManager.Instance.OpenMenu(MenuManager.Instance.mainMenu);
    }
    public void Confirm()
    {
        MenuManager.Instance.SetDestinationToBox();
        MenuManager.Instance.CloseMenu(canvas);
        MenuManager.Instance.SetActualMenu(MenuManager.Instance.mainMenu);
    }
}
