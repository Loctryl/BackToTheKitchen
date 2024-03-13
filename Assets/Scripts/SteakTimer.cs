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
            XRGrabNetworkInteractable.interactionLayers = InteractionLayerMask.NameToLayer("Ingredients");

        }
        if (elapsedTime < 0)
        {
            particuleSystem.SetActive(true);
            filter.mesh = trashMesh;
            Cooking = false;
            XRGrabNetworkInteractable.interactionLayers = InteractionLayerMask.NameToLayer("RawIngredients");
        }
    }

    public void SetCooking()
    {
        Cooking = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Flame"))
        {
            Cooking = false;
        }
    }
}