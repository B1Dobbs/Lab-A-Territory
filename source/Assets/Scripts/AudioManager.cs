using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource menu;
    public AudioSource gamePlay;
    public AudioSource breaking;
    public AudioSource fixing;
    public AudioSource lockdown;
    public AudioSource button;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        menu.Play();
    }


    public void playMenu()
    {
        menu.Play();
    }

    public void stopMenu()
    {
        menu.Stop();
    }

    public void playGamePlay()
    {
        gamePlay.Play();
    }

    public void stopGamePlay()
    {
        gamePlay.Stop();
    }

    public void playBreaking()
    {
        breaking.Play();
    }

    public void playFixing()
    {
        fixing.Play();
    }

    public void playLockdown()
    {
        lockdown.Play();
    }

    public void playButton()
    {
        button.Play();
    }
}
