using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelScriptableObject : ScriptableObject
{
    public List<Brick> bricks = new List<Brick>();
}
