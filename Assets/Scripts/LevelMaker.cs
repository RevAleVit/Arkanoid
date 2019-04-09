using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct BrickType
{
    public BrickController prefab;
    public int balanceChance;
}

public class LevelMaker : MonoBehaviour
{
    [SerializeField] BrickType[] brickTypes;
    private int[] balanceValues;

    [Space]
    [Range(1, 10)]
    [SerializeField] private int countRows = 6;

    [Space]
    [Header("Count bricks in row range")]
    [Range(1, 3)]
    [SerializeField] private int minCountBricksInRow = 3;
    [Range(3, 6)]
    [SerializeField] private int maxCountBricksInRow = 6;    

    // Start is called before the first frame update
    void Start()
    {
        balanceValues = new int[brickTypes.Length];

        for(int i = 0; i < brickTypes.Length; i++)
            balanceValues[i] = brickTypes[i].balanceChance;

        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < countRows; i++)
        {
            int countBricksInCurrentRow = Random.Range(minCountBricksInRow, maxCountBricksInRow + 1);

            for (int j = 0; j < countBricksInCurrentRow; j++)
            {
                float xPositionShift = (j - ((float)countBricksInCurrentRow / 2 - 1)) * 0.8f;
                float xPositionCorrector = -0.4f;

                Transform brick = Instantiate(brickTypes[GetBalanceNum(balanceValues)].prefab, transform).transform;
                brick.localPosition = new Vector2(xPositionShift + xPositionCorrector, -i * 0.6f);                
            }
        }
    }

    //Just get balanced index by value in array
    private int GetBalanceNum(int[] values)
    {
        int max = 0;
        foreach (int val in values)
            max += val;

        int randomValue = Random.Range(0, max);

        int ran = 0;

        for (int i = 0; i < values.Length; i++)
        {
            ran += values[i];
            if (randomValue < ran)
                return i;
        }
        return 0;
    }
}
