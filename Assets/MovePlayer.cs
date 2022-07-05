using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController characterController;
    public PlayerLogic _PlayerLogic;

    /// <summary>
    /// https://youtu.be/_QajrabyTJc
    /// 
    /// Teljes Kod
    /// </summary>

    //gravity variables
    [Header("Gravity")]
    Vector3 velocity;
    public float gravity = -9.8f;
    public Transform GroundCheckerObject;
    public float groundDistance = .4f;
    public LayerMask groundmask;

    private bool isGrounded;


    [Header("Character Speed")] 
    public float speed;

    [Header("Jump")]
    public float jumpHeight = 3f; 

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        _PlayerLogic = GetComponent<PlayerLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = GetComponent<PlayerLogic>()._move_speed;
        
        isGrounded = Physics.CheckSphere(GroundCheckerObject.position, groundDistance, groundmask); //check if it hit anything (its on ground) 

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z ;

        if(!_PlayerLogic.is_sitting)
            characterController.Move(move * speed * Time.deltaTime);


        //gravity

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);


        // JUMP

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //strange formula
        }
    }
}
