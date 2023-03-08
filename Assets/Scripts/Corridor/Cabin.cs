using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabin : MonoBehaviour
{
    [SerializeField] private AudioClip elevatorDoorOpen;
    [SerializeField] private AudioClip elevatorDoorClose;
    [SerializeField] private AudioClip elevatorSound;
    private AudioSource elevatorDoorAudio;
    public Animator doorAnim;

    [SerializeField] GameObject m_cabinControlPanel;
    CabinControlPanel cabinControlPanel;

    public bool isOpen;
    private void Awake()
    {
        elevatorDoorAudio = GetComponentInChildren<AudioSource>();
        doorAnim = GetComponentInChildren<Animator>();
        cabinControlPanel = m_cabinControlPanel.GetComponent<CabinControlPanel>();
    }

    public void DesactivateAnimator()
    {
        doorAnim.enabled = false;
    }
    public void ActivateAnimator()
    {
        doorAnim.enabled = true;
    }

    public void PlayDoorOpenSound()
    {
        elevatorDoorAudio.clip = elevatorDoorOpen;
        elevatorDoorAudio.Play();
    }
    
    public void PlayDoorCloseSound()
    {
        elevatorDoorAudio.clip = elevatorDoorClose;
        elevatorDoorAudio.Play();
    }

    public void PlayElevatorSound()
    {
        elevatorDoorAudio.clip = elevatorSound;
        elevatorDoorAudio.Play();
    }

    public void OpenCabin()
    {
        doorAnim.SetBool("isOpen", true);
    }

    public void CloseCabin()
    {
        doorAnim.SetBool("isOpen", false);
    }

    private void SetOpen()
    {
        isOpen = true;
    }
    private void SetClose()
    {
        isOpen = false;
    }

    public IEnumerator PlayElevatorScene()
    {
        CloseCabin();
        while (isOpen)
        {
            yield return null;
        }

        PlayElevatorSound();

        yield return new WaitForSeconds(2);

        OpenCabin();

        yield return new WaitForSeconds(1.5f);

        cabinControlPanel.ElevatorSceneIsOver();
    }

    public void StartElevetorScene()
    {
        StartCoroutine(PlayElevatorScene());
    }
}
