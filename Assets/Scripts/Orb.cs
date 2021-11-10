using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    
    /*
    TODO
    delete when offscreen
    collision with player
    */

    public string playerName;
    private GameObject player;
    private Transform _tf;
    private Transform _plrtf;
    private Rigidbody2D _rb;
    private Vector2 dir;
    
    void Start()
    {
        player = GameObject.Find(playerName);
        
        _rb = GetComponent<Rigidbody2D>();
        _tf = GetComponent<Transform>();
        _plrtf = player.GetComponent<Transform>(); // get transform from player

        dir = _plrtf.position - _tf.position;
    }

    void Update()
    {
        _rb.AddForce(dir);
    }
}
