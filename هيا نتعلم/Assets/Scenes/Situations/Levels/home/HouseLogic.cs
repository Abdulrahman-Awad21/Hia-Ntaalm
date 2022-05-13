using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private GameObject bath,room,home,kitchen,boy;

    SpriteRenderer mySprite;
    Rigidbody2D myRB;
    Animator myAnimator;

    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            mySprite.flipX = false;
            myAnimator.SetBool("Walking Left", true);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            mySprite.flipX = true;
            myAnimator.SetBool("Walking Left", true);
        }
        else
            myAnimator.SetBool("Walking Left", false);

        myRB.velocity = new Vector2(playerSpeed * Input.GetAxis("Horizontal"), myRB.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check
        //if enemy then health-1 collision.comparetag
        if (collision.CompareTag("wall right"))
        {
            if (room.activeInHierarchy)
            {
                room.SetActive(false);
                bath.SetActive(true);
            }
            else if (bath.activeInHierarchy)
            {
                bath.SetActive(false);
                kitchen.SetActive(true);
            }
            else if (kitchen.activeInHierarchy)
            {
                kitchen.SetActive(false);
                home.SetActive(true);
                boy.SetActive(false);
            }
            boy.transform.position = new Vector2(-1.47f, -0.4865412f);
        }

    }


}
