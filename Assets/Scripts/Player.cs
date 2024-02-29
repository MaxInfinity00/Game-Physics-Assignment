using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    
    bool isLookingRight = true;
    bool isGrappled = false;

    private Vector2 GrappleAnchorPosition;
    
    [FormerlySerializedAs("GrappleDistance")] public float grappleDistance = 10;
    
    private Rigidbody2D rb;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        GrappleAnchorPosition = new Vector2(0, 0);
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrappled)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, GrappleAnchorPosition);
        }
    }
    
    public void PressedLeft()
    {
        Debug.Log("A key was pressed");
        isLookingRight = false;
    }
    
    public void PressedRight()
    {
        Debug.Log("D key was pressed");
        isLookingRight = true;
    }

    public void PressedSpace()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, ((isLookingRight?Vector2.right:Vector2.left) + Vector2.up).normalized, grappleDistance);
        if (hit.collider.GetComponent<Platform>())
        {
            Debug.Log("Hit something " + hit.collider.name + " " + hit.point);
            GrappleAnchorPosition = hit.point;
            isGrappled = true;
            lineRenderer.enabled = true;
        }
        else
        {
            Debug.Log("Did not hit anything");
            isGrappled = false;
            lineRenderer.enabled = false;
        }
    }
    
    public void ReleasedSpace()
    {
        Debug.Log("Space was released");
        isGrappled = false;
        lineRenderer.enabled = false;
    }
    
    private void FixedUpdate()
    {
        if (isGrappled)
        {
            Vector2 direction = GrappleAnchorPosition - (Vector2)transform.position;
            rb.AddForce(direction.normalized * 20);
            // Vector3 direction;
            // if (isLookingRight)
            // {
            //     direction = Vector3.Cross(Vector3.back, GrappleAnchorPosition - (Vector2)transform.position);
            // }
            // else
            // {
            //     direction = Vector3.Cross(Vector3.forward, GrappleAnchorPosition - (Vector2)transform.position);
            // }
            // rb.AddForce(direction.normalized * 20);
        }
    }

}
