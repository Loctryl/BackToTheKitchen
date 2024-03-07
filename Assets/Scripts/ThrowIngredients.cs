using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowIngredients : MonoBehaviour
{

    [SerializeField] private GameObject _particleSystem;
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
            Destroy(other.gameObject);
            _particleSystem.SetActive(true);
        }
    }
}
