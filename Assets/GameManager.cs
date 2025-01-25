using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public float timeToNextAirBalloon;


    public float water;
    public float food;
    public float wood;
    public float steel;
    public float coal;


    public GameObject parlor;
    UIManager uim;
    TileMapManager tmm;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        tmm = TileMapManager.instance;
        uim = UIManager.instance;
    }

    void Update()
    {
        timeToNextAirBalloon -= Time.deltaTime;
        uim.SetTimeToNextBalloon(timeToNextAirBalloon);
        if (timeToNextAirBalloon < 0.0f)
        {
            BalloonArrival();
        }

        HandleMouseInput();
    }

    void BalloonArrival()
    {
        Debug.Log("balloon arrived :3");
    }

    void HandleMouseInput()
    {
        // ui updates
        uim.UpdateResources(water, food, wood, steel, coal);


        // mouse shit
        if (Input.GetMouseButtonDown(0))
        {
            // check to see if mouse is over a ui(?) element it's weird
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Vector2 worldPosition = GetMouseWorldPosition();
            Debug.Log(worldPosition);

            Tile tile = tmm.GetTile((int)Mathf.Floor(worldPosition.x), (int)Mathf.Floor(worldPosition.y));

            uim.UpdateSelection(tile);

            tmm.SelectTile(tile);
        }
    }

    Vector2 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        mouseScreenPosition.z = cam.nearClipPlane;

        Vector2 worldPosition = cam.ScreenToWorldPoint(mouseScreenPosition);

        return worldPosition;
    }

    public void Build()
    {
        tmm.PlaceBuilding(parlor);
    }
}
