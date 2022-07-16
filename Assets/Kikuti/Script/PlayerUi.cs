using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerUi : MonoBehaviour
{
    //�A�C�e���l���e�L�X�g�\��

    public Text text;

    GameObject player;
    PlayerControl script;

    private Animator anim;//*

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();

        anim = gameObject.GetComponent<Animator>();//*
    }

    // Update is called once per frame
    void Update()
    {
        if (script.UiDecision==true)//�\��
        {
            anim.SetBool("Anim", true);//*

            text.text = script.Ui;
            StartCoroutine(DelayCoroutine(1, () => //�P�b���\��
            {
                text.text = " ";
                anim.SetBool("Anim", false);//*
                script.UiDecision=false;
            }));
        }
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }

}
