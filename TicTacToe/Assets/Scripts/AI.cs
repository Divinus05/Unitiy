using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AI{

    public string Name { get; private set; }
    private System.Random rand;

    public AI(string name)
    {
        this.Name = name;
        this.rand = new System.Random();
    }

    public int Move(IEnumerable<GridSpace> buttonList)
    {
        int result;
        var castedList = buttonList.ToList();
        do
        {
            result = this.rand.Next(0, 9);
            Debug.Log("Wanting to move to " + result);
        } while (!string.IsNullOrEmpty(castedList[result].buttonText.text));

        return result;
    }
}
