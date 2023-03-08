using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    public void Quit()
    {
        Application.Quit();
    }

    public void OpenBoxPersonnalisation()
    {
        MenuManager.Instance.CloseMenu(canvas);
        MenuManager.Instance.OpenMenu(MenuManager.Instance.boxConfigurationMenu);
    }
    public void OpenCorridor()
    {
        MenuManager.Instance.SetDestinationToCorridor();
        MenuManager.Instance.CloseMenu(canvas);
    }
}
