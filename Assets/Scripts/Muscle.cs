using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Muscle : MonoBehaviour
{
    public  Bone          fromBone;
    public  Bone          toBone;
    public  float         frequency;
    private LineRenderer  _lineRenderer;
    private SpringJoint2D _spring;

    private void Start()
    {
        _lineRenderer                        = transform.GetComponent<LineRenderer>();
        
        _spring                              = fromBone.gameObject.AddComponent<SpringJoint2D>();
        _spring.connectedBody                = toBone.GetComponent<Rigidbody2D>();
        _spring.autoConfigureConnectedAnchor = false;
        _spring.anchor                       = Vector2.zero;
        _spring.connectedAnchor              = Vector2.zero;
        _spring.frequency                    = frequency;
        _spring.autoConfigureDistance        = false;
    }

    private void Update()
    {
        _lineRenderer.SetPosition(0, fromBone.transform.position);
        _lineRenderer.SetPosition(1, toBone.transform.position);
    }
}
