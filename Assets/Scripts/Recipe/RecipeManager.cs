using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ingredients;
    [SerializeField] private GameObject _recipePrefab;
    
    private List<Recipe> _recipes;
    
    // Start is called before the first frame update
    void Start()
    {
        _recipes = new List<Recipe>();
        
        CreateRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateRecipe()
    {
        GameObject recipe = Instantiate(_recipePrefab);
        recipe.GetComponent<Recipe>().SetRecipe(_ingredients);
        _recipes.Add(recipe.GetComponent<Recipe>());
    }

    public void ServeDish(GameObject dish)
    {
        bool reciped = false;
        int recipeIndex = 0;
        
        while (!reciped && recipeIndex <= _recipes.Count)
        {
            if (dish.GetComponent<Dish>().GetIngredients() == _recipes[recipeIndex].GetRecipeIngredients())
            {
                reciped = true;
            }
            recipeIndex++;
        }
    }
}
