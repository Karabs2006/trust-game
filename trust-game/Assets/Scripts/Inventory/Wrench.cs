using TMPro;
using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Items/Wrench")]
public class Wrench : Item
{
    bool usedOnce = false;
    public override void Use()
    {
        if (!usedOnce)
        {

            GameObject timer = GameObject.Find("Timer");
            GameObject puzzlePlayer = GameObject.Find("Puzzle One");
            GameObject obstacle = GameObject.Find("MainObstacle");
            GameObject buttonScript = GameObject.Find("ScriptHolderInv");

            TMP_Text tMP_Text = timer.GetComponent<TMP_Text>();
            PuzzlePosition puzzlePosition = puzzlePlayer.GetComponent<PuzzlePosition>();
            Obstacles obstacles = obstacle.GetComponent<Obstacles>();
            Inventory inventory = buttonScript.GetComponent<Inventory>();

        //Test if button click works
            
            obstacles.StartCoroutine(obstacles.FlashObject(Color.green, Color.white));
            puzzlePosition.timerInt +=10;
            tMP_Text.text = $"{puzzlePosition.timerInt}";
            Debug.Log(tMP_Text.text);
            usedOnce = true;
        }
        

    }

    
}