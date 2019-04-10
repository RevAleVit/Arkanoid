using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;    
    
    [SerializeField] private Transform bricksZone;

    private List<BrickController> bricksAtField;
    private float bricksFallTimer;
    private int pointsCount = 0;

    private void Awake()
    {
        instance = this;
        bricksAtField = new List<BrickController>();
    }

    private void Start()
    {
        bricksFallTimer = GameSettings.instance.bricksFallTime; 
    }

    private void Update()
    {
        //Bricks fall timer
        bricksFallTimer -= Time.deltaTime;
        GUIManager.instance.RefreshTimer(bricksFallTimer);
        if (bricksFallTimer <= 0)
            FallBricks();
    }

    private void FallBricks()
    {
        //Start coroutine for smooth bricks falling (set fall distance in parameters)
        StartCoroutine(BricksFalling(bricksZone.position.y - 0.8f));
        bricksFallTimer = GameSettings.instance.bricksFallTime;
    }

    IEnumerator BricksFalling(float targetPosition)
    {
        //Falling bricks to target position
        while (bricksZone.position.y > targetPosition)
        {
            bricksZone.position -= new Vector3(0, 0.05f, 0);
            yield return new WaitForSeconds(0.03f);
        }
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

        //Check for bricks on the field
        if (bricksAtField.Count <= 0)
            GUIManager.instance.GameOver(true);
    }    
}
