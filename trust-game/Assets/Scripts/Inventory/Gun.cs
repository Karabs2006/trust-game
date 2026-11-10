using UnityEngine;

[CreateAssetMenu(menuName = "Items/Gun")]
public class Gun : Item
{
    public override void Use()
    {
      
      PuzzleCheck.currentPuzzle.SetActive(false);
      PuzzleCheck.trunkInv.SetActive(false);
      GameObject player = GameObject.Find("Player");

      PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

      playerMovement.currentSpeed = 10;
      playerMovement.rb.linearVelocity = new Vector2(playerMovement.currentSpeed, playerMovement.rb.linearVelocity.y);
        
    }
}