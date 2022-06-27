using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshot;
    [SerializeField] private GameObject player;
    private float span = 2.0f;
    private float time =0f;
    bool InArea = false;
    private float arealr = 0.0f;
    private float areaud = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (InArea ==true)
        {
            
            float x = this.transform.position.x;
            float y = this.transform.position.y;
            time += Time.deltaTime;
            if (time > span)
            {
                Instantiate(enemyshot);
                enemyshot.transform.position = new Vector2(x - 0.7f, y - 0.8f);
                time = 0f;
            }
        }
        arealr = player.transform.position.x - this.transform.position.x;
        Debug.Log(arealr);
        areaud = player.transform.position.y - this.transform.position.y;
        if (arealr >= 16.0f || arealr <= -16.0f || areaud >= 4.0f || areaud <= -4.0f)//Collider�c��20�Ȃ�4 ����50�Ȃ�P�U
        {
            InArea = false;
            Debug.Log("as");
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        InArea = true;
        Debug.Log("c");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        InArea = true;
        Debug.Log("d");
    }



}
