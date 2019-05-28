using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    Defender defender;

    private void OnMouseDown()
    {
        if(defender)
            AttemptToPlaceDefenderAt(getMousePosInWorld());

        //AttemptToPlaceDefenderAt(hasDefenderInSquare(getMousePosInWorld()));
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
        newDefender.transform.parent = transform;
    }

    private void AttemptToPlaceDefenderAt(Vector2 worldpos)
    {
        //if (worldpos.x >= 1000f && worldpos.y>=1000f)
        //    return;

        int defenderCost = defender.getStarCost();
        StarDisplay stars = FindObjectOfType<StarDisplay>();

        if (stars.getStars() >= defenderCost)
        {
            SpawnDefender(worldpos);
            stars.ReduceStars(defenderCost);
        }
            
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

    private Vector2 hasDefenderInSquare(Vector2 worldpos)
    {
        Defender[] defenders = FindObjectsOfType<Defender>();
        Vector2 snapPos = worldpos;

        foreach(Defender defender in defenders)
        {
            bool isXEqual = Mathf.Abs(defender.transform.position.x - worldpos.x) <= Mathf.Epsilon;
            bool isYEqual = Mathf.Abs(defender.transform.position.y - worldpos.y) <= Mathf.Epsilon;

            if (isXEqual && isYEqual)
            {
                snapPos = new Vector2(1000f,1000f);
                break;
            }
        }

        return snapPos;
    }
}
