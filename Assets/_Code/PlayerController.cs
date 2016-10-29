using UnityEngine;
using System.Collections;

[System.Serializable]
public class Bounds
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    public float tilt;
    public Bounds bounds;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.3f;

    float nextFire;

	void FixedUpdate()
    {
        float mHorizontal = Input.GetAxis("Horizontal");
        float mVertical = Input.GetAxis("Vertical");

        rb = GetComponent<Rigidbody>();

        Vector3 movement = new Vector3(mHorizontal, mVertical, 0.0f);
        rb.velocity = movement * speed;
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, bounds.xMin, bounds.xMax),
                Mathf.Clamp(rb.position.y, bounds.yMin, bounds.yMax),
                0.0f
            );
        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
