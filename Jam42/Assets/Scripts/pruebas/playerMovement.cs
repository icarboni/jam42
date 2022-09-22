using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D playerRB;
    public float speed = 20;
    public float jump = 60f;
    public bool isJumping = false;
    private float moveHorizontal;
    private float moveVertical;
    public float lenghtRaycast = 1;
    public LayerMask groundMask;
    public bool stunned = false;
    public float jumpHeight = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (stunned == false)
        {
            move();
        }
        PlayerAnimations();
        Debug.DrawRay(transform.localPosition, Vector2.down * lenghtRaycast, Color.green);
    }

    private void move()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() == true)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpHeight);
            StartCoroutine(ResetJump());
        }
        playerRB.velocity += Vector2.right * speed * moveHorizontal * Time.deltaTime;
    }

    private bool isGrounded()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down * lenghtRaycast, 1.5f, 1 << 6);
        if (hitinfo.collider != null)
        {
            Debug.Log("Hit: " + hitinfo.collider.name);
            if (isJumping == false)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator ResetJump()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
    }

    public void PlayerAnimations()
    {
        anim.SetFloat("walkVelocity", playerRB.velocity.x);
        anim.SetBool("IsStunned", stunned);
    }
    
}
