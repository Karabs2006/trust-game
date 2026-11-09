
using UnityEngine;

public class Destination : MonoBehaviour
{
    public EndingManager end;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           end.Ending();
        }
    }

   
    
}
