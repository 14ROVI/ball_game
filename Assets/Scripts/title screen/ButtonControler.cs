using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControler : MonoBehaviour {

    

    public void start()
    {

        SceneManager.LoadScene(1);
        
    }
    public void upgrade()
    {

        SceneManager.LoadScene(2);

    }
    public void home()
    {

        SceneManager.LoadScene(0);

    }
}
