using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Tilemaps.Tilemap;
using UnityEngine.EventSystems;
using System.Threading;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float speed = 10f; //een variable die comma getalle opslaat
    public float jumpforce = 60f;
    [SerializeField] LayerMask Ground;
    Vector3 moveDirection;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    public float grounddrag = 0f;
    public float playerHeight;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //ground = 1 << 3; // plek van de niuewe layer
        rb.freezeRotation = true;
       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float inptX = Input.GetAxis("Vertical"); //pakt de toets waarde voor een horizontale input
        //rb.velocity = new Vector3(inptX * speed, rb.velocity.y);
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, Ground);
        if (grounded)
        {
           
            rb.drag = 0.1f;
        }
        else
        {
            rb.drag = 0.6f;
        }
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //float inptY = Input.GetAxis("Horizontal"); //pakt de toets waarde voor een horizontale input
        //rb.velocity = new Vector3(inptY * speed,rb.velocity.y, rb.velocity.x);
        if (Input.GetButton("Horizontal"))
        {
            MovePlayer();

        }
        else if (Input.GetButton("Vertical"))

        {
            MovePlayer();
        }
        if (Input.GetButton("Jump")) // als button jump wordt ingedrukt doe dit
        {
            Jump(); // roept een method op

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = +30f;
        }
        else
        {
            speed = 15f;

            if (speed >= 15)
            {
                speed = 15;
            }
        }
    }
    public void Jump()
    {
        RaycastHit hit;
        // maakt de lijn aan die detecteerd waneer je de vloer raakt
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.green);

        if (Physics.Raycast(transform.position, Vector2.down, out hit, 1.3f, Ground))
        {
            rb.AddForce(transform.up * jumpforce * 0.5f, ForceMode.Force); //bepaald de jump hoogte
             
        }
      
        
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
    }

}