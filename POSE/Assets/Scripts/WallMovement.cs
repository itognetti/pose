using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float speed = 2.0f;
    private GameObject player;
    private bool pushingPlayer = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        transform.position = transform.position + speed * Time.deltaTime * Vector3.right;
        if(pushingPlayer)
            player.transform.position = player.transform.position + speed * Time.deltaTime * Vector3.right;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Body")){
            pushingPlayer = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Body")){
            pushingPlayer = false;
        }
    }

    void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

}
