﻿
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Util
{
    public static readonly Dictionary<int, int> BITMASK_TO_TILEINDEX = new Dictionary<int, int>()
    {{2, 1 },{ 8, 2 }, {10, 3 }, {11, 4 }, {16, 5 }, {18, 6 }, { 22, 7 },
        { 24, 8 }, {26, 9 }, {27, 10 }, {30, 11 }, {31, 12 }, {64, 13 },{ 66 , 14},
        { 72 , 15},{ 74 , 16},{ 75 , 17},{ 80 , 18},{ 82 , 19},{ 86 , 20},{ 88 , 21},
        { 90 , 22},{ 91 , 23},{ 94 , 24},{ 95 , 25},{ 104 , 26},{ 106 , 27},{ 107 , 28},
        { 120 , 29},{ 122 , 30},{ 123 , 31},{ 126 , 32},{ 127 , 33},{ 208 , 34},{ 210 , 35},
        { 214 , 36},{ 216 , 37},{ 218 , 38},{ 219 , 39},{ 222 , 40},{ 223 , 41},{ 248 , 42},
        { 250 , 43},{ 251 , 44},{ 254 , 45},{ 255 , 46},{ 0 , 47 } };

    public static void IterateXY(int size, System.Action<int, int> action)
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                action(x, y);
            }
        }
    }

    public static void IterateXY(int sizeX, int sizeY, System.Action<int, int> action)
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                action(x, y);
            }
        }
    }

    public static void IterateX(int size, System.Action<int> action)
    {
        for (int i = 0; i < size; i++)
        {
            action(i);
        }
    }

    public static float PseudoRandomValue(float x, float y)
    {
        return (float)(Mathf.Sin(Vector2.Dot(new Vector2(x, y), new Vector2(12.9898f, 78.233f))) * 43758.5453) % 1;
    }

    public static int RandomInVector(Vector2Int vector)
    {
        return Random.Range(vector.x, vector.y);
    }

    public static Vector2Int RandomDirection()
    {
        int value = Random.Range(0, 4);

        switch (value)
        {
            case 0:
                return Vector2Int.right;
            case 1:
                return Vector2Int.down;
            case 2:
                return Vector2Int.left;
            default:
                return Vector2Int.up;
        }
    }

    public static Vector2Int ToGridPosition(this Vector3 vector)
    {
        return new Vector2Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y));
    }

    public static float Abs(this float f)
    {
        return Mathf.Abs(f);
    }

    public static float Sign(this float f)
    {
        return Mathf.Sign(f);
    }

    public static Vector3 AsV3(this Vector2Int v)
    {
        return new Vector3(v.x, v.y);
    }

    public static void DebugDrawTile(Vector2Int location)
    {
        DebugDrawTile(location, Color.white, 1);
    }

    public static void DebugDrawTile(Vector2Int location, Color color, float duration = 1)
    {
        Debug.DrawLine(location.AsV3(), location.AsV3() + Vector3.up, color, duration);
        Debug.DrawLine(location.AsV3(), location.AsV3() + Vector3.right, color, duration);
        Debug.DrawLine(location.AsV3() + Vector3.up, location.AsV3() + Vector3.up + Vector3.right, color, duration);
        Debug.DrawLine(location.AsV3() + Vector3.right, location.AsV3() + Vector3.up + Vector3.right, color, duration);
    }

    public static void GizmosDrawTile(Vector2Int location)
    {
        Gizmos.DrawLine(location.AsV3(), location.AsV3() + Vector3.up);
        Gizmos.DrawLine(location.AsV3(), location.AsV3() + Vector3.right);
        Gizmos.DrawLine(location.AsV3() + Vector3.up, location.AsV3() + Vector3.up + Vector3.right);
        Gizmos.DrawLine(location.AsV3() + Vector3.right, location.AsV3() + Vector3.up + Vector3.right);
    }

    public static Vector2 ScreenCenter { get => new Vector2(Screen.width / 2, Screen.height / 2); }

    public static Vector3 MouseToWorld()
    {
        if (CameraController.Instance == null)
            return Vector3.zero;

        var ray = CameraController.Instance.Camera.ScreenPointToRay(Input.mousePosition);

        Plane p = new Plane(Vector3.forward, Vector3.zero);
        if (p.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }
        return Vector3.zero;
    }

    public static RaycastHit2D[] RaycastFromMouse()
    {
        if (CameraController.Instance == null)
            return null;

        Vector3 position = MouseToWorld();
        return Physics2D.CircleCastAll(position, 0.2f, Vector2.zero);
    }

    public static Vector2Int AsV2Int(this Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                return new Vector2Int(0, 1);
            case Direction.Right:
                return new Vector2Int(1, 0);
            case Direction.Down:
                return new Vector2Int(0, -1);
            case Direction.Left:
                return new Vector2Int(-1, 0);

            default:
                return Vector2Int.zero;
        }
    }
    public static Direction Inverse(this Direction dir)
    {
        return (Direction)(((int)dir + 2) % 4);
    }

    public static string GenerateNewSaveGUID()
    {
        return System.Guid.NewGuid().ToString();
    }

    public static int RandomInV2(Vector2Int vector2Int)
    {
        return Random.Range(vector2Int.x, vector2Int.y+1);
    }

}
