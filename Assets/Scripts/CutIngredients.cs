using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CutIngredients : MonoBehaviour
{
    [SerializeField] private int hitCount = 5;
    [SerializeField] private GameObject slicedObj;
    [SerializeField] private GameObject optionalSecondObj;
    [SerializeField] public int instantiateNumber = 1;

    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        photonView.OwnershipTransfer = OwnershipOption.Takeover;
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
                for (int i = 0; i < instantiateNumber; i++)
                {
                    GameObject food = Instantiate(slicedObj, transform);
                    food.transform.parent = null;
                    if (optionalSecondObj != null)
                    {
                        GameObject food2 = Instantiate(optionalSecondObj, transform);
                        food2.transform.parent = null;
                    }
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
