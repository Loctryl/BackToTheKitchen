using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowIngredients : MonoBehaviour
{
    [SerializeField] private GameObject particuleSystem;
    [SerializeField] private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredients") || other.CompareTag("RawSteak") || other.CompareTag("Flame"))
        {
            Destroy(other.gameObject);
            particuleSystem.SetActive(true);
        }
    }
}
