using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;
using Photon.Pun;

public class Recipe : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject compositionDisplay;
    [SerializeField] private GameObject image;
    [SerializeField] private List<Sprite> composition;
    private List<int> _recipe;

    private float _initialTime;
    private float _timeToServe;
    
    // Start is called before the first frame update
    void Start()
    {
        _initialTime = Random.Range(180.0f, 360.0f);
        _timeToServe = _initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        _timeToServe -= Time.deltaTime;
        slider.value = (_timeToServe / _initialTime) * 100;
        if (_timeToServe <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void CreateImageComp(int id)
    {
        GameObject nF = PhotonNetwork.Instantiate(image.name, Vector3.zero, Quaternion.identity);
        nF.transform.parent = compositionDisplay.transform;
        nF.GetComponent<Image>().sprite = composition[id];
    }

    public void SetRecipe(List<GameObject> ingredients)
    {
        List<int> recipe = new List<int>();
        
        recipe.Add(-1);
        recipe.Add(0);
        CreateImageComp(0);
        
        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            int id = Random.Range(2, ingredients.Count - 1);
            recipe.Add(id);
            CreateImageComp(id);

        }
        
        recipe.Add(1);
        CreateImageComp(1);

    }
    
    public List<int> GetRecipeIngredients() { return _recipe; }
}
