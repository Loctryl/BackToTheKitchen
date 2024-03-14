using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CutIngredients : MonoBehaviourPunCallbacks
{
    [SerializeField] private int hitCount = 5;
    [SerializeField] private GameObject slicedObj;
    [SerializeField] private GameObject optionalSecondObj;
    [SerializeField] public int instantiateNumber = 1;
    [SerializeField] public AudioSource ChoppingSound;

    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Destroyer"))
        { 
            photonView.RPC("PlayAudio", RpcTarget.All);
            if (hitCount <= 0)
            {
                for (int i = 0; i < instantiateNumber; i++)
                {
                    GameObject food = PhotonNetwork.Instantiate(slicedObj.name, transform.position, transform.rotation);
                    food.transform.parent = null;
                    if (optionalSecondObj != null)
                    {
                        GameObject food2 = PhotonNetwork.Instantiate(optionalSecondObj.name, transform.position, transform.rotation);
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
    
    [PunRPC]
    void PlayAudio()
    {
        ChoppingSound.Play();
    }
}

