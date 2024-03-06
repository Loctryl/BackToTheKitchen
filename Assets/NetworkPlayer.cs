using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{



    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public PhotonView photonView;


    public Transform XRHead { get; set; }
    public Transform XRleftHand { get; set; }
    public Transform XRrightHand { get; set; }

    // Start is called before the first frame update
    void Start()
    {
       photonView = GetComponent<PhotonView>();

        rightHand.gameObject.SetActive(true);
        leftHand.gameObject.SetActive(true);
        head.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    
        if (photonView.IsMine)
        {
            MapPosition();
        }
      
        
    }

    private void MapPosition()
    {
        head.position = XRHead.position;
        head.rotation = XRHead.rotation;

        leftHand.position = XRleftHand.position;
        leftHand.rotation = XRleftHand.rotation;

        rightHand.position = XRrightHand.position;
        rightHand.rotation = XRrightHand.rotation;
    }
}
