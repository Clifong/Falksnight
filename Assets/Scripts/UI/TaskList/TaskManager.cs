using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public Task allTasks;
    public GameObject box;
    public GameObject questTitle;
    public GameObject sampleTaskBox;
    List<TaskData> currentActiveTasks = new List<TaskData>();
    List<GameObject> taskObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Invoke("InitializeTaskList", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeTaskList()
    {
        List<TaskData> allTaskData = allTasks.allTasks;
        foreach (TaskData t in allTaskData)
        {
            if (t.active)
            {
                currentActiveTasks.Add(t);
                AddTaskToList(t);
            }
        }
    }

    //add task to task list UI
    public void AddTaskToList(TaskData taskData)
    {
        GameObject temp = Instantiate(sampleTaskBox, box.transform);
        temp.GetComponent<TaskObject>().UpdateInfo(taskData);
        int position = taskData.taskType == TaskData.TaskType.Mission 
                       ? questTitle.transform.GetSiblingIndex() 
                       : sampleTaskBox.transform.GetSiblingIndex();
        temp.transform.SetSiblingIndex(position);
        temp.SetActive(true);
    }

    //remove task from task list UI
    public void RemoveTaskFromList(TaskData taskData)
    {
        int index = currentActiveTasks.FindIndex(x => x.taskName == taskData.taskName);
        GameObject temp = taskObjects[index];
        taskObjects.RemoveAt(index);
        currentActiveTasks.RemoveAt(index);
        Destroy(temp);
    }

    //update specified task detail
    public void UpdateTaskDetails(TaskData taskData, bool activate)
    {
        taskData.active = activate;
        if (activate)
        {
            
            AddTaskToList(taskData);
        }
        else
        {
            RemoveTaskFromList(taskData);
        }
    }
}
