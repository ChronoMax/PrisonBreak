using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelItem : Item
{
    private string awnser;

    public PuzzelItem(string riddle, float weight, string awnser) : base(riddle, weight)
    {
        this.awnser = awnser;
    }

    public string GetAwnser()
    {
        return awnser;
    }
}
