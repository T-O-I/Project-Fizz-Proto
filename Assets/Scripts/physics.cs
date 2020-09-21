using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physics : MonoBehaviour
{
    private float speed = 5f;
    private Vector2 inertia;
    private move moveScript;

    private Rigidbody2D ballrb2;
    private Transform particleTransform;
    private float startingY;
    private float despawnY = 7f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("character");
        moveScript = player.GetComponent<move>();
        ballrb2 = this.GetComponent<Rigidbody2D>();
        particleTransform = this.GetComponent<Transform>();
        startingY = particleTransform.position.y;
        //Debug.Log(startingY.ToString());
        //Debug.Log("DESPAWN AT: " + (startingY - despawnY).ToString());
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void FixedUpdate()
    {
        inertia = -moveScript._inertia;
        //if(inertia != new Vector2(0.0f, 0.0f))
        //{
        ballrb2.AddForce(inertia * speed);
        //}
        if (moveScript._isFalling)
        {
            if (!moveScript.onWall)
            {
                ballrb2.AddForce(new Vector2(0, 12.5f));
            }
        }
        if (particleTransform.position.y < (startingY - despawnY))
        {
            //Debug.Log("Despawning particle");
            Destroy(this.gameObject);
        }
    }
}
