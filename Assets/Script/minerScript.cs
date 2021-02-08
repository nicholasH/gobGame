using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minerScript : MonoBehaviour {
    public float gForce = 0;
    public float HorizontalSpeed = 0;

    private Rigidbody2D Rigid;
    private Collider2D colli;

    private Vector2 lastVelocity;
    private Vector2 acceleration;

    // Use this for initialization
    void Start () {
        Rigid = GetComponent<Rigidbody2D>();
        colli = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        float translationVert = Input.GetAxis("Vertical");
        float translationHori = Input.GetAxis("Horizontal");

        Vector2 hMovement = new Vector2(translationHori, 0);
        Vector2 VMovement = new Vector2(translationHori, translationVert);

        Rigid.AddForce(hMovement * HorizontalSpeed);
        Rigid.AddForce(VMovement * (gForce*9.81f));

        acceleration = (Rigid.velocity - lastVelocity) / Time.fixedDeltaTime;
        lastVelocity = Rigid.velocity;

        //print(lastVelocity);
        //print(Input.GetAxis("Vertical"));

    }


    void OnCollisionEnter2D(Collision2D col)
    {

    }
    void OnCollisionStay2D(Collision2D collisionInfo)
    {

 
        if (collisionInfo.collider.name == "verticalCollider")
        {
            
            if (Input.GetAxis("Vertical") > .9 || Input.GetAxis("Vertical") < -.9 )
            {
                collisionInfo.gameObject.SendMessageUpwards("Digging");
            }

        }
        else if(collisionInfo.collider.name == "HorizontalCollider")
        {

            if (Input.GetAxis("Horizontal") > .9 || Input.GetAxis("Horizontal") < -.9)
            {
                collisionInfo.gameObject.SendMessageUpwards("Digging");
            }
        }
    }


    // Update is called once per frame
    void Update () {

    }
}
