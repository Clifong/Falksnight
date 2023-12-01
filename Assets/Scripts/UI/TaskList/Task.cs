using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Task")]
public class Task : ScriptableObject
{
    public List<TaskData> allTasks = new List<TaskData>();
}
