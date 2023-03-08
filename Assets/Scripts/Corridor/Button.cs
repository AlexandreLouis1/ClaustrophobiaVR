using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static List<Button> cabinButtonsList = new List<Button>();

    [SerializeField] GameObject m_CabinControlPanel;
    CabinControlPanel cabinControlPanel;

    public GameObject lightBtn;
    public Material lightOn;
    public Material lightOff;

    private Rigidbody rb;

    public int buttonID;

    void Awake()
    {
        buttonID = int.Parse(transform.name);
        cabinButtonsList.Add(this);

        rb = GetComponent<Rigidbody>();
        cabinControlPanel = m_CabinControlPanel.GetComponent<CabinControlPanel>();
        if(buttonID == 0)
        {
            isOn();
        }
    }

    public void isOn()
    {
        lightBtn.GetComponent<Renderer>().material = lightOn;
        rb.isKinematic = true;
    }

    public void isOff()
    {
        lightBtn.GetComponent<Renderer>().material = lightOff;
        rb.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Trigger")
        {
             cabinControlPanel.ButtonIsPressed(this);
        }
    }
}
