using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<BrickController> bricksAtField;
    private int pointsCount = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddBrick(BrickController brick)
    {
        //Add brick to list
        bricksAtField.Add(brick);
    }

    public void DelBrick(BrickController brick)
    {
        //Remove brick from list
        bricksAtField.Remove(brick);

        //Increase points by brick health
        pointsCount += brick.countHealth;
        GUIManager.instance.RefreshPoints(pointsCount);

        //Check for briks on the field
        if (bricksAtField.Count <= 0)
            GUIManager.instance.GameOver(true);
    }
}
