using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public TextMeshProUGUI positionText;
    public TextMeshProUGUI typeText;

    public TextMeshProUGUI timeToNextBalloonText;
    public Button buildButton;

    public TextMeshProUGUI waterText;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI steelText;
    public TextMeshProUGUI coalText;

    public void UpdateSelection(Tile tile) {
        positionText.text = tile.x.ToString() + ", " + tile.y.ToString();
        typeText.text = tile.type.ToString() + " : " + tile.resourceType.ToString();
    }

    public void SetSelectedTilePosition(int x, int y)
    {
        positionText.text = x.ToString() + ", " + y.ToString();
    }

    public void SetTimeToNextBalloon(float time)
    {
        timeToNextBalloonText.text = "Time until balloon arrival: " + time.ToString("F1"); ;
    }

    public void BuildButton()
    {
        GameManager.instance.Build();
    }

    public void UpdateResources(float water, float food, float wood, float steel, float coal)
    {
        waterText.text = "Water: " + Mathf.Floor(water).ToString();
        foodText.text = "Food: " + Mathf.Floor(food).ToString();
        woodText.text = "Wood: " + Mathf.Floor(wood).ToString();
        steelText.text = "Steel: " + Mathf.Floor(steel).ToString();
        coalText.text = "Coal: " + Mathf.Floor(coal).ToString();
    }
}
