using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SteakTimer : MonoBehaviour
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

    private bool Cooking = false;
    private float maxElapsedTime;


    // Start is called before the first frame update
    void Start()
    {
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
            XRGrabNetworkInteractable.interactionLayers = InteractionLayerMask.GetMask("Nothing");
        }
    }

    public void SetCookingTrue()
    {
        Cooking = true;
    }

    public void SetCookingFalse()
    {
        Cooking = false;
    }

    public void HoverEnter (HoverEnterEventArgs e)
    {
        Debug.Log("entered");
        if (e.interactorObject.transform.CompareTag("Flame")){
            SetCookingTrue();
            UItimer.SetActive(true);
        }
    }

    public void HoverExited(HoverExitEventArgs e)
    {
        Debug.Log("exited");
        if (e.interactorObject.transform.CompareTag("Flame"))
        {
            SetCookingFalse();
            UItimer.SetActive(false);
        }
    }
}
