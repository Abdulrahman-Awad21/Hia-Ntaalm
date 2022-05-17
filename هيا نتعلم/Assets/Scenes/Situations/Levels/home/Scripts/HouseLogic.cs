using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float playerSpeed = 2.0f; //,jump=10f;
    [SerializeField]
    private GameObject bath,room,home,kitchen,boy, popUpMsg,glass,soap,knife,roomS,bathS,kitchenS;

    SpriteRenderer mySprite;
    Rigidbody2D myRB;
    Animator myAnimator;
    bool inPopUp = false;//,isJump=false;
    
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        roomS.SetActive(false);
        bathS.SetActive(false);
        kitchenS.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //player Jump
        /*
        if ((Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.UpArrow)) && isJump == false)
        { 
            myRB.velocity = new Vector2(0, jump);
            isJump = true;
        }
        if (Mathf.Abs(myRB.velocity.y) < 0.001f)
            isJump = false;
        */
        if (!glass.activeInHierarchy && !knife.activeInHierarchy && !soap.activeInHierarchy)
        { 
            inPopUp = false;
            playerSpeed = 2;
        }

    }

    private void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) &&!inPopUp)
        {
            mySprite.flipX = false;
            myAnimator.SetBool("Walking Left", true);
        }
        
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !inPopUp)
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
        if (collision.CompareTag("wall right"))
        { 
            soap.SetActive(true);
            knife.SetActive(true);
            SetSituation();
        }

        else if (collision.CompareTag("glass PopUp"))
        {
            popUpMsg.GetComponent<Animator>().SetTrigger("Popupmsg");
            playerSpeed = 0;
            myAnimator.SetBool("Walking Left", false);
            inPopUp = true;
            if (room.activeInHierarchy)
                roomS.SetActive(true);
            else if (bath.activeInHierarchy)
            {
                roomS.SetActive(false);
                bathS.SetActive(true);
            }
            else if (kitchen.activeInHierarchy)
            {
                bathS.SetActive(false);
                kitchenS.SetActive(true);
            }


            //SceneManager.LoadScene("home");
        }
    }
    
    private void SetSituation() 
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
            SceneManager.LoadScene("home");
        
        boy.transform.position = new Vector2(-1.47f, -0.4865412f);
    }

}
