using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public float RotationMultiplier = 1f;
    float m_CameraVerticalAngle = 0f;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    public Camera PlayerCamera;
    public float killHeight;
    public GameManager gameManager;
    bool mayMove = false;
    bool onGround, onWall;
    Animator animator;
    public UIGameCanvas gameCanvas;
    int pickups = 0;
    public static event Action cubesCollected, crossDoor;


    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        onWall = false;
        animator = GetComponent<Animator>();
        characterController = this.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.changePositionPlayer += SpawningPlayer;
    }
    private void FixedUpdate()
    {
        if (mayMove)
        {
            CharacterRotation();
            CharacterMovement();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    void CharacterMovement()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void CharacterRotation()
    {
        {
            transform.Rotate(
                new Vector3(0f, (Input.GetAxis("Mouse X") * rotationSpeed * RotationMultiplier),
                    0f), Space.Self);
        }
        {
            m_CameraVerticalAngle += Input.GetAxis("Mouse Y") * -1 * rotationSpeed * RotationMultiplier;
            m_CameraVerticalAngle = Mathf.Clamp(m_CameraVerticalAngle, -89f, 89f);
            PlayerCamera.transform.localEulerAngles = new Vector3(m_CameraVerticalAngle, 0, 0);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recollectable")
        {
            PickUp(other.gameObject.transform.parent);
        }
        if (other.gameObject.tag == "Puerta")
        {
            //gameManager.ChangeMaze();
            if (crossDoor != null)
            {
                crossDoor();
            }
        }
    }

    void PickUp(Transform parent)
    {
        parent.gameObject.GetComponent<Animator>().enabled = false;
        parent.gameObject.GetComponent<Light>().enabled = false;
        for (int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).gameObject.tag == "Recollectable")
            {
                parent.GetChild(i).gameObject.tag = "Untagged";
                parent.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                parent.GetChild(i).GetComponent<BoxCollider>().isTrigger = false;
            }
        }
        pickups++;
        PickupMessageUI();
        CheckGameGoal();
        parent.gameObject.GetComponent<PickupManager>().DestroyPickup();
    }

    void PickupMessageUI()
    {
        gameCanvas.UpdateCubeCounterText(pickups);
        gameCanvas.UpdateMessageText(pickups);
    }

    void CheckGameGoal()
    {
        if (pickups >= 4)
        {
            Debug.Log("Abriendo puertas");
            if (cubesCollected != null)
            {
                cubesCollected();
            }
            //gameManager.OpenDoor();
            pickups = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Aun en desarrollo
        if (collision.gameObject.tag == "Ground")
        {
            if (collision.gameObject.transform.parent.gameObject.tag == "Wall")
            {
                onWall = false;
                PlayAnimation("Climbing", false);
            }
            PlayAnimation("Jumping", false);
            onGround = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //En desarrollo
        if (collision.gameObject.tag == "Wall")
        {
            onGround = false;
            onWall = true;
        }
    }

    void PlayAnimation(string animName, bool status)
    {
        animator.SetBool(animName, status);
    }

    void SpawningPlayer(Vector3 pos)
    {
        StartCoroutine(SpawnPlayer(pos));
    }

    public IEnumerator SpawnPlayer(Vector3 position)
    {
        gameCanvas.UpdateCubeCounterText(0);
        mayMove = false;
        transform.position = position;
        yield return new WaitForSeconds(1);
        mayMove = true;
    }
}
