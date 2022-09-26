using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance;

    //Movement controls
    public InputMaster controls;
    Vector2 move;
    Vector2 rotation;
    private float walkSpeed = 5f;

    //Player Jump
    Rigidbody rb;
    float distanceToGround;
    private bool isGrounded = true;
    public Camera playerCamera;
    Vector3 cameraRotation;
    public float jump = 25f;

    //Player Animation
    Animator playerAnimator;
    Animation anim;
    bool isWalking;

    //Projectiles
    public GameObject bullet;
    public Transform projectilePos;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

        controls = new InputMaster();

        controls.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        controls.Player.Move.canceled += cntxt => move = Vector2.zero;

        controls.Player.Jump.performed += cntxt => Jump();
        controls.Player.Shoot.performed += cntxt => Shoot();


        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }
    }
    public void Shoot()
    {
        Rigidbody bulletRb = Instantiate(bullet, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);
    }

    
}
