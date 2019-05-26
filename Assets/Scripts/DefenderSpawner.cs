using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    Defender defender;

    private void OnMouseDown()
    {
        if(defender)
            SpawnDefender(getMousePosInWorld());
    }

    public void SelectDefender(Defender defender)
    {
        this.defender = defender;
    }

    private void SpawnDefender(Vector2 worldpos)
    {
        Defender newDefender = Instantiate(
                defender,
                worldpos,
                Quaternion.identity
            );
    }

    private Vector2 getMousePosInWorld()
    {
        Vector2 clickedPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickedPos);

        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        float snapX = Mathf.RoundToInt(worldPos.x);
        float snapY = Mathf.RoundToInt(worldPos.y);

        return new Vector2(snapX, snapY);
    }
}
