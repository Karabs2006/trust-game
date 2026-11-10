using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[CreateAssetMenu(menuName = "Items/Tomogachi")]
public class Tomogachi : Item
{
    public override void Use()
    {
        //SceneManager.LoadScene("SampleScene");
        GameObject transformObj = GameObject.Find("TomogachiSpawnTest");
        Transform targetTransform = transformObj.GetComponent<Transform>();

        GameObject playerObj = GameObject.Find("Player");

        //playerObj.transform.position = new Vector3(targetTransform.position.x, playerObj.transform.position.y, playerObj.transform.position.z);

        
        switch (PuzzleCheck.currentPuzzle.name)
            {
                
                case "Puzzle One":

                    PuzzlePosition puzzlePosition = PuzzleCheck.currentPuzzle.GetComponent<PuzzlePosition>();
                    puzzlePosition.timerInt = 30;
                    puzzlePosition.timerText.text = $"{puzzlePosition.timerInt}";

                    puzzlePosition.eventInput.Respawn();

                break;

                case "PuzzleTwo":
                    
                    IntCounter intCounter = PuzzleCheck.currentPuzzle.GetComponent<IntCounter>();
                    intCounter.tryCount = 4;
                    intCounter.timerText.text = $"{intCounter.tryCount}";


                    GameObject puzzlePlayer = PuzzleCheck.currentPuzzle.transform.Find("PuzzlePlayer").gameObject;
                    MoveTest moveTest = puzzlePlayer.GetComponent<MoveTest>();
                    moveTest.Respawn();
                    
                    GameObject obstacles = PuzzleCheck.currentPuzzle.transform.Find("Obstacles").gameObject;
                    MoveObstacles moveObstacles = obstacles.GetComponent<MoveObstacles>();
                    moveObstacles.Respawn();

                    break;

                case "PuzzleThree":
                    GameObject scriptHolder = PuzzleCheck.currentPuzzle.transform.Find("ScriptHolder").gameObject;
                    PuzzleThreeTimer puzzleThreeTimer = scriptHolder.GetComponent<PuzzleThreeTimer>();
                    puzzleThreeTimer.Reset();
                
                    break;

                case "PuzzleFour":
                
                    GameObject scriptHolderTwo = PuzzleCheck.currentPuzzle.transform.Find("ScriptHolder").gameObject;
                    PuzzleFour puzzleFour = scriptHolderTwo.GetComponent<PuzzleFour>();
                    puzzleFour.timeInt = 30;
                    puzzleFour.slider.value = 0;
                    puzzleFour.tMP_Text.text = $"{puzzleFour.timeInt}";

                    break;

                
            }
    }
}