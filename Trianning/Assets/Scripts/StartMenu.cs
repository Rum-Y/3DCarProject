using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum GAMETYPE {SINGLE,MULTI};
public class StartMenu : MonoBehaviour
{
    public GameObject panelA;
    public GameObject panelB;
    public GAMETYPE gameType=GAMETYPE.SINGLE;
    // Start is called before the first frame update
    void Start()
    {
        panelB.SetActive(false);
    }
    public void PlayA()
    {
        panelA.SetActive(false);
        panelB.SetActive(true);
    }
    public void playSingle()
    {
         gameType=GAMETYPE.SINGLE;
         PlayerPrefs.SetString("GAMETYPE","SINGLE");
         SceneManager.LoadScene(1);
    }
    public void playMulti()
    {
         gameType=GAMETYPE.MULTI;
         PlayerPrefs.SetString("GAMETYPE","MULTI");
         SceneManager.LoadScene(1);
    }
    public void Quit()
    {
       Application.Quit();
     }
    // Update is called once per frame
    void Update()
    {
        
    }
}
