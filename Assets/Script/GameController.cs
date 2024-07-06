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
        if (rows[0].isRowStop || rows[1].isRowStop || rows[2].isRowStop)
        {
            CheckResult();
            priceText.enabled = true;
            isResult = false;
        }
        if (rows[0].isRowStop && rows[1].isRowStop && rows[2].isRowStop &&! isResult)
        {
            CheckResult();
            priceText.enabled = true;
            priceText.text = "Prize Value" + prizeValue;

        }
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
    private  void CheckResult()
    {
        if (rows[0].stoppedSloat == "Diamond" &&
            rows[1].stoppedSloat == "Diamond" &&
            rows[2].stoppedSloat == "Diamond")
            prizeValue = 200;
       else if (rows[0].stoppedSloat == "Crown" &&
            rows[1].stoppedSloat == "Crown" &&
            rows[2].stoppedSloat == "Crown")
            prizeValue = 400;
        else if (rows[0].stoppedSloat == "Melon" &&
          rows[1].stoppedSloat == "Melon" &&
          rows[2].stoppedSloat == "Melon")
            prizeValue = 400;
        else if (rows[0].stoppedSloat == "Bar" &&
           rows[1].stoppedSloat == "Bar" &&
           rows[2].stoppedSloat == "Bar")
            prizeValue = 400;
        else if (rows[0].stoppedSloat == "Seven" &&
          rows[1].stoppedSloat == "Seven" &&
          rows[2].stoppedSloat == "Seven")
            prizeValue = 400;
        else if (rows[0].stoppedSloat == "Cherry" &&
         rows[1].stoppedSloat == "Cherry" &&
         rows[2].stoppedSloat == "Cherry")
            prizeValue = 400;
        else if (rows[0].stoppedSloat == "Lemon" &&
          rows[1].stoppedSloat == "Lemon" &&
          rows[2].stoppedSloat == "Lemon")
            prizeValue = 400;
        isResult = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
