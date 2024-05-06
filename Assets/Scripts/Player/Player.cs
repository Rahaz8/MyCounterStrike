using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity

{
    public override int HP => 100;
    public override int ARMOR => 50;
    public GameObject[] disable, enable;
    public bool dead = false;

    public override void Die()
    {
        dead = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        source.Play();
        Time.timeScale = 0;
        foreach(var o in disable)
        {
            o.SetActive(false);
        }
        foreach (var o in enable)
        {
            o.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level"+PlayerPrefs.GetInt("level"),LoadSceneMode.Single);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
