/**************************Muaadh's Version****************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public Text moneyText;
    public Text careerText;
    Hashtable careerSalary = new Hashtable();
    Hashtable careerTaxes = new Hashtable();
    string[] careerList = { "Astronaut", "Investor", "Dog Walker" };

    int money = 0;
    string career = "Astronaut";

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        moneyText.text = "$" + money.ToString();
        careerSalary.Add("Astronaut", 100000);
        careerSalary.Add("Investor", 90000);
        careerSalary.Add("Dog Walker", 30000);
        careerSalary.Add("Unemployed", 1);

        careerTaxes.Add("Astronaut", 10000);
        careerTaxes.Add("Investor", 9000);
        careerTaxes.Add("Dog Walker", 3000);
        careerTaxes.Add("Unemployed", 0);
    }

    public void AddMoneyTile()
    {
        money += Random.Range(5000, 30000);
        moneyText.text = "$" + money.ToString();
    }

    public void AddMoneyCareer()
    {
        money += (int)careerSalary[career];
        moneyText.text = "$" + money.ToString();
    }

    public void changeCareerRandom()
    {
        career = careerList[Random.Range(0, careerList.Length)];
        careerText.text = career.ToString();
    }

    public void taxes()
    {
        money -= (int)careerTaxes[career];
        moneyText.text = "$" + money.ToString();
    }

    // This function will be called when the player collides with a tile
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Tile"
        if (collision.gameObject.tag == "Tile")
        {
            // Call the function you want to execute
            AddMoneyTile();
        }
    }
}


/*************************************** Allen's Version******************************/

/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public Text moneyText;
    public Text careerText;
    Hashtable careerSalary = new Hashtable();
    Hashtable careerTaxes = new Hashtable();
    string[] careerList = { "Astronaut", "Investor", "Dog Walker" };

    int money = 0;
    string career = "Astronaut";

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        moneyText.text = "$" + money.ToString();
        careerSalary.Add("Astronaut", 100000);
        careerSalary.Add("Investor", 90000);
        careerSalary.Add("Dog Walker", 30000);
        careerSalary.Add("Unemployed", 1);

        careerTaxes.Add("Astronaut", 10000);
        careerTaxes.Add("Investor", 9000);
        careerTaxes.Add("Dog Walker", 3000);
        careerTaxes.Add("Unemployed", 0);
    }

    public void AddMoneyTile()
    {
        money += Random.Range(5000, 30000);
        moneyText.text = "$" + money.ToString();
    }
    
    public void AddMoneyCareer()
    {
        money += (int)careerSalary[career];
        moneyText.text = "$" + money.ToString();
    }

    public void changeCareerRandom()
    {
        career = careerList[Random.Range(0, careerList.Length)];
        careerText.text = career.ToString();
    }

    public void taxes()
    {
        money -= (int)careerTaxes[career];
        moneyText.text = "$" + money.ToString();
    }
}

**/

