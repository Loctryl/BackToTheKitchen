using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private RecipeManager recipeManager;
    [SerializeField] private float timeToServe;
    private float _timeOnBar;
    private bool _isDishOnBar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // on socket enter
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dishes"))
        {
            
        }
    }

    // on socket stay
    private void OnTriggerStay(Collider other)
    {
        if (_isDishOnBar)
        {
            _timeOnBar += Time.deltaTime;
            if (_timeOnBar >= timeToServe)
            {
                recipeManager.ServeDish(other.gameObject);
                _timeOnBar = 0;
                Destroy(other.gameObject);
            }
        }
    }
}
