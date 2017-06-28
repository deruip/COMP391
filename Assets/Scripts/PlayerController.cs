using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;

}
public class PlayerController : MonoBehaviour
{
    // Public Variables
    public float speed;
    public Boundary boundary;
    public Transform laserSpawn;
    public GameObject laser;
    public float fireDelta = 0.5f;

    // Private Variables
    Rigidbody2D rBody;
    private float nextFire = 0.5F;
    private float myTime = 0.5f;

    // Use this for initialization
    void Start()
    {
        rBody = this.GetComponent<Rigidbody2D>(); // Creating a reference to THIS rigidbody2D
    }
    // Used for Physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rBody.velocity = movement * speed;

        rBody.position = new Vector2(                                            // Creating a new Vector2 object
            Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax),         // Restricting X to xMin and xMax
            Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax));        // Restricting Y to yMin and yMax
    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;
        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            // Creating a laser at laserSpawn's position and rotation
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);

            nextFire = nextFire - myTime;
            myTime = 0.0f;
        }
    }
}
