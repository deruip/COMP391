using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    // Public variables
    public float speed;
    
    // Private variables
    private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();
        rBody.velocity = this.transform.right * speed;
	}
}
