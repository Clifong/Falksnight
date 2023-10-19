using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillsSO", menuName = "SkillsSO", order = 1)]
public class SkillsSO : ScriptableObject
{
    public string name;
    [TextAreaAttribute]
    public string description;
    public int attack;
}
