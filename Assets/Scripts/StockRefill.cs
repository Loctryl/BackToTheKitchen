using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockRefill : MonoBehaviour
{
    [SerializeField] GameObject Food;
    [SerializeField] GameObject AttachPoint;
    [SerializeField] GameObject ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refill()
    {
        GameObject newFood = Instantiate(Food, AttachPoint.transform);
        ParticleSystem.SetActive(true);
    }
}
