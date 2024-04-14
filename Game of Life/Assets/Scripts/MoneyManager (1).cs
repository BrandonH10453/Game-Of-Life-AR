using System.Collections;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public TMP_Text moneyText;
    public TMP_Text careerText;
    public TMP_Text TaxText;
    public TMP_Text MarriageText;
    public TMP_Text ChildrenText;
    public TMP_Text InsuranceText;
    public TMP_Text LifeTileText;
    public TMP_Text PlayerNumber;
    Hashtable careerSalary = new Hashtable();
    Hashtable careerTaxes = new Hashtable();
    string[] careerDegreeList = {"Doctor", "IT", "Teacher", "Accountant"};
    string[] careerNondegreeList = {"Police Officer", "Designer", "Artist", "Athlete", "Actor"};
    bool playerFlag = true;
    playerInfo player1 = new playerInfo(0, 0, 0, "single", "unemployed", "No");
    playerInfo player2 = new playerInfo(1, 1, 1, "Married", "Artist", "Yes");

    public class playerInfo
    {
        // Default constructor
        public playerInfo() { }

        // Constructor
        public playerInfo(int money, int children, int lifeTile, string married, string career, string insurance)
        {
            this.money = money;
            this.children = children;
            this.lifeTile = lifeTile;
            this.married = married;
            this.career = career;
            this.insurance = insurance;
        }

        // Sets and Gets
        public int getMoney()
        {
            return (money);
        }

        public int getlifeTile()
        {
            return (lifeTile);
        }

        public int getChildren()
        {
            return (children);
        }

        public string getCareer()
        {
            return (career);
        }

        public string getMarried()
        {
            return (married);
        }

        public string getInsured()
        {
            return (insurance);
        }

        public void setMoney(int value)
        {
            this.money = value;
        }

        public void setlifeTile(int value)
        {
            this.lifeTile = value;
        }

        public void setChildren(int value)
        {
            this.children = value;
        }

        public void setMarried(string value)
        {
            this.married = value;
        }

        public void setCareer(string value)
        {
            this.career = value;
        }

        public void getInsured(string value)
        {
            this.insurance = value;
        }

        // Properties for the playerInfo Class
        string married;
        string career;
        string insurance;
        int money;
        int children;
        int lifeTile;
    }

    public void playerSwitch()
    {
        if (playerFlag)
        {
            PlayerNumber.text = "Player 2 Turn";
            playerFlag = false;
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
            ChildrenText.text = "Children: " + player2.getChildren().ToString();
            LifeTileText.text = "Life Tile: " + player2.getlifeTile().ToString();
            MarriageText.text = "Married: " + player2.getMarried().ToString();
            careerText.text = "Career: " + player2.getCareer().ToString();
            InsuranceText.text = "Insured: " + player2.getInsured().ToString();
        }
        else
        {
            PlayerNumber.text = "Player 1 Turn";
            playerFlag = true;
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
            ChildrenText.text = "Children: " + player1.getChildren().ToString();
            LifeTileText.text = "Life Tile: " + player1.getlifeTile().ToString();
            MarriageText.text = "Married: " + player1.getMarried().ToString();
            careerText.text = "Career: " + player1.getCareer().ToString();
            InsuranceText.text = "Insured: " + player1.getInsured().ToString();
        }
    }
  
    // Add a public GameObject for the confirmation button
    public GameObject confirmButton;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PlayerNumber.text = "Player 1 Turn";
        moneyText.text = "Cash: $" + player1.getMoney().ToString();
        ChildrenText.text = "Children: " + player1.getChildren().ToString();
        LifeTileText.text = "Life Tile: " + player1.getlifeTile().ToString();
        MarriageText.text = "Married: " + player1.getMarried().ToString();
        careerText.text = "Career: " + player1.getCareer().ToString();
        careerSalary.Add("Doctor", 80000);
        careerSalary.Add("IT", 70000);
        careerSalary.Add("Teacher", 50000);
        careerSalary.Add("Accountant", 60000);
        careerSalary.Add("Police Officer", 60000);
        careerSalary.Add("Designer", 40000);
        careerSalary.Add("Artist", 40000);
        careerSalary.Add("Athlete", 50000);
        careerSalary.Add("Actor", 40000);

        careerTaxes.Add("Doctor", 35000);
        careerTaxes.Add("IT", 30000);
        careerTaxes.Add("Teacher", 20000);
        careerTaxes.Add("Accountant", 0);
        careerTaxes.Add("Police Officer", 25000);
        careerTaxes.Add("Designer", 15000);
        careerTaxes.Add("Artist", 15000);
        careerTaxes.Add("Athlete", 20000);
        careerTaxes.Add("Actor", 15000);

        // Initially set the confirmation button to inactive
        confirmButton.SetActive(false);
    }

    // This function will be called when the player collides with a tile
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has one of the tags
        if (collision.gameObject.tag == "Collect 20k" || collision.gameObject.tag == "Collect 10k" || collision.gameObject.tag == "Collect 5k" ||
            collision.gameObject.tag == "Collect 75k" || collision.gameObject.tag == "Collect 80k" || collision.gameObject.tag == "Collect 50k"||
            collision.gameObject.tag == "Collect 95k" || collision.gameObject.tag == "Collect 100k"|| collision.gameObject.tag == "Pay 5k" ||
            collision.gameObject.tag == "Pay 10k" || collision.gameObject.tag == "Start College" || collision.gameObject.tag == "Start Career" ||
            collision.gameObject.tag == "Pay Day" || collision.gameObject.tag == "Millionaire Estates" || collision.gameObject.tag == "Countryside Acres" ||
            collision.gameObject.tag == "Career Choice" || collision.gameObject.tag == "Life Space" || collision.gameObject.tag == "Pay 5k if not insured"||
            collision.gameObject.tag == "Miss next turn"|| collision.gameObject.tag == "Pay 15k if not insured" || collision.gameObject.tag == "Draw Deed"||
            collision.gameObject.tag == "Doctor Field: 5k" || collision.gameObject.tag == "Tech Field: 10k" || collision.gameObject.tag == "Change Career Salary Pay 20k"||
            collision.gameObject.tag == "Taxes Due" || collision.gameObject.tag == "New Career" || collision.gameObject.tag == "Add a person and Life Space"||
            collision.gameObject.tag == "Add 2 people and Life Space" || collision.gameObject.tag == "Sports Field: 20k" || collision.gameObject.tag == "Actor Field: 5k"||
            collision.gameObject.tag == "Pay 40k if not insured" || collision.gameObject.tag == "Trade Salary" || collision.gameObject.tag == "Tech Field: 25k"||
            collision.gameObject.tag == "Art Field: 20k" || collision.gameObject.tag == "Sports Field: 25k" || collision.gameObject.tag == "Education Field: 5k"||
            collision.gameObject.tag == "Sell house, buy new one" || collision.gameObject.tag == "Police Field: 15k" || collision.gameObject.tag == "Art Field: 15k"||
            collision.gameObject.tag == "Actor Field: 15k" || collision.gameObject.tag == "Art Field: 25k" || collision.gameObject.tag == "Education Field: 5k per child"||
            collision.gameObject.tag == "Sport Field: 30k" || collision.gameObject.tag == "Pay 125k if not insured"||
            collision.gameObject.tag == "Doctor Field: 25k" || collision.gameObject.tag == "Actor Field: 100k" || collision.gameObject.tag == "Education Field: 50k per child"||
            collision.gameObject.tag == "Pay 50k if not insured" || collision.gameObject.tag == "Art Field: 125k" || collision.gameObject.tag == "Sports Field: 65k"||
            collision.gameObject.tag == "Collect 20k times spin" || collision.gameObject.tag == "Designer Field: 5k" || collision.gameObject.tag == "Designer Field: 30k"||
            collision.gameObject.tag == "Designer Field: 25k" || collision.gameObject.tag == "Retire")
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
            case "Collect 20k":
                Collect20k(20000, playerFlag);
                break;
            case "Collect 10k":
                Collect10k(10000, playerFlag);
                break;
            case "Collect 5k":
                Collect5k(5000, playerFlag);
                break;
            case "Collect 75k":
                Collect75k(75000, playerFlag);
                break;
            case "Collect 50k":
                Collect50k(50000, playerFlag);
                break;
            case "Collect 80k":
                Collect80k(80000, playerFlag);
                break;
            case "Collect 95k":
                Collect95k(95000, playerFlag);
                break;
            case "Collect 100k":
                Collect100k(100000, playerFlag);
                break;
            case "Pay 5k":
                Pay5k(5000, playerFlag);
                break;
            case "Pay 10k":
                Pay10k(10000, playerFlag);
                break;
            case "Life Space":
                PickUpLifeTile(1, playerFlag);
                break;
            case "Pay 5k if not insured":
                Pay5kIfNotInsured(5000);
                break;
            case "Pay 15k if not insured":
                Pay15kIfNotInsured(15000);
                break;
            case "Pay 40k if not insured":
                Pay40kIfNotInsured(40000);
                break;
            case "Pay 50k if not insured":
                Pay50kIfNotInsured(50000);
                break;
            case "Pay 125k if not insured":
                Pay125kIfNotInsured(125000);
                break;
            case "Miss next turn":
                MissNextTurn();
                break;
            case "Doctor Field: 5k":
                DoctorField5k(5000);
                break;
            case "Doctor Field: 25k":
                DoctorField25k(25000);
                break;
            case "Doctor Field: 100k":
                DoctorField100k(100000);
                break;
            case "Tech Field: 10k":
                TechField10k(10000);
                break;
            case "Tech Field: 25k":
                TechField25k(25000);
                break;
            case "Sports Field: 20k":
                SportsField20k(20000);
                break;
            case "Sports Field: 25k":
                SportsField25k(25000);
                break;
            case "Sports Field: 30k":
                SportsField30k(30000);
                break;
            case "Sports Field: 65k":
                SportsField65k(65000);
                break;
            case "Actor Field: 5k":
                ActorField5k(5000);
                break;
            case "Actor Field: 15k":
                ActorField15k(15000);
                break;
            case "Actor Field: 100k":
                ActorField100k(100000);
                break;
            case "Art Field: 15k":
                ArtField15k(15000);
                break;
            case "Art Field: 20k":
                ArtField20k(20000);
                break;
            case "Art Field: 25k":
                ArtField25k(25000);
                break;
            case "Art Field: 125k":
                ArtField125k(125000);
                break;
            case "Police Field: 15k":
                PoliceField15k(15000);
                break;
            case "Designer Field: 5k":
                DesignerField5k(5000);
                break;
            case "Designer Field: 25k":
                DesignerField25k(25000);
                break;
            case "Designer Field: 30k":
                DesignerField30k(30000);
                break;
            case "Taxes Due":
                TaxesDue();
                break;
            case "Lose your job":
                LoseJob();
                break;
            case "Add a person and Life Space":
                AddChild(1, 1);
                break;
            case "Get Married":
                GetMarried();
                break;
            case "Twins!":
                Twins(2, 1);
                break;
            case "Collect 20k times spin":
                CollectMoneyTimesSpin(20000);
                break;
            case "Education Field: 5k per child":
                EducationField5k(5000);
                break;
            case "Education Field: 50k per child":
                EducationField50k(50000);
                break;
            case "Start College":
                StartCollege(40000);
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
    public void Collect20k(int amount, bool flag)
    {
        if (flag)
        {
            player1.setMoney(player1.getMoney() + amount);
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
        }
        else
        {
            player2.setMoney(player2.getMoney() + amount);
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
        }
    }
    public void Collect10k(int amount, bool flag)
    {
        if (flag)
        {
            player1.setMoney(player1.getMoney() + amount);
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
        }
        else
        {
            player2.setMoney(player2.getMoney() + amount);
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
        }
    }
    public void Collect5k(int amount, bool flag)
    {
        if (flag)
        {
            player1.setMoney(player1.getMoney() + amount);
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
        }
        else
        {
            player2.setMoney(player2.getMoney() + amount);
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
        }
    }
    public void Collect50k(int amount, bool flag)
    {
        if (flag)
        {
            player1.setMoney(player1.getMoney() + amount);
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
        }
        else
        {
            player2.setMoney(player2.getMoney() + amount);
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
        }
    }
    public void Collect75k(int amount, bool flag)
    {
        if (flag)
        {
            player1.setMoney(player1.getMoney() + amount);
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
        }
        else
        {
            player2.setMoney(player2.getMoney() + amount);
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
        }
    }
    public void Collect80k(int amount, bool flag)
    {
        if (flag)
        {
            player1.setMoney(player1.getMoney() + amount);
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
        }
        else
        {
            player2.setMoney(player2.getMoney() + amount);
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
        }
    }
     public void Collect95k(int amount, bool flag)
    {
        if (flag)
        {
            player1.setMoney(player1.getMoney() + amount);
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
        }
        else
        {
            player2.setMoney(player2.getMoney() + amount);
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
        }
    }
     public void Collect100k(int amount, bool flag)
    {
        if (flag)
        {
            player1.setMoney(player1.getMoney() + amount);
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
        }
        else
        {
            player2.setMoney(player2.getMoney() + amount);
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
        }
    }
    public void Pay5k(int amount, bool flag)
    {
        if (flag)
        {
            player1.setMoney(player1.getMoney() - amount);
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
        }
        else
        {
            player2.setMoney(player2.getMoney() - amount);
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
        }
    }
    public void Pay10k(int amount, bool flag)
    {
        if (flag)
        {
            player1.setMoney(player1.getMoney() - amount);
            moneyText.text = "Cash: $" + player1.getMoney().ToString();
        }
        else
        {
            player2.setMoney(player2.getMoney() - amount);
            moneyText.text = "Cash: $" + player2.getMoney().ToString();
        }
    }
    public void PickUpLifeTile(int tile, bool flag)
    {
        if (flag)
        {
            player1.setlifeTile(player1.getlifeTile() + tile);
            LifeTileText.text = "Life Tile: " + player1.getlifeTile().ToString();
        }
        else
        {
            player1.setlifeTile(player2.getlifeTile() + tile);
            LifeTileText.text = "Life Tile: " + player2.getlifeTile().ToString();
        }
    }
    public void Pay5kIfNotInsured(int amount)
    {
        // Add your implementation here
    }
    public void Pay15kIfNotInsured(int amount)
    {
        // Add your implementation here
    }
    public void Pay40kIfNotInsured(int amount)
    {
        // Add your implementation here
    }
    public void Pay50kIfNotInsured(int amount)
    {
        // Add your implementation here
    }
    public void Pay125kIfNotInsured(int amount)
    {
        // Add your implementation here
    }
    public void MissNextTurn()
    {
        // Add your implementation here
    }

    public void DoctorField5k(int amount)
    {
        // Add your implementation here
    }
    public void DoctorField25k(int amount)
    {
        // Add your implementation here
    }
    public void DoctorField100k(int amount)
    {
        // Add your implementation here
    }
    public void TechField10k(int amount)
    {
        // Add your implementation here
    }
    public void TechField25k(int amount)
    {
        // Add your implementation here
    }
    public void SportsField20k(int amount)
    {
        // Add your implementation here
    }
    public void SportsField25k(int amount)
    {
        // Add your implementation here
    }
    public void SportsField30k(int amount)
    {
        // Add your implementation here
    }
    public void SportsField65k(int amount)
    {
        // Add your implementation here
    }
    public void ActorField5k(int amount)
    {
        // Add your implementation here
    }
    public void ActorField15k(int amount)
    {
        // Add your implementation here
    }
    public void ActorField100k(int amount)
    {
        // Add your implementation here
    }
    public void ArtField15k(int amount)
    {
        // Add your implementation here
    }
    public void ArtField20k(int amount)
    {
        // Add your implementation here
    }
    public void ArtField25k(int amount)
    {
        // Add your implementation here
    }
    public void ArtField125k(int amount)
    {
        // Add your implementation here
    }
    public void PoliceField15k(int amount)
    {
        // Add your implementation here
    }
    public void DesignerField5k(int amount)
    {
        // Add your implementation here
    }
    public void DesignerField25k(int amount)
    {
        // Add your implementation here
    }
    public void DesignerField30k(int amount)
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
    public void AddChild(int child, int tile)
    {

    }
    public void GetMarried()
    {
        // Add your implementation here
    }
    public void Twins(int child, int tile)
    {
       
    }
    public void CollectMoneyTimesSpin(int amount)
    {
        // Add your implementation here
    }
    public void EducationField5k(int amount)
    {
        // Add your implementation here
    }
    public void EducationField50k(int amount)
    {
        // Add your implementation here
    }
    public void StartCollege(int amount)
    {
       
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