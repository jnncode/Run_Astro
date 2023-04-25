using UnityEngine;
using System.Collections;

public class AstronautPlayer : MonoBehaviour {

	public Animator anim;
	public CharacterController controller;
	private IPlayerAction playerAction; 
	public Vector3 position;
	public float speed = 10.0f;
	public float turnSpeed = 5.0f;
	public Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	void Start () {
		controller = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
		playerAction = new WalkAction(); // default movement strategy
	}

	void Update () {
		if (Input.GetKey("w"))
		{
    		playerAction = new WalkAction();
		}
		else if (Input.GetKey("space"))
		{
    		playerAction = new JumpAction();
		}
		else if (Input.GetKey("left shift"))
		{
    		playerAction = new RunAction();
		}
		else
		{
    		playerAction = null;
			moveDirection = Vector3.zero; 
		}
		if (playerAction != null) {
			playerAction.PerformAction(this);
		}

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
		    SpawnPowerUp(PowerUpType.Shrink);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SpawnPowerUp(PowerUpType.Expand);
		}

		float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
	}

	public void SetAnimation(int animation) {
		anim.SetInteger("AnimationPar", animation);
	}

	public void MoveForward(float distance) {
        if (controller.isGrounded) {
            moveDirection = transform.forward * distance;
        }
    }

    public void MoveUp(float distance) {
        if (controller.isGrounded) {
            moveDirection = transform.up * distance;
        }
    }

    public void Jump(float height) {
        if (controller.isGrounded) {
            moveDirection.y = Mathf.Sqrt(2f * gravity * height);
        }
    }

	public void SpawnPowerUp(PowerUpType type)
	{
		Vector3 position = transform.position + new Vector3(0, 1, 0);
		IPowerUp powerUp = PowerUpFactory.CreatePowerUp(type);
		powerUp.SetPosition(position);
		powerUp.Activate(this);
	}
}
