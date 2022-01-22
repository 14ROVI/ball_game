using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class buttonContolers : MonoBehaviour {

    public GameObject launcher;
    public GameObject diemessage;
    public GameObject restartbutton;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject pauseMessage;
    public GameObject pointAdder;
    public GameObject homeb;
    bool pauseCheck = false;
    bool died = false;

    public void menu(bool die)
    {
        if (die)
        {
            diemessage.SetActive(true);
            died = true;

            showAd();
            
        }
        else
        {
            pauseMessage.SetActive(true);
        }
        
        pauseButton.SetActive(false);
        homeb.SetActive(true);
        restartbutton.SetActive(true);
        playButton.SetActive(true);
        Time.timeScale = 0;

        
    }

    public void showAd()
    {
        Time.timeScale = 0;

        if (Random.Range(0,2) == 0)
        {
            return;
        }

        else if (Advertisement.IsReady())
        {
            Advertisement.Show("", new ShowOptions() {resultCallback = handleResult});
        }
        
    }

    private void handleResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Time.timeScale = 1;
                break;
            case ShowResult.Skipped:
                Time.timeScale = 1;
                break;
            case ShowResult.Failed:
                Time.timeScale = 1;
                break;
            

        }
        if (died == true)
        {
            Time.timeScale = 0;
        }
    }


    public void home()
    {
        restart();
        SceneManager.LoadScene(0);
        showAd();
    }


    public void restart()
    {

        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");

        enemyCreator eC = launcher.GetComponent<enemyCreator>();

        foreach (GameObject item in enemys)
        {
            Destroy(item);
        }

        eC.count = 5;

        WR Wr = pointAdder.GetComponent<WR>();
        Wr.readTextFile();
        Wr.cachePoints = 0;

        pauseMessage.SetActive(false);
        homeb.SetActive(false);
        diemessage.SetActive(false);
        restartbutton.SetActive(false);
        playButton.SetActive(false);
        pauseButton.SetActive(true);

        showAd();

        died = false;
    }

    public void pause()
    {

        if (pauseCheck == false)
        {

            Time.timeScale = 0;
            menu(false);
            pauseButton.SetActive(false);
            pauseCheck = true;

        }

        else
        {

            Time.timeScale = 1;
            pauseCheck = false;

        }
    }

    public void play()
    {
        if (died == true)
        {
            restart();
        }

        else
        {
            pauseMessage.SetActive(false);
            pauseButton.SetActive(true);
            playButton.SetActive(false);
            restartbutton.SetActive(false);
            homeb.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
