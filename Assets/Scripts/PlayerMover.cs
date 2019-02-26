﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public Vector3 destination;
	public bool isMoving = false;
	public iTween.EaseType easeType = iTween.EaseType.easeInOutExpo;

	public float moveSpeed = 1.5f;
	public float iTweenDelay = 0f;
	Board m_board;

	// Use this for initialization
	void Awake () {
		m_board = Object.FindObjectOfType<Board>().GetComponent<Board>();
	}
	
	public void Move(Vector3 destinationPos, float delayTime = 0.25f) {
		if (m_board != null) {
			Debug.Log(destinationPos);
			Node targetNode = m_board.FindNodeAt(destinationPos);
			if (targetNode != null) {
				StartCoroutine(MoveRoutine(destinationPos, delayTime));
			} else {
				Debug.Log("Invalid move");
			}
		} else {
			Debug.Log("No board");
		}
	}

	IEnumerator MoveRoutine(Vector3 destinationPos, float delayTime) {
		isMoving = true;
		destination = destinationPos;
		yield return new WaitForSeconds(delayTime);
		iTween.MoveTo(gameObject, iTween.Hash(
			"x", destinationPos.x,
			"y", destinationPos.y,
			"z", destinationPos.z,
			"delay", iTweenDelay,
			"easetype", easeType,
			"speed", moveSpeed
		));
		while(Vector3.Distance(destinationPos, transform.position) > 0.01f) {
			yield return null;
		}
		iTween.Stop(gameObject);
		transform.position = destinationPos;
		isMoving = false;
	}

	public void MoveLeft() {
		Vector3 newPosition = transform.position + new Vector3(-Board.spacing,0f,0f);
		Move(newPosition,0);
	}

	public void MoveRight() {
		Vector3 newPosition = transform.position + new Vector3(Board.spacing,0f,0f);
		Move(newPosition,0);
	}

	public void MoveForward() {
		Vector3 newPosition = transform.position + new Vector3(0f,0f,Board.spacing);
		Move(newPosition,0);
	}

	public void MoveBackward() {
		Vector3 newPosition = transform.position + new Vector3(0f,0f,-Board.spacing);
		Move(newPosition,0);
	}
}
