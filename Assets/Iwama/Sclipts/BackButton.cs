
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : CheckButton
{
    GameObject number;
    CheckButton script;
 
    public void PushButtonDialBack()
    {

        number = GameObject.Find("Check");
        script = number.GetComponent<CheckButton>();

        
        script.inputString = "";//back�̂��폜���Ă��܂��Ă���
        suuji_text.text = "";
        Panel.SetActive(false);

        Debug.Log("�߂�");
        
    }

}

