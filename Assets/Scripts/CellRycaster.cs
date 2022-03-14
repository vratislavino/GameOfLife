using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellRycaster : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 1000))
            {
                var cell = hit.collider.GetComponentInParent<Cell>();
                if(cell != null)
                {
                    cell.IsAlive = !cell.IsAlive;
                }
            }
        }
    }
}
