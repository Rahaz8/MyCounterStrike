using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInfo : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] Player plr;
    [SerializeField] Slider hp,armor;
    [SerializeField] Image gun;
    [SerializeField] TextMeshProUGUI ammo;
    // Update is called once per frame
    void Update()
    {
        armor.maxValue = plr.ARMOR;
        hp.maxValue = plr.HP;
        armor.value = plr.armor;
        hp.value = plr.hp;
        if (armor.value == 0 ) 
        {
            armor.gameObject.SetActive( false );
        }
        gun.sprite = player.w.sprite;
        ammo.text = player.w.ammo + "/" + player.w.MagSize;
    }
}
