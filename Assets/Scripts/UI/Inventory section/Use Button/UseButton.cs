using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : MonoBehaviour
{
    public void Consume() {
        ItemUIManager.itemUIManager.Consume();
    }
}
