using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action handlePulled= delegate{ };
    //It represents a method that takes no parameters and returns void.
    //handle script say something
    [SerializeField]
    private TextMeshProUGUI priceText;
    //used to get information about our row
    [SerializeField]
    private Row[] rows;
    [SerializeField]
    private Transform handle;

    private int prizeValue;
    private bool isResult ;
    void Start()
    {
       
    }
    private void OnMouseDown()
    {
        if (rows[0].isRowStop && rows[1].isRowStop && rows[2].isRowStop)
            StartCoroutine(PullHandle());
    }
    private IEnumerator PullHandle()
    {
        // Rotate 5 degrees incrementally
        for (int i = 0; i <= 15; i += 5)
        {
            handle.Rotate(0, 0, i);
            yield return new WaitForSeconds(0.1f);
        }

        handlePulled();

        // Rotate back to the original position
        for (int i = 15; i >= 0; i -= 5)
        {
            handle.Rotate(0, 0, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void CheckResult()
    {
        string[] sloatTypes = { "Diamond", "Crown", "Melon", "Bar", "Seven", "Cherry", "Lemon" };
        int[] prizes = { 200, 400, 400, 400, 400, 400, 400 };
        for(int i=0;i< sloatTypes.Length;i++)
        {
            if (rows[0].stoppedSloat == sloatTypes[i] && rows[1].stoppedSloat == sloatTypes[i] &&
                rows[2].stoppedSloat == sloatTypes[i])
            {
                prizeValue = prizes[i];
                isResult = true;
                return;
            }
            if ((rows[0].stoppedSloat == "Diamond" && rows[1].stoppedSloat == "Crown" && rows[2].stoppedSloat == "Melon") ||
        (rows[0].stoppedSloat == "Melon" && rows[1].stoppedSloat == "Diamond" && rows[2].stoppedSloat == "Crown"))
            {
                prizeValue = 1000; // Example prize value for specific combination
                isResult = true;
                return;
            }
            else if ((rows[0].stoppedSloat == "Bar" && rows[1].stoppedSloat == "Seven" && rows[2].stoppedSloat == "Cherry") ||
                     (rows[0].stoppedSloat == "Cherry" && rows[1].stoppedSloat == "Bar" && rows[2].stoppedSloat == "Seven"))
            {
                prizeValue = 750; // Example prize value for another specific combination
                isResult = true;
                return;
            }

            // Extend this section to include other specific combinations as needed
            // Example: Diamond, Crown, and any other symbol
            if ((rows[0].stoppedSloat == "Diamond" && rows[1].stoppedSloat == "Crown") ||
                (rows[0].stoppedSloat == "Crown" && rows[1].stoppedSloat == "Diamond"))
            {
                prizeValue = 500; // Example prize value for Diamond and Crown combination
                isResult = true;
                return;
            }

            // If no matches or specific combinations, set prize value to 0
            prizeValue = 0;
            isResult = true;

        }

        isResult = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (rows[0].isRowStop && rows[1].isRowStop && rows[2].isRowStop)
        {
            if (!isResult)
            {
                CheckResult();
                priceText.enabled = true;
                priceText.text = "Prize " + prizeValue;
            }
        }
        else
        {
            priceText.enabled = false;
            isResult = false;
        }
    }
}
