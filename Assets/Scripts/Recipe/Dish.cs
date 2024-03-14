using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Dish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<int> GetIngredients()
    {
        List<int> ingredients = new List<int>();
        Sockatable current = gameObject.GetComponent<Sockatable>();
        
        while (current)
        {
            ingredients.Add(current.objectIndex);
            current = current.socketedObj;
        }
        
        return ingredients;
    }

    public void DeletingDish()
    {
        Sockatable current = gameObject.GetComponent<Sockatable>();
        
        while (current)
        {
            Destroy(current.gameObject);
            current = current.socketedObj;
        }
    }
}
