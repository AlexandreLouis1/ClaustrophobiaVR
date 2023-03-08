using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public AudioSource soundscape;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerTrackerOffset;
    [SerializeField] public GameObject Corridor;
    [SerializeField] public GameObject Box;

    private Corridor corridor;
    private BoxControllers boxControllers;

    private void Awake()
    {
        Instance = this;
        corridor = Corridor.GetComponent<Corridor>();
        boxControllers = Box.GetComponent<BoxControllers>();
    }
    private void Start()
    {
        MenuManager.Instance.enabled = true;
    }

    public void TeleportPlayerToDestination(GameObject destination)
    {
        if(destination != null)
        {
            if (destination == Box)
            {
                player.transform.position = boxControllers.boxAnchor.transform.position;
            }
            if(destination == Corridor)
            {
                player.transform.position = corridor.corridorAnchor.transform.position;
            }
            playerTrackerOffset.transform.position = player.transform.position;
        }
        else
        {
            Debug.LogError("Erreur TeleportPlayerToDestination");
        }
    }
}
