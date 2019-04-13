using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    float musicVolume = 0.1f;
    float bangVolume = 5f;
    float movementVolume = 0.1f;
    bool movingSoundIsPlaying = false;
    [SerializeField] AudioClip mainMusic;
    [SerializeField] AudioClip bangSound;
    [SerializeField] AudioClip movementSound;

    AudioSource audioSource;
    Player player;

    private void Awake()
    {
        int nbOfAudioManagers = FindObjectsOfType<AudioManager>().Length;
        if(nbOfAudioManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        if(!mainMusic || !bangSound || !movementSound)
        {
            Debug.LogWarning("Music or sound(s) is/are missing");
            return;
        }

        audioSource = GetComponent<AudioSource>();

        if (!audioSource)
        {
            Debug.LogWarning("AudioSource component is missing from AudioManager Game object");
            return;
        }

        PlayBackgroundMusic();
    }

    private void Update()
    {
        ManageMovementSound();
    }

    private void ManageMovementSound()
    {
        player = FindObjectOfType<Player>();
        if (!player)
        {
            return;
        }

        AudioSource playerAudio = player.GetComponent<AudioSource>();
        if (!playerAudio)
        {
                return;
        }

        if (!player.playerIsStatic && !movingSoundIsPlaying)
        {
            movingSoundIsPlaying = true;
            playerAudio.Stop();
            playerAudio.clip = movementSound;
            playerAudio.volume = movementVolume;
            playerAudio.loop = true;
            playerAudio.Play();
        }
        else if(player.playerIsStatic || player.playerHasWon)
        {
            playerAudio.Stop();
            movingSoundIsPlaying = false;
        }
    }

    private void PlayBackgroundMusic()
    {
        audioSource.Stop();
        audioSource.clip = mainMusic;
        audioSource.volume = musicVolume;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayCollisionSound()
    {
        audioSource.PlayOneShot(bangSound, bangVolume);
    }
    
}
