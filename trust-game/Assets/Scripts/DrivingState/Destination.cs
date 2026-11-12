
using UnityEngine;

public class Destination : MonoBehaviour
{
    public EndingManager end;
    public GameObject text;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
           end.Ending();
        }
    }

   
    
}
