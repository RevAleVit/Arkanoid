using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<BrickController> bricksAtField;

    private void Awake()
    {
        instance = this;
    }

    public void AddBrick(BrickController brick)
    {
        bricksAtField.Add(brick);
    }

    public void DelBrick(BrickController brick)
    {
        bricksAtField.Remove(brick);

        if (bricksAtField.Count <= 0)
            GUIManager.instance.GameOver(true);
    }
}
