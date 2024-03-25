using UnityEngine;
using TMPro;

public class RandomNumGenerator : MonoBehaviour
{

    //public GameObject TextBox;
    public int TheNumber;
    public TextMeshProUGUI randomNumberHolder;
    public void RandomGenerate()
    {
        TheNumber = Random.Range(1, 10);
        //TextBox.GetComponent<Text>().text = "You rolled " + TheNumber;
        randomNumberHolder.text = "You rolled " + TheNumber.ToString();
    }
}
