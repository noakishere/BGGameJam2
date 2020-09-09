using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    private Vector2 targetPos; //for the vertical movement

    public float Yincrement = 2f;
    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;
    public int slowTimer = 100; //a changer

    public bool isImmune;
    public bool isSlow;
    public bool isFF;

    public GameObject effect; //Particle Effect
    public GameObject gameOver; //Game Over Text variable
    public GameObject announcer; //Announcer section
    public Text announcerText;

    Animator myAnimator; 

    private void Start()
    {
        //necessary cuz the player messes with this variable a lot !
        //at the start of the level you'll decide where your player want to player
        targetPos = transform.position; 
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GetImmune();
        SlowDownTimer();
        SlowDown();
        FastForward();
    }


    void Move()
    {
        /*
        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");

        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * 10f);
        myRigidBody.velocity = climbVelocity; */

        //Need to be changed with CrossPlatformInput possibly??
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)
            && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)
            && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
        
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime); //Move smoothly 

        if (targetPos.y > 2)
            targetPos.y = 2;
        else if (targetPos.y < -4)
            targetPos.y = -4;
    }

    public void GetImmune()
    {
        //Check ImmuneObject script
        if(isImmune)
            StartCoroutine(ImmunityTimer());
        else
            StopAllCoroutines();
    }

    IEnumerator ImmunityTimer()
    {
        isImmune = true;
        myAnimator.SetBool("isImmune", true);
        announcerText.text = "Youre Immune Now!!!";
        announcer.SetActive(true);
        yield return new WaitForSeconds(4f);
        isImmune = false;
        myAnimator.SetBool("isImmune", false);
        announcer.SetActive(false);
        Debug.Log("HI");
    }

    
    public void SlowDown() //REMOVE THIS
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSlow)
        {
            isSlow = true;
        }
    } 

    public void SlowDownTimer()
    {
        if(isSlow)
        {
            announcerText.text = "Slow Time Now!!!";
            announcer.SetActive(true);
            slowTimer--;
            Time.timeScale = 0.5f;

            if (slowTimer == 0)
            {
                isSlow = false;
                announcer.SetActive(false);
                Time.timeScale = 1.00f;
                slowTimer = 100;
            }       
        }   
    }

    /*
    public void DoDo() //REMOVE THIS
    {
        if (Input.GetKeyDown(KeyCode.A) && !isFF)
        {
            isFF = true;
        }
    }
    */

    public void FastForward()
    {
        if (isFF)
        {
            StartCoroutine(ImmunityTimer());
            announcerText.text = "Fast Forward!!!";
            announcer.SetActive(true);
            slowTimer--;
            Time.timeScale = 10f;

            if (slowTimer == 0)
            {
                isFF = false;
                announcer.SetActive(false);
                Time.timeScale = 1.00f;
                slowTimer = 100;
            }
        }
    }
}
