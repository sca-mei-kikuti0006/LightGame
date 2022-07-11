using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    GameObject player;
    PlayerControl script;
    SpriteRenderer MainSpriteRendererD;
    SpriteRenderer MainSpriteRendererU;
    SpriteRenderer MainSpriteRendererR;
    SpriteRenderer MainSpriteRendererL;
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] private Sprite atk;
    [SerializeField] private Sprite o2up;
    [SerializeField] private Sprite explosion;
    [SerializeField] private GameObject enemyshotR;
    [SerializeField] private GameObject enemyshotL;
    [SerializeField] private GameObject enemyshotU;
    [SerializeField] private GameObject enemyshotD;
    [SerializeField] private GameObject enemy6r;//right方向(下)の攻撃
    [SerializeField] private GameObject enemy6l;//left方向(下)の攻撃
    [SerializeField] private GameObject enemy6rd;//enemy6rの生成位置
    [SerializeField] private GameObject enemy6ld;//enemy6lの生成位置
    [SerializeField] private GameObject enemy6R;//right方向(上)の攻撃
    [SerializeField] private GameObject enemy6L;//left方向(上)の攻撃
    [SerializeField] private GameObject enemy6ru;//enemy6Rの生成位置
    [SerializeField] private GameObject enemy6lu;//enemy6Lの生成位置
    [SerializeField] private GameObject Coin;
    private float span = 1.0f;
    private float span2 = 1.5f;
    private float span3 = 3.0f;
    private float time = 0f;
    private float time2 = 0f;
    private float time3 = 0f;
    private float hp = 1000;
    private float nowhp;
    private int o2d = 0;
    private int o2u = 0;
    private int o2r = 0;
    private int o2l = 0;
    Rigidbody2D rb;
    bool InArea = false;
    private float arealr = 0.0f;//攻撃範囲(左右)
    private float areaud = 0.0f;//攻撃範囲(上下)
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        MainSpriteRendererD = enemyshotD.GetComponent<SpriteRenderer>();
        MainSpriteRendererR = enemyshotR.GetComponent<SpriteRenderer>();
        MainSpriteRendererL = enemyshotL.GetComponent<SpriteRenderer>();
        MainSpriteRendererU = enemyshotU.GetComponent<SpriteRenderer>();
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
       script = player.GetComponent<PlayerControl>();
        hpSlider.value = 1000;
    }

    void Update()
    {
        recovery();
        //プレイヤーが範囲に入ったら位置を求め、時間を計測
        if (InArea == true)
        {

            float x = this.transform.position.x;
            float y = this.transform.position.y;
            time += Time.deltaTime;
            time2 += Time.deltaTime;
            time3 += Time.deltaTime;
            //span3秒経過したらenemyshotR〜enemyshotDを生成
            if (time3 > span3 && this.tag != "explosion")
            {
                Instantiate(enemyshotR);
                Instantiate(enemyshotL);
                Instantiate(enemyshotU);
                Instantiate(enemyshotD);
                enemyshotR.transform.position = new Vector2(x, y);
                enemyshotL.transform.position = new Vector2(x, y);
                enemyshotU.transform.position = new Vector2(x, y);
                enemyshotD.transform.position = new Vector2(x, y);
                time3 = 0f;
            }
            //span秒経過したらenemy6r,enemy6Lの生成
            if (time > span && this.tag != "explosion")
            {
                Instantiate(enemy6r);
                Instantiate(enemy6L);
                enemy6r.transform.position = enemy6rd.transform.position;
                enemy6L.transform.position = enemy6lu.transform.position;
                time = 0f;

            }
            //span2秒経過したらenemy6l,enemy6Rの生成
            if (time2 > span2 && this.tag != "explosion")
            {
                Instantiate(enemy6l);
                Instantiate(enemy6R);
                enemy6l.transform.position = enemy6ld.transform.position;
                enemy6R.transform.position = enemy6ru.transform.position;
                time2 = 0f;
            }
        }
        arealr = player.transform.position.x - this.transform.position.x;
        //Debug.Log(arealr);
        areaud = player.transform.position.y - this.transform.position.y;
        if (arealr >= 60.0f || arealr <= -60.0f || areaud >= 60.0f || areaud <= -60.0f)//Colliderが４０なら60
        {
            InArea = false;
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            InArea = true;
        }

        if (other.gameObject.tag == "Bullet")
        {
            hp -= script.Power;
            hpSlider.value = hp;
        }
        if (other.gameObject.tag == "Gun")
        {
            hp -= (script.Power / 2);
            hpSlider.value = hp;
        }
        if (other.gameObject.tag == "Explosion")
        {
            hp -= 50;
            hpSlider.value = hp;
        }

        if (hp <= 0)
        {
            MainSpriteRenderer.sprite = explosion;
            this.tag = "explosion";
            Invoke("End", 2.0f);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            InArea = true;
        }

        if (other.gameObject.tag == "Bullet")
        {
            hp -= script.Power;
        }
        if (other.gameObject.tag == "Gun")
        {
            hp -= (script.Power / 2);
        }
        if (other.gameObject.tag == "Explosion")
        {
            hp -= 50;
        }

        if (hp <= 0)
        {
            MainSpriteRenderer.sprite = explosion;
            this.tag = "explosion";
            Invoke("End", 2.0f);
        }
    }




    void recovery()
    {
        o2d = Random.Range(1, 11);
        if (o2d >= 9)
        {
            MainSpriteRendererD.sprite = o2up;
            enemyshotD.tag = "O2";
        }

        else
        {
            MainSpriteRendererD.sprite = atk;
            enemyshotD.tag = "Boss";
        }

        o2u = Random.Range(1, 11);
        if (o2u >= 9)
        {
            MainSpriteRendererU.sprite = o2up;
            enemyshotU.tag = "O2";
        }

        else
        {
            MainSpriteRendererU.sprite = atk;
            enemyshotU.tag = "Boss";
        }

        o2r = Random.Range(1, 11);
        if (o2r >= 9)
        {
            MainSpriteRendererR.sprite = o2up;
            enemyshotR.tag = "O2";
        }

        else
        {
            MainSpriteRendererR.sprite = atk;
            enemyshotR.tag = "Boss";
        }

        o2l = Random.Range(1, 11);
        if (o2l >= 9)
        {
            MainSpriteRendererL.sprite = o2up;
            enemyshotL.tag = "O2";
        }

        else
        {
            MainSpriteRendererL.sprite = atk;
            enemyshotL.tag = "Boss";
        }
    }


    void End()
    {
        this.gameObject.SetActive(false);
    }
}
