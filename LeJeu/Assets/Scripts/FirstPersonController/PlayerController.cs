using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private InputManager inputManager;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;
    private Animator animator;

    int isWalkinghash;
    int Jumpinghash;
    int isGroundedhash;
    int isInAirhash;



    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>();

        isWalkinghash = Animator.StringToHash("isWalking");
        Jumpinghash = Animator.StringToHash("Jumping");
        isGroundedhash = Animator.StringToHash("isGrounded");
        isInAirhash = Animator.StringToHash("isInAir");
    }


    void Update()
    {
        groundedPlayer = controller.isGrounded;
        animator.SetBool(isGroundedhash, controller.isGrounded);

        if (groundedPlayer)
        {
            animator.SetBool(isInAirhash, false);
        }

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x , 0 , movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);


        // Changes the height position of the player..
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            animator.SetBool(Jumpinghash , true);
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        if (!groundedPlayer)
        {
            animator.SetBool(isInAirhash, true);
            animator.SetBool(Jumpinghash, false);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
    }
}
