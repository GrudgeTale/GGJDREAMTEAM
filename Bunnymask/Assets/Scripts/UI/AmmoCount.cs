using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public Ammo player;
    public Text ammoText;

    // Update is called once per frame
    void Update(){
        ammoText.text = player.CurrentAmmo.ToString() + " / " + player.MaxAmmo.ToString();
    }
}
