using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maps : MonoBehaviour
{
    public void MapsLevel1()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("TM_level1");
        //AudioManager.instance.Play("level1");

    }
    public void MapsLevel2()
    {
         SceneManager.LoadScene("TM_level2");
         //AudioManager.instance.Play("level2");
    }
    public void MapsLevel3()
    {
         SceneManager.LoadScene("TM_level3");
         //AudioManager.instance.Play("level3");
    }
    public void MapsLevel4()
    {
         SceneManager.LoadScene("TM_level4");
         //AudioManager.instance.Play("level4");
    }
    public void MapsLevel5()
    {
         SceneManager.LoadScene("TM_level5");
         //AudioManager.instance.Play("level5");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("NewMenu");
    }

    public void PuzzleButton()
    {
        SceneManager.LoadScene("PuzzleGame");
         //AudioManager.instance.Play("puzmem");
    }

    public void MemoryButton()
    {
        SceneManager.LoadScene("MemoryGame");
         //AudioManager.instance.Play("puzmem");
    }

}
