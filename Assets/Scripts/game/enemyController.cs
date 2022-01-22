using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject launcher;
    public GameObject textg;
    public GameObject bcontroller;
    public GameObject wre;
    public int health;
    public int num;
    private Sprite blockSprite;
    private SpriteRenderer spriteRenderer;
    private PlayerController pC;
    private buttonContolers bC;
    private WR wr;
    private int ldmg;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        launcher = GameObject.FindGameObjectWithTag("player");
        bcontroller = GameObject.FindGameObjectWithTag("bCon");
        wre = GameObject.FindGameObjectWithTag("Wr");
        wr = wre.GetComponent<WR>();
        ldmg = wr.dmg;
        randomSprite();
        GetComponentInChildren<TextMesh>().text = health.ToString();
        StartCoroutine(enemyPurge());
        

    }

    public void addHealth()
    {
        int rand = Random.Range(0, 2);
        int rand2 = Random.Range(1, 11);

        //print(rand2);
        //print(rand);

        if (rand == 0)
        {
            health = 50 + num * num + (num * num / rand2);
        }

        if (rand == 1)
        {
            health = 50 + num * num - (num * num / rand2);  
        }
        //print(health);
        num += 1;
    }

    void FixedUpdate()
    {
        //print(health);
        if (health <= 0)
        {

            Destroy(gameObject);

        }
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {

            pC = launcher.GetComponent<PlayerController>();
            pC.balld(collision.gameObject);
            health = health - ldmg;
            GetComponentInChildren<TextMesh>().text = health.ToString();
            wr.chache(ldmg);

        }

        if (collision.gameObject.tag == "player")
        {
            //print("1");
            bC = bcontroller.GetComponent<buttonContolers>();
            bC.menu(true);

        }
    }

    void randomSprite()
    {

        num = Random.Range(1, 5);
        string numstr = num.ToString();

        blockSprite = Resources.Load<Sprite>(numstr);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = blockSprite;
        textg = Instantiate(textg);
        textg.transform.SetParent(transform);
        textg.transform.localPosition = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(0, -30, 0);

    }

    IEnumerator enemyPurge()
    {

        yield return new WaitForSeconds(10);
        Destroy(gameObject);

    }
}
