using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderReader : MonoBehaviour
{
    public Slider spawnSlider;
    public Slider bidSlider;
    [SerializeField] private TextMeshProUGUI spawnText;
    [SerializeField] private TextMeshProUGUI bidText;

    void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        spawnText.text = $"Amount of each\n object to spawn : {spawnSlider.value}";
        bidText.text = $"Bid amount : {bidSlider.value}";
    }
}

//4796