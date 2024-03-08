using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
        GameObject newFood = PhotonNetwork.Instantiate(Food.name, AttachPoint.transform.position, AttachPoint.transform.rotation);
        ParticleSystem.SetActive(true);
    }
}
