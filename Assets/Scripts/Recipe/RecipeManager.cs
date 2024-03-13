using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> ingredients;
    [SerializeField] private GameObject recipePrefab;
    [SerializeField] private GameObject recipeDisplay;
    
    private List<Recipe> _recipes;
    [SerializeField] private float timeBetweenRecipes = 60.0f;
    private float _elapsedTime;


    [HideInInspector] public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        _recipes = new List<Recipe>();
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= timeBetweenRecipes && _recipes.Count < 4)
        {
            _elapsedTime = 0;
            CreateRecipe();
        }
    }

    void CreateRecipe()
    {
        //GameObject recipe = Instantiate(recipePrefab, recipeDisplay.transform);
        GameObject recipe = PhotonNetwork.Instantiate(recipePrefab.name, recipeDisplay.transform.position, Quaternion.identity);
        recipe.transform.SetParent(recipeDisplay.transform);
        recipe.transform.localRotation = Quaternion.identity;
        recipe.transform.localScale = Vector3.one;
        recipe.GetComponent<Recipe>().SetRecipe(ingredients);
        _recipes.Add(recipe.GetComponent<Recipe>());
    }

    public void ServeDish(GameObject dish)
    {
        int recipeIndex = 0;
        List<int> meal = dish.GetComponent<Dish>().GetIngredients();
        Debug.Log("Serve me");
        
        while (recipeIndex <= _recipes.Count)
        {
            if (meal == _recipes[recipeIndex].GetRecipeIngredients())
            {
                Debug.Log("Feat recipe");
                Destroy(_recipes[recipeIndex].gameObject);
                _recipes.Remove(_recipes[recipeIndex]);
                score += 50;
                return;
            }
            recipeIndex++;
        }
        score -= 50;
    }
}
