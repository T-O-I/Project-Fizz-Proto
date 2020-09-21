using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private LayerMask platformLayerMask;

    public float speed;

    private Rigidbody2D rb2d;

    private Vector2 inertia;

    private bool isJumping = false;

    private BoxCollider2D bc2d;

    public bool onWall = false;

    private int wallJumpCount = 0;

    private bool falling = false;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        _isFalling = false;


    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        if (!isWalled())
        {
            onWall = false;
            wallJumpCount = 0;
        }
        else
        {
            onWall = true;
        }

        //if on wall, press space once
        if(Input.GetButtonDown("Jump") && isWalled() && wallJumpCount < 1)
        {
            Vector2 jump;
            jump = new Vector2(0, 7);
            rb2d.AddForce(jump, ForceMode2D.Impulse);
            wallJumpCount++;
        }

        //ixf (Input.GetKeyDown("space") && (isGrounded() || isWalled()) && onWall == false && wallJumpCount < 1)
        if (Input.GetButtonDown("Jump") && (isGrounded() || isWalled()) && onWall == false && wallJumpCount < 1)
            {
            Vector2 jump;
            if (isWalled())
            {
                Debug.Log("You are hanging on a wall.");
                jump = new Vector2(0, 7);
                wallJumpCount++;
            }
            else
            {
                jump = new Vector2(0, 5);
            }
            rb2d.AddForce(jump, ForceMode2D.Impulse);
        }


        if (rb2d.velocity.y < 0.0f && falling == false && !isGrounded())
        {
            falling = true;
        }

        if (isGrounded())
        {
            falling = false;
        }

        Vector2 movement = new Vector2(moveH, moveV);
        _inertia = movement;

        rb2d.AddForce(movement * speed);


    }

    private void LateUpdate()
    {
        //apex = false;
    }

    private bool isGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(bc2d.bounds.center, Vector2.down, bc2d.bounds.extents.y + extraHeight, platformLayerMask);
        return raycastHit.collider != null;
    }


    private int leftCount = 0;
    private int rightCount = 0;
    private bool isWalled()
    {
        float extraHeight = .1f;
        RaycastHit2D rcHit_L = Physics2D.Raycast(bc2d.bounds.center, Vector2.left, bc2d.bounds.extents.x + extraHeight, platformLayerMask);
        RaycastHit2D rcHit_R = Physics2D.Raycast(bc2d.bounds.center, Vector2.right, bc2d.bounds.extents.x + extraHeight, platformLayerMask);

        if(rcHit_L.collider != null)
        {
            leftCount++;
            //Debug.Log("LEFT WALL HIT " + leftCount.ToString());
        }
        else if (rcHit_R.collider != null)
        {
            rightCount++;
            //Debug.Log("RIGHT WALL HIT " + rightCount.ToString());
        }

        return rcHit_L.collider != null || rcHit_R.collider != null;
    }

    private bool isWall()
    {
        return true;
    }


    public Vector2 _inertia
    {
        get { return inertia; }
        private set { inertia = value; }
    } 

    public bool _isFalling
    {
        get { return falling; }
        set { falling = value; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
    }

}
