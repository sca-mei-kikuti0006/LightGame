using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�h���b�v����Ǘ�

    GameObject player;
    PlayerControl script;


    public static int attackUp=12;//�U���́@
    public static int attackSpeedUp=5;//�U�����x
    public static int speedUp=10;//�ړ����x
    public static int jumpUp=1;//�W�����v
    public static int hpUp=10;//HP
    public static int o2Up=5;//�_�f������
    public static int defenseUp=10;//�h���
    public static int attackRange=10;//�U���͈�
    public static int hpRecUp=1;//������


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerControl>();


    }

    // Update is called once per frame
    void Update()
    {
       
    }

}

