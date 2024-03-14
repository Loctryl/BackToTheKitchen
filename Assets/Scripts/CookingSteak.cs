using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CookingSteak : MonoBehaviour
{
    [SerializeField] private GameObject socket;
    [SerializeField] private GameObject particle;

    [SerializeField] private bool onStove = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RawSteak") && onStove)
        {
            socket.SetActive(true);
            particle.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RawSteak"))
        {
            socket.SetActive(false);
            particle.SetActive(false);
        }
    }

    public void SetOnStoveTrue()
    {
        onStove = true;
    }
    public void SetOnStoveFalse()
    {
        onStove = false;
    }
}
