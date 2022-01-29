using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Vector2 mousePosition;
    private TrailRenderer trailRenderer;


    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }


    void RemoveTrail()
    {
        var trail = GetComponent<TrailRenderer>();
        trail.Clear();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
        }
    }
}
