using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If we click the left mouse button.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the ,ouse position and shoot a ray from it.
            Vector2 world_point = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(world_point, Vector2.zero);

            //if something was hit...
            if (hit.collider != null)
            {
               //Destroy the game object.
               Destroy(hit.collider.gameObject);

            }
        }
    }
}
