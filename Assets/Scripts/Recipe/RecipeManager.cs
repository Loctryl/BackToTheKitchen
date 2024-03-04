using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ingredients;
    
    private List<List<int>> _recipes;
    
    // Start is called before the first frame update
    void Start()
    {
        _recipes = new List<List<int>>();
        
        CreateRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateRecipe()
    {
        List<int> recipe = new List<int>();
        
        recipe.Add(0);

        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            recipe.Add(Random.Range(1, _ingredients.Count-1));
        }
        
        recipe.Add(0);
        
        _recipes.Add(recipe);
    }
}
