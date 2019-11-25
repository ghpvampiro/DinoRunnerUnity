using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetAnimaY : MonoBehaviour {
	public float scrollSpeed = 0.5F;
	public Renderer rend;
	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		float offsetX = Time.time * scrollSpeed;
		float offsetY = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
	}
}