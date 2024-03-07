using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    private List<int> _ingredients;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<int> GetIngredients() { return _ingredients; }

    void PlaceIngredient(GameObject ing)
    {
        if (ing.CompareTag("Ingredients"))
        {
            Debug.Log("Place ingredient on dish");
        }
    }
}
