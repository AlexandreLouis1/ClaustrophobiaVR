using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxsizeButtonGroup : MonoBehaviour
{
    [SerializeField] GameObject ButtonSmall;
    [SerializeField] GameObject ButtonMedium;
    [SerializeField] GameObject ButtonLarge;
    [SerializeField] GameObject text;

    Button2 buttonSmall;
    Button2 buttonMedium;
    Button2 buttonLarge;

    private void Awake()
    {
        buttonSmall = ButtonSmall.GetComponent<Button2>();
        buttonMedium = ButtonMedium.GetComponent<Button2>();
        buttonLarge = ButtonLarge.GetComponent<Button2>();
    }

    public void Hide()
    {
        text.SetActive(false);
        buttonSmall.Hide();
        buttonMedium.Hide();
        buttonLarge.Hide();
    }

    public void Show()
    {
        text.SetActive(true);
        buttonSmall.Show();
        buttonMedium.Show();
        buttonLarge.Show();
    }
}
