using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class PuzzleFour : MonoBehaviour
{   
    public Slider slider;
    public TMP_Text tMP_Text;
    public ParticleSystem particleSystem;
    public GameObject puzzle;
    public PlayerMovement playerMovement;

    bool started = false;

    int timeInt = 30;

    void Start()
    {
        tMP_Text.text = $"{timeInt}";
    }

    void Update()
    {   
        if(!started)
        {
            StartCoroutine(Countdown());
        }
       if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            slider.value++;
            particleSystem.Play();
        }

        if(slider.value == 150)
        {
            puzzle.SetActive(false);
            playerMovement.currentSpeed = 10;
            //playerMovement.rb.linearVelocity = new Vector2(playerMovement.currentSpeed, playerMovement.rb.linearVelocity.y);
        }
    }

    IEnumerator Countdown()
    {
        started = true;

        while(timeInt > 0)
        {
            timeInt--;
            tMP_Text.text = $"{timeInt}";
            yield return new WaitForSeconds(1f);
        }
    }
    
}
