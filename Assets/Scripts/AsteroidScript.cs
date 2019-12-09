using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour {

    Rigidbody asteroid;

    public float minSpeed, maxSpeed;
    public float rotationSpeed;
    
    public GameObject AsteroidExplosion;
    public GameController gameController;

    void Start () {
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        asteroid.velocity = Vector3.back * Random.Range(minSpeed,maxSpeed);

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            return;
        }
        else
        {
            gameController.UpdateScore(10);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);

        Instantiate(AsteroidExplosion, other.transform.position, Quaternion.identity);
    }
}
