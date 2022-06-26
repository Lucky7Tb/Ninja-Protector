using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenGameManager : MonoBehaviour
{
    public AudioClip backgroundSound; 
    private AudioSource playerAudio;

    void Start()
    {
        Screen.SetResolution(1025, 768, false);
        playerAudio = GetComponent<AudioSource>();
        playerAudio.loop = true;
        playerAudio.PlayOneShot(backgroundSound, 1f);
    }

    public void StartGame()
    {
        playerAudio.Stop();
        SceneManager.LoadScene("Main");
    }
}
