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
    public TextMeshProUGUI timeToNextBalloonText;

    public Button buildButton;

    public void SetSelectedTilePosition(int x, int y)
    {
        positionText.text = x.ToString() + ", " + y.ToString();
    }

    public void SetTimeToNextBalloon(float time)
    {
        timeToNextBalloonText.text = "Time until balloon arrival: " + time.ToString("F1");;
    }

    public void BuildButton() {
        GameManager.instance.Build();
    }
}
