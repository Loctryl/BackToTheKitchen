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

        if (SelectedObject != null)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                SelectedObject.transform.position = worldPosition;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredients"))
        {
            SelectedObject = other.gameObject;
            Debug.Log("grabbing");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SelectedObject = null;
    }
}


