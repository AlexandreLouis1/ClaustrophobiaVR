using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject BoxConfigurationMenu;

    public Canvas mainMenu;
    public Canvas boxConfigurationMenu;

    private Canvas actualMenu;

    private void Awake()
    {
        Instance = this;

        mainMenu = MainMenu.GetComponent<Canvas>();
        boxConfigurationMenu = BoxConfigurationMenu.GetComponent<Canvas>();
    }
    private void Start()
    {
        OpenMenu(mainMenu);
    }
    public void SetDestinationToBox()
    {
        GameManager.Instance.TeleportPlayerToDestination(GameManager.Instance.Box);
    }
    public void SetDestinationToCorridor()
    {
        GameManager.Instance.TeleportPlayerToDestination(GameManager.Instance.Corridor);
    }
    public void OpenMenu(Canvas menu)
    {
        menu.enabled = true;
        SetActualMenu(menu);
    }
    public void CloseMenu(Canvas menu)
    {
        menu.enabled = false;
    }
    public void ShowOrHideMenu()
    {
        if(actualMenu != null)
        {
            if (actualMenu.enabled)
            {
                actualMenu.enabled = false;
            }
            else
            {
                actualMenu.enabled = true;
            }
        }
        else { Debug.LogError("No menu available"); }
    }
    public void SetActualMenu(Canvas menu)
    {
        actualMenu = menu;
    }
}
