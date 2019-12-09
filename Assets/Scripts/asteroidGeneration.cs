using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidGeneration : MonoBehaviour {

    public GameObject Asteroid;

    public float minDelay, maxDelay;

    private float nextLaunch;
	void Update () {


        if (Time.time > nextLaunch)
        {
            float positionZ = transform.position.z;
            float positionY = transform.position.y;
            float positionX = Random.Range(-transform.localScale.x /2, transform.localScale.x / 2);

            var position = new Vector3(positionX, positionY, positionZ);

            Instantiate(Asteroid, position, Quaternion.identity);

            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);
        }
	}
}
