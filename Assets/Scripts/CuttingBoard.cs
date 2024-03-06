using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    [SerializeField] private int multiplicator = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredients"))
        {
            Debug.Log("oui");
            other.GetComponent<CutIngredients>().instantiateNumber = multiplicator;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ingredients"))
        {
            other.GetComponent<CutIngredients>().instantiateNumber = 1;
        }
    }
}
