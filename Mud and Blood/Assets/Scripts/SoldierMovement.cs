using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    Vector2 lastClickedPos;

    public CircleCollider2D soldierCircle;

    bool soldierSelected;
    public bool moving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(soldierSelected && Input.GetMouseButtonDown(1)) {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if(moving && (Vector2)transform.position != lastClickedPos) {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
        } else {
            moving = false;
        }

        if(Input.GetMouseButtonUp(1)) {
            soldierSelected = false;
        }
    }

    public void Move(Vector2 pos) {
        if((Vector2)transform.position != pos) {
            print("visited");
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
        }

        //if(moving && (Vector2)transform.position != lastClickedPos) {
        //    float step = moveSpeed * Time.deltaTime;
        //    transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
        //} else {
        //    moving = false;
        //}
    }

    
}
