using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedEnemyMotion : MonoBehaviour
{

    private static float pi = 3.1415f;
    public float floatSpeed = 1.0f; // control in the prefab pane in Unity Editor
    public float orbitRadius = 1.0f; // floatSpeed and orbitRadius are levers to pull to change path of enemy
    public float leftBound = 0.5f; // multiply by pi to find right bound of circle
    public float rightBound = 1.5f; // multiply by pi to find left bound of circle
    private float _t = pi;
    // determine whether moving left or right (+ or -1)
    private float stepdir = 1.0f;
    
    private Transform _tf;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // snag the transform into tf so we don't repeatedly call getcomponent
        _tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // r(t) = sin(t)i + cos(t)j to draw a circle, so
        // r'(t) = cos(t)i - sin(t)j to move perp to circle
        // Math.Cos()/.Sin() return double so we cast to float
        _tf.position += new Vector3((float)Math.Cos(_t), (float)-Math.Sin(_t), 0) * floatSpeed * stepdir;
        // to create the bottom half of a circle, t oscillates from pi/2 to 3pi/2

        if (_t < pi * leftBound || _t > pi * rightBound)
        {
            stepdir *= -1f;
        }

        _t += orbitRadius * stepdir;

    }
}
