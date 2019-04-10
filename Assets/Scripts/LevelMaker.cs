using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    private int[] balanceValues;

    // Start is called before the first frame update
    void Start()
    {
        balanceValues = new int[GameSettings.instance.brickTypes.Length];

        for(int i = 0; i < GameSettings.instance.brickTypes.Length; i++)
            balanceValues[i] = GameSettings.instance.brickTypes[i].balanceChance > 1 ? GameSettings.instance.brickTypes[i].balanceChance : 1;

        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < GameSettings.instance.countBrickRows; i++)
        {
            //Random count of bricks in current row (from range)
            int countBricksInCurrentRow = Random.Range(GameSettings.instance.minCountBricksInRow, GameSettings.instance.maxCountBricksInRow + 1);

            for (int j = 0; j < countBricksInCurrentRow; j++)
            {
                //Calculate object position
                float xPositionShift = (j - ((float)countBricksInCurrentRow / 2 - 1)) * 0.8f;
                float xPositionCorrector = -0.4f;

                //Get balanced index of brick
                int balancedNum = GetBalanceNum(balanceValues);
                if (GameSettings.instance.brickTypes[balancedNum].prefab != null)
                {
                    //Instantiate brick object
                    BrickController brick = Instantiate(GameSettings.instance.brickTypes[balancedNum].prefab, transform);
                    //Check for correct count health and set it to brick object
                    brick.countHealth = GameSettings.instance.brickTypes[balancedNum].countHealth >= 1 ? GameSettings.instance.brickTypes[balancedNum].countHealth : 1;
                    //Set brick position
                    brick.transform.localPosition = new Vector2(xPositionShift + xPositionCorrector, -i * 0.6f);
                }
                else
                    Debug.LogError("Brick type number[" + balancedNum + "] is empty!");
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
