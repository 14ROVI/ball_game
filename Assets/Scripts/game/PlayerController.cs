using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public GameObject rbutton;
    private int speed = 100;
    public GameObject message;
    private bool ballCreateDistancer = true;
    private float ballfreq = 0.5f;
    private int ballSpeed = 200;
    public GameObject ball;
    private Rigidbody2D rb;
    private float step;
    private Vector3 newPosition;
    public GameObject buttonController;
    GameObject wre;
    WR wr;
    int rate;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbutton.SetActive(false);
        message.SetActive(false);
        wre = GameObject.FindGameObjectWithTag("Wr");
        wr = wre.GetComponent<WR>();
        rate = wr.rate;
        ballfreq = ballfreq / rate;
    }

    void FixedUpdate () {

        Vector3 oldPosition = new Vector3(rb.position.x,0,0);

        if (Input.touchCount > 0)
        {
            newPosition = new Vector3(Input.GetTouch(0).position.x, 0, 0);
            newPosition = Camera.main.ScreenToWorldPoint(newPosition);
        }

        step = speed * Time.deltaTime;
        rb.transform.position = Vector3.MoveTowards(oldPosition, newPosition, step);

        StartCoroutine(ballCreate(ball));
    }

    IEnumerator ballCreate(GameObject ball)
    {

        if (Input.GetMouseButton(0))
        {
            if (ballCreateDistancer == true)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
                GameObject ballclone = (GameObject)Instantiate(ball, pos, transform.rotation);
                ballclone.GetComponent<Rigidbody2D>().velocity = transform.up * ballSpeed;
                StartCoroutine(ballPurge(ballclone));
                ballCreateDistancer = false;
                yield return new WaitForSeconds(ballfreq);
                ballCreateDistancer = true;

            }
        }
    }

    IEnumerator ballPurge(GameObject ballclone){

        yield return new WaitForSeconds(4);
        Destroy(ballclone);

    }

    public void balld(GameObject ball)
    {
        Destroy(ball);
    }
}
