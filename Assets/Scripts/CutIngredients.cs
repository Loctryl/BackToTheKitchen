using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutIngredients : MonoBehaviour
{
    [SerializeField] private int hitCount = 5;
    [SerializeField] private GameObject slicedObj;
    [SerializeField] public int instantiateNumber = 1;
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
            Debug.Log("bing");
            if (hitCount <= 0)
            {
                Debug.Log("bong");
                for (int i = 0; i < instantiateNumber; i++)
                {
                    GameObject lettuce = Instantiate(slicedObj, transform);
                    lettuce.transform.parent = null;
                }
                Destroy(gameObject);
            }
            else
            {
                hitCount--;
            }
        }
    }
}
