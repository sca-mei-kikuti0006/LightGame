using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1Control : MonoBehaviour
{
    //�ʏ��

    public GameObject attackUpBook;
    public GameObject attackSpeedBook;
    public GameObject defenseBook;

    //���ʉ�
    public GameObject openSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(openSound, this.transform.position, this.transform.rotation);//���ʉ�
        
            float rnd = Random.Range(0, 1f);
            Destroy(gameObject);

            if (rnd <= 0.6f)
            {
                Instantiate(attackUpBook, this.transform.position, this.transform.rotation);
                //�U����UP
            }
            else if(rnd <= 0.8f)
            {
                Instantiate(attackSpeedBook, this.transform.position, this.transform.rotation);
                //�U�����xUP
            }
            else
            {
                Instantiate(defenseBook, this.transform.position, this.transform.rotation);
                //�h���UP
            }
        }

    }
}
