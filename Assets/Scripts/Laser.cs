using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public float speed;
	void Start () {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;		
	}

}
