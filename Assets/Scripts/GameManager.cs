using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<BrickController> bricksAtField;
    [SerializeField] private float bricksFallTime = 2;
    [SerializeField] private Transform bricksZone;

    private int pointsCount = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Invoke("FallBricks", bricksFallTime +  1);
    }

    private void FallBricks()
    {
        bricksZone.position -= new Vector3(0, 0.8f, 0);
        Invoke("FallBricks", bricksFallTime);
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
