using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskObject : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    TaskData data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfo(TaskData data)
    {
        title.text = data.taskName;
        description.text = data.taskDescription;
        this.data = data;
    }

    public TaskData GetData()
    {
         return data;
    }
}
