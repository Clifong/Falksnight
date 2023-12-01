using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TaskData
{
    public bool active; //whether task is currently doable
    public string taskName; //name of task
    [TextAreaAttribute] public string taskDescription; //description of task
    public TaskType taskType; //type of task
    public enum TaskType {Mission, Quest}

    public TaskData(bool active, string taskName, string taskDescription, TaskType taskType)
    {
        this.active = active;
        this.taskName = taskName;
        this.taskDescription = taskDescription;
        this.taskType = taskType;
    }
}