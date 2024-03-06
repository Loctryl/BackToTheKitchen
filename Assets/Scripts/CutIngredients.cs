using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutIngredients : MonoBehaviour
{
    [SerializeField] private int hitCount = 5;
    [SerializeField] private GameObject slicedObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Destroyer"))
        {
            if (hitCount <= 0)
            {
                Debug.Log("bing");
                Instantiate(slicedObj);
                Destroy(gameObject);
            }
            else
            {
                hitCount--;
            }
        }
    }
}
