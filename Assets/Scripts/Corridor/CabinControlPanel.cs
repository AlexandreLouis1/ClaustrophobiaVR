using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinControlPanel : MonoBehaviour
{
    [SerializeField] private GameObject m_cabin;
    private Cabin cabin;
    public Button ButtonPressedListener;
    [SerializeField] private Button buttonPressed;

    private void Awake()
    {
        cabin = m_cabin.GetComponent<Cabin>();
    }

    public void ButtonIsPressed(Button button)
    {
        if(ButtonPressedListener == null)
        {
            ButtonPressedListener = button;
            buttonPressed.isOff();
            buttonPressed = button;
            cabin.StartElevetorScene();
            button.isOn();
        }
    }

    public void ElevatorSceneIsOver()
    {
        ClearButtonPressedListener();
    }

    void ClearButtonPressedListener()
    {
        ButtonPressedListener = null;
    }
}
