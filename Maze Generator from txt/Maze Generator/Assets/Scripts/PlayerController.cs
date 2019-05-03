using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField] private float moveSpeed;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	

	void Update () {
        float horiz = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(horiz * moveSpeed, rb.velocity.y, 0f);
        float vert = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(rb.velocity.x, vert * moveSpeed, 0f);
	}
}
