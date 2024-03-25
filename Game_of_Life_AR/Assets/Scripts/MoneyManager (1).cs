/**************************Muaadh's Version****************************/
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
    string[] careerList = { "Doctor", "IT", "Teacher", "Accountant", "Police Officer", "Designer", "Artist", "Athlete", "Actor" };

    int money = 0;
    string career = "Doctor";

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
        if (collision.gameObject.tag == "Spawnable")
            else if (collision.gameObject.tag ==)
        {
            // Call the function you want to execute
            AddMoneyTile();
        }
    }
}
**/
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

    // Add a public GameObject for the confirmation button
    public GameObject confirmButton;

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

        // Initially set the confirmation button to inactive
        confirmButton.SetActive(false);
    }

    // This function will be called when the player collides with a tile
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has one of the tags
        if (collision.gameObject.tag == "Collect" || collision.gameObject.tag == "Pay" || /* add the rest of your tags here */)
        {
            // If the player collides with a tile, activate the confirmation button
            confirmButton.SetActive(true);
        }
    }

    // This function will be called when the confirmation button is clicked
    public void OnConfirmButtonClick(string tag)
    {
        // Perform the task associated with the tile
        switch (tag)
        {
            case "Collect":
                CollectMoney(1000);  // replace 1000 with the amount to collect
                break;
            case "Pay":
                PayMoney(1000);  // replace 1000 with the amount to pay
                break;
            case "Life Space":
                PickUpLifeTile();
                break;
            case "Pay ?k if not insured":
                PayIfNotInsured(1000);  // replace 1000 with the amount to pay if not insured
                break;
            case "Miss next turn":
                MissNextTurn();
                break;
            case "Career Field: ?k":
                CareerField(1000);  // replace 1000 with the amount for the career field
                break;
            case "Return 1 stock":
                ReturnStock();
                break;
            case "Taxes Due":
                TaxesDue();
                break;
            case "Lose your job":
                LoseJob();
                break;
            case "Baby Boy!":
                BabyBoy();
                break;
            case "Baby Girl!":
                BabyGirl();
                break;
            case "Get Married":
                GetMarried();
                break;
            case "Twins!":
                Twins();
                break;
            case "Collect ?k times spin":
                CollectMoneyTimesSpin(1000);  // replace 1000 with the amount to collect times spin
                break;
            case "Education Field - ?k per child":
                EducationField(1000);  // replace 1000 with the amount for the education field per child
                break;
            case "Start College":
                StartCollege();
                break;
            case "Start Career":
                StartCareer();
                break;
            case "Pay Day":
                PayDay();
                break;
            case "Career choice":
                CareerChoice();
                break;
            case "Draw Deed":
                DrawDeed();
                break;
            case "Sell house, buy new one":
                SellHouseBuyNewOne();
                break;
            case "Change Career & Salary Pay 20k":
                ChangeCareerAndSalary();
                break;
            case "Trade Salary":
                TradeSalary();
                break;
            case "Retire":
                Retire();
                break;
            case "Millionaire Estates":
                MillionaireEstates();
                break;
            case "Countryside Acres":
                CountrysideAcres();
                break;
            default:
                Debug.Log("Unknown tag: " + tag);
                break;
        }

        // After performing the task, deactivate the confirmation button
        confirmButton.SetActive(false);
    }

    // Add the rest of your functions here...
    public void CollectMoney(int amount)
    {
        money += amount;
        moneyText.text = "$" + money.ToString();
    }

    public void PayMoney(int amount)
    {
        money -= amount;
        moneyText.text = "$" + money.ToString();
    }

    public void PickUpLifeTile()
    {
        // Add your implementation here
    }

    public void PayIfNotInsured(int amount)
    {
        // Add your implementation here
    }

    public void MissNextTurn()
    {
        // Add your implementation here
    }

    public void CareerField(int amount)
    {
        // Add your implementation here
    }

    public void ReturnStock()
    {
        // Add your implementation here
    }

    public void TaxesDue()
    {
        // Add your implementation here
    }

    public void LoseJob()
    {
        // Add your implementation here
    }

    public void BabyBoy()
    {
        // Add your implementation here
    }

    public void BabyGirl()
    {
        // Add your implementation here
    }

    public void GetMarried()
    {
        // Add your implementation here
    }

    public void Twins()
    {
        // Add your implementation here
    }

    public void CollectMoneyTimesSpin(int amount)
    {
        // Add your implementation here
    }

    public void EducationField(int amount)
    {
        // Add your implementation here
    }

    public void StartCollege()
    {
        // Add your implementation here
    }

    public void StartCareer()
    {
        // Add your implementation here
    }

    public void PayDay()
    {
        // Add your implementation here
    }

    public void CareerChoice()
    {
        // Add your implementation here
    }

    public void DrawDeed()
    {
        // Add your implementation here
    }

    public void SellHouseBuyNewOne()
    {
        // Add your implementation here
    }

    public void ChangeCareerAndSalary()
    {
        // Add your implementation here
    }

    public void TradeSalary()
    {
        // Add your implementation here
    }

    public void Retire()
    {
        // Add your implementation here
    }

    public void MillionaireEstates()
    {
        // Add your implementation here
    }

    public void CountrysideAcres()
    {
        // Add your implementation here
    }
}
