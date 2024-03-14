using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SteakTimer : MonoBehaviourPunCallbacks
{
    [SerializeField] private MeshFilter filter;
    [SerializeField] private Mesh cookedMesh;
    [SerializeField] private Mesh trashMesh;
    [SerializeField] private GameObject particuleSystem;
    [SerializeField] private float elapsedTime = 120;
    [SerializeField] private Slider slider;
    [SerializeField] private Image sliderFill;
    [SerializeField] private GameObject player;
    [SerializeField] private XRGrabNetworkInteractable XRGrabNetworkInteractable;
    [SerializeField] private GameObject UItimer;
    [SerializeField] private AudioSource CookingSound;
    
    private PhotonView photonView;

    private bool Cooking = false;
    private float maxElapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        maxElapsedTime = elapsedTime;
        player = GameObject.FindGameObjectWithTag("Player");
        slider.maxValue = elapsedTime;
        XRGrabNetworkInteractable = GetComponent<XRGrabNetworkInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.LookAt(new Vector3 (player.transform.position.x, 0, player.transform.position.z));
        slider.value = elapsedTime;
        sliderFill.color = Color.Lerp(Color.red, Color.green, slider.value / maxElapsedTime);
        if (Cooking)
        {
            TimerCooking();
        }
    }

    private void TimerCooking()
    {
        if (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
        }
        if (elapsedTime < maxElapsedTime / 2)
        {
            filter.mesh = cookedMesh;
            XRGrabNetworkInteractable.interactionLayers = InteractionLayerMask.GetMask("Ingredients");

        }
        if (elapsedTime < 0)
        {
            particuleSystem.SetActive(true);
            filter.mesh = trashMesh;
            Cooking = false;
            XRGrabNetworkInteractable.interactionLayers = InteractionLayerMask.GetMask("RawIngredients");
        }
    }

    public void SetCookingTrue()
    {
        Cooking = true;
        photonView.RPC("PlayAudio", RpcTarget.All);
    }

    public void SetCookingFalse()
    {
        Cooking = false;
        photonView.RPC("StopAudio", RpcTarget.All);
    }
    
    [PunRPC]
    void PlayAudio()
    {
        CookingSound.Play();
    }
    
    [PunRPC]
    void StopAudio()
    {
        CookingSound.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Flame"))
        {
            SetCookingTrue();
            UItimer.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Flame"))
        {
            SetCookingFalse();
            UItimer.SetActive(false);
        }
    }
}
