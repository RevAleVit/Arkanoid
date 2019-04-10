using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BrickType
{
    public BrickController prefab;
    public int countHealth;
    public int balanceChance;    
}

public class GameSettings : MonoBehaviour
{
    [Header("BAT settings")]
    [Range(0.05f, 0.3f)]
    public float batMoveSpeed = 0.15f;

    [Space]
    [Header("BALL settings")]
    [Range(3, 7)]
    public float ballSpeed = 5;

    [Space]
    [Header("BRICKS FALL settings")]
    [Range(1, 20)]
    public float bricksFallTime = 10;

    [Space]
    [Header("LEVEL MAKER setting")]
    public BrickType[] brickTypes;    
    [Space]
    [Range(1, 10)]
    public int countBrickRows = 6;
    [Space]
    [Header("Count bricks in row range")]
    [Range(1, 3)]
    public int minCountBricksInRow = 3;
    [Range(3, 6)]
    public int maxCountBricksInRow = 6;

    public static GameSettings instance;
    private void Awake()
    {
        instance = this;
    }
}
