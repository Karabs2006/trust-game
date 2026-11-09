using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Items/SnackBar")]
public class SnackBar : Item
{
    public override void Use()
    {   
        
        GameObject timer = GameObject.Find("Timer");
        TMP_Text tMP_Text = timer.GetComponent<TMP_Text>();

        //Puzzle One
        GameObject puzzlePlayer = GameObject.Find("Puzzle One");

        if(puzzlePlayer != null)
        {
            PuzzlePosition puzzlePosition = puzzlePlayer.GetComponent<PuzzlePosition>();
            puzzlePosition.timerInt +=10;
            tMP_Text.text = $"{puzzlePosition.timerInt}";
        }

        //Puzzle Two

        if(puzzlePlayer == null)
        {
            GameObject scriptHolder = GameObject.Find("ScriptHolder");

            PuzzleThreeTimer puzzleThreeTimer = scriptHolder.GetComponent<PuzzleThreeTimer>();

            if(puzzleThreeTimer != null)
            {
                puzzleThreeTimer.timeInt += 10;
                tMP_Text.text = $"{puzzleThreeTimer.timeInt}" ;
            }


            if(puzzleThreeTimer == null)
            {
               PuzzleFour puzzleFour = scriptHolder.GetComponent<PuzzleFour>();
               puzzleFour.timeInt += 10;
               tMP_Text.text = $"{puzzleFour.timeInt}" ;
            }
        }

        //Puzzle Three




    }
}
