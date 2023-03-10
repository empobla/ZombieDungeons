/*
This script was download from https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-for-unity-2017-3-32351
It controlls the movement of the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private CharacterController characterController;
	private Animator animator;

	[SerializeField]
	private float moveSpeed = 100;
	[SerializeField]
	private float turnSpeed = 5f;

	private void Awake()
	{
		characterController = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");

		var movement = new Vector3(horizontal, 0, vertical);

		characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

		animator.SetFloat("Speed", movement.magnitude);

		if (movement.magnitude > 0)
		{
			Quaternion newDirection = Quaternion.LookRotation(movement);

			transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
		}
	}
}