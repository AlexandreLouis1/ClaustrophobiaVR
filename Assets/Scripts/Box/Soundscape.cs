using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundscape : MonoBehaviour
{
    private float volumeToReach;

    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(volumeToReach != m_AudioSource.volume)
        {
            if(volumeToReach > m_AudioSource.volume)
            {
                m_AudioSource.volume += 0.01f;
            }
            else
            {
                m_AudioSource.volume -= 0.01f;
            }
        }
    }

    public void SetVolumeToReach(float newVolumeToReach)
    {
        volumeToReach = newVolumeToReach;
    }
}
