using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private bool isAlive;
    private Animator animator;

    private float currentColorShade = 255;
    private Material material;

    public bool IsAlive
    {
        get { return isAlive; }
        set { 
            isAlive = value;
            // (1,0,0) + (0,0,1) -> (1,0,1) * 0.9 => 0.9, 0, 0.9
            if (!isAlive)
            {
                //animator.SetTrigger("Died");
                transform.localScale = (Vector3.right + Vector3.forward) * 0.9f + Vector3.up * 0.1f;
            }
            else
            {
                //animator.SetTrigger("CameToLife");
                currentColorShade = 255;
                transform.localScale = Vector3.one * 0.9f;
            }
        }
    }

    public bool WillBeAlive;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        material = GetComponentInChildren<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ApplyState()
    {
        IsAlive = WillBeAlive;
    }

    private void Update()
    {
        if (!isAlive)
        {
            currentColorShade -= 50 * Time.deltaTime;
        }
        material.color = new Color(currentColorShade/255, currentColorShade/255, currentColorShade/255);
    }

}
