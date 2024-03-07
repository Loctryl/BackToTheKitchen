using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    private List<int> _recipe;

    private float _timeToServe;
    
    // Start is called before the first frame update
    void Start()
    {
        _timeToServe = Random.Range(180.0f, 360.0f);
    }

    // Update is called once per frame
    void Update()
    {
        _timeToServe -= Time.deltaTime;

        if (_timeToServe <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetRecipe(List<GameObject> ingredients)
    {
        List<int> recipe = new List<int>();
        
        recipe.Add(0);

        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            recipe.Add(Random.Range(1, ingredients.Count-1));
        }
        
        recipe.Add(0);
    }
    
    public List<int> GetRecipeIngredients() { return _recipe; }

}
