﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderPreview : MonoBehaviour, IItemPreview
{
    new SpriteRenderer renderer;
    bool couldPlace;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    public Vector3 GetPlacePosition(Vector3 pointPosition)
    {
        return pointPosition.ToGridPosition().AsV3() + new Vector3(0.5f, 0);
    }

    public void UpdatePreview(Vector3 position)
    {
        transform.position = GetPlacePosition(position);
        var gridPos = position.ToGridPosition();
        if (RuntimeProceduralMap.Instance.IsBlockAt(gridPos.x, gridPos.y-1) &&  MapHelper.AirTileCountAbove(RuntimeProceduralMap.Instance, gridPos, true) >= 6)
        {
            renderer.color = Color.green;
            couldPlace = true;
        }
        else
        {
            renderer.color = Color.red;
            couldPlace = false;
        }
    }

    public bool WouldPlaceSuccessfully()
    {
        return couldPlace;
    }
}
