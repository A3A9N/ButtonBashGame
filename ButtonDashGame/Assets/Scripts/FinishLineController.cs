using System;
using UnityEngine;

public class FinishLineController : MonoBehaviour
{

    public static event Action OnPlayerWin;

 
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
 
            OnPlayerWin?.Invoke();
           
        }
    }
}
