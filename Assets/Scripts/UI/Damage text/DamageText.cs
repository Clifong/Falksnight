using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public void DestroyText(){
        Destroy(gameObject.transform.parent.gameObject);
    }
}
