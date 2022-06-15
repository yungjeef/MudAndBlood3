using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    Vector2 lastClickedPos;

    bool soldierSelected;
    bool moving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
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

    void MouseInput() {
        if(Input.GetMouseButtonDown(0)) {
            Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

            if(hit.collider != null) {
                soldierSelected = true;
            }
        }
    }
}
