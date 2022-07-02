using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2UpBook : MonoBehaviour
{
    //O2�ϋvUP

    GameObject oxygen;
    OxygenControl script;

    //���ʉ�
    public GameObject bookSound;

    // Start is called before the first frame update
    void Start()
    {
        oxygen = GameObject.Find("Oxygen");
        script = oxygen.GetComponent<OxygenControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Instantiate(bookSound, this.transform.position, this.transform.rotation);//���ʉ�
            script.O2Up += 0.1f;
            Destroy(gameObject);
        }

    }
}
