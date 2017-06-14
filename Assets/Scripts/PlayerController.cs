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

    // Private Variables
    Rigidbody2D rBody;

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

    }
}
