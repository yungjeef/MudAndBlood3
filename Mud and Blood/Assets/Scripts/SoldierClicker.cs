using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierClicker : MonoBehaviour
{

    public SoldierMovement selectedSoldier;
    bool soldierSelected;
    Vector2 lastClickedPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!soldierSelected) {
            MouseInput();
        }
            
        if(Input.GetMouseButtonDown(1) && !selectedSoldier.moving) {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(soldierSelected && (Vector2)selectedSoldier.transform.position != lastClickedPos) {
            float step = selectedSoldier.moveSpeed * Time.deltaTime;
            selectedSoldier.transform.position = Vector2.MoveTowards(selectedSoldier.transform.position, lastClickedPos, step);
        } else {
            soldierSelected = false;
        }
    }

    void MouseInput() {
        if(Input.GetMouseButtonDown(0)) {
            Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

            if(hit.collider) {
                Debug.Log(hit.transform.gameObject);
                selectedSoldier = hit.transform.gameObject.GetComponent<SoldierMovement>();
                soldierSelected = true;
            }
        }
    }
}
