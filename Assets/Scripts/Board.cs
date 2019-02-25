using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

	public static float spacing = 2f;
	public static Vector2[] directions = {
		new Vector2(spacing, 0f),
		new Vector2(-spacing, 0f),
		new Vector2(0f, spacing),
		new Vector2(0f, -spacing)
	};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
