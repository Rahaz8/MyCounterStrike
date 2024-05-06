using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void Newgame()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level1",LoadSceneMode.Single);
    }

    // Update is called once per frame
    public void Continue()
    {
        int level = PlayerPrefs.GetInt("level");
        SceneManager.LoadScene("Level" + level, LoadSceneMode.Single);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
