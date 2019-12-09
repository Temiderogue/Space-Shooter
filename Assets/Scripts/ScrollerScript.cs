using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerScript : MonoBehaviour {

    private Vector3 startPosition;
    public float speed;

	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float move = Mathf.Repeat(Time.time * speed, 50);
        transform.position = startPosition + Vector3.back * move;
	}
}
