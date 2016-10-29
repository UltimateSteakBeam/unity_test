using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    //public float xSpeed;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
