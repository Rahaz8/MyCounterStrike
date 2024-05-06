
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelchange : MonoBehaviour
{
    public void Next()
    {
        int level = PlayerPrefs.GetInt("level");
        level++;
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level" + level, LoadSceneMode.Single);
    }
}
