using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdate : Singleton<UIUpdate>
{
    public TMP_Text ammo;
    public TMP_Text Health;
    public TMP_Text Reloading;

    public void updateammo(int a){
        ammo.text = "ammo:"+Convert.ToString(a);
    }
    
    public void updatereloading(float h){
        Reloading.text = "realoading:"+Convert.ToString(h);
    }
    
    public void updatehealth(float h){
        Health.text = "Health:"+Convert.ToString(h);
    }
}
