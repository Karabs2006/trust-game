using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InfectionBar : MonoBehaviour
{
    public Image infectionBar;
    private float currentInfection;
    private float maxInfection =60;
    public GameObject holder;
    private float increase =21;
    private float decrease;
    private EndingManager ending;

    void Start()
    {
        ending = FindAnyObjectByType<EndingManager>();
        //holder.SetActive(false);
    }

    IEnumerator SetVisible()
    {
        holder.SetActive(true);
        yield return new WaitForSeconds (0.2f);
        IncreaseInfection();
        yield return new WaitForSeconds (0.5f);
        CheckInfection();
        yield return new WaitForSeconds (10f);
        StopCoroutine("SetVisible");
        holder.SetActive(false);
    }

    public void IncreaseInfection()
    {
        currentInfection += increase;
        infectionBar.fillAmount = currentInfection / maxInfection;
    }
    
    public void CheckInfection()
    {
        if (currentInfection >= maxInfection)
        {
            ending.Ending();
            Debug.Log("Youre infected");
            //game over screen 
        }
    }


}
