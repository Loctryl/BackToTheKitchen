using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateRayCast : MonoBehaviour
{
    public GameObject SelectedObject;
    public bool OnStock = false;

    private Vector3 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane + 10;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPosition;

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Mouse0) && other.tag == "MovableObj")
        {
            SelectedObject = other.gameObject;
            SelectedObject.transform.position = worldPosition;
        }
    }
}


