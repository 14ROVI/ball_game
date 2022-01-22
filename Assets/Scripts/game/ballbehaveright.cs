using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballbehaveright : MonoBehaviour {

    Rigidbody2D rb;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update () {

        if (rb.velocity.y < 0.1)
        {
            Destroy(gameObject);
        }

	}
}
