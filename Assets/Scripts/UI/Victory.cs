using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI score , win;
    [SerializeField] Button cont, exit;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    public bool won = false;
    void Update()
    {
        score.text = "Осталось ботов: " + (transform.childCount);
        if (transform.childCount == 0 ) 
        {
            won = true;
            cont.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            win.gameObject.SetActive(true);
            score.gameObject.SetActive(false);
            Destroy(gameObject);
            source.clip = clip;
            source.Play();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
