using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenConfidant : MonoBehaviour
{
    private void OnOpenConfidant(){
        ConfidantUIManager.confidantUIManager.EnableOrDisableCanvas();
    }
}
