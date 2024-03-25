using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomNumGenerator : MonoBehaviour
{

    //public GameObject TextBox;
    public int TheNumber;
    public TextMeshProUGUI randomNumberHolder;
    public void RandomGenerate()
    {
        TheNumber = Random.Range(1, 7);
        //TextBox.GetComponent<Text>().text = "You rolled " + TheNumber;
        randomNumberHolder.text = "You rolled " + TheNumber.ToString();
    }
}
