using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockRefill : MonoBehaviour
{
    [SerializeField] GameObject Food;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newFood = Instantiate(Food);
            other.GetComponent<SimulateRayCast>().SelectedObject = newFood;
        }
    }
}
