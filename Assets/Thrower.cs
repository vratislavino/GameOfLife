using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    Rotator rotator;
    [SerializeField]
    public Rigidbody objPrefab;
    private Rigidbody current;

    [SerializeField]
    private Transform spawnPoint;
    private float force = 100;

    bool thrown = false;
    // Start is called before the first frame update
    void Start()
    {
        rotator = GetComponent<Rotator>();
        CreateObj();
    }

    void CreateObj()
    {
        current = Instantiate(objPrefab, spawnPoint.position, spawnPoint.rotation);
        current.transform.SetParent(transform);
        current.isKinematic = true;
        current.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!thrown)
            {
                Throw();
                thrown = true;
            }
            else
            {
                thrown = false;
                CreateObj();
                rotator.rotate = true;
            }
        }
    }

    private void Throw()
    {
        rotator.rotate = false;
        current.isKinematic = false;
        current.useGravity = true;
        current.AddForce(transform.forward * force + transform.up * force, ForceMode.Impulse);
        current.transform.SetParent(null);
    }
}
