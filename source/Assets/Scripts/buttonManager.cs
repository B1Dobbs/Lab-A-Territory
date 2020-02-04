using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject options;
    public GameObject pressKey;
    public GameObject controls;
    public GameObject credits;
    public GameObject tutorial;

    AudioManager audioManager;

    void Start(){
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    public void PlayGame() {
        SceneManager.LoadScene("AlexScene");
        audioManager.stopMenu();
        audioManager.playGamePlay();
        audioManager.playButton();
    }
    public void Tutorial() {
        tutorial.SetActive(true);
        mainMenu.SetActive(false);
        audioManager.playButton();
    }
    public void Options() {
        mainMenu.SetActive(false);
        options.SetActive(true);
        audioManager.playButton();
    }
    public void ExitGame() {
        Application.Quit();
        audioManager.playButton();
    }
    public void PlayAgain() {
        SceneManager.LoadScene("BrookeScene");
        audioManager.stopMenu();
        audioManager.playGamePlay();
        audioManager.playButton();
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
        audioManager.stopGamePlay();
        audioManager.playButton();
    }
    public void Credits() {
        credits.SetActive(true);
        mainMenu.SetActive(false);
        audioManager.playButton();
    }
    public void BackCredits() {
        credits.SetActive(false);
        mainMenu.SetActive(true);
        audioManager.playButton();
    }
    public void BackTutorial() {
        tutorial.SetActive(false);
        mainMenu.SetActive(true);
        audioManager.playButton();
    }
}
