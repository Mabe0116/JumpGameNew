using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public bool isBlock = true;
    public GameObject bombParticle;
    private AudioSource audioSource;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        const float moveSpeed  = 1.0f;
        const float moveJump = 4.0f;

        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);

        Ray ray = new Ray(rayPosition, Vector3.down);

        float distance = 0.9f;

        isBlock = Physics.Raycast(ray, distance);

        //UnitychanˆÚ“®
        if(Input.GetKey(KeyCode.UpArrow) )
        {
            Vector3 velocity = new Vector3(0, 0, 0.02f);
            transform.position += transform.rotation * velocity;
        }
        

        if(Input.GetKey(KeyCode.RightArrow) )
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }


        if (isBlock == true)
        {
            Debug.DrawRay(rayPosition,Vector3.down * distance, Color.red);
            animator.SetBool("jump", false);
        }
        else
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
            animator.SetBool("jump", true);
        }

        Vector3 v = rb.velocity;
        float stick  = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow) || stick > 0)
        {
            v.x = moveSpeed;
            animator.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || stick < 0) 
        {
            v.x = -moveSpeed;
            animator.SetBool("Walk", true);
        }
        else
        {
            v.x = 0;
            animator.SetBool("Walk", false); 
        }

        if(UnityEngine.Input.GetButton("Jump") || UnityEngine.Input.GetKey(KeyCode.Space))
        {
            if(isBlock == true)
            {
                v.y = moveJump;
            }
        }
        rb.velocity = v;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
            Instantiate(bombParticle,transform.position, Quaternion.identity);
        }
    }
}
