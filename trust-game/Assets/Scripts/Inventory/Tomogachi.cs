using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Items/Tomogachi")]
public class Tomogachi : Item
{
    public override void Use()
    {
      SceneManager.LoadScene("SampleScene");
        GameObject transformObj = GameObject.Find("TomogachiSpawnTest");
        Transform targetTransform = transformObj.GetComponent<Transform>();

        GameObject playerObj = GameObject.Find("Player");

        playerObj.transform.position = new Vector3(targetTransform.position.x, playerObj.transform.position.y, playerObj.transform.position.z);
        

    }
}