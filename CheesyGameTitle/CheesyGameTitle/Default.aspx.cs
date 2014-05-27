using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheesyGameTitle
{
    public partial class _Default : Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            RatButton.Visible = false;
            bodyDiv.Visible = false;
            
        }

        protected void StartButton_Click(object sender, EventArgs e)
        {
            // Visa knappar efter man trycker på start

            StartButton.Visible = false;
            RulesLink.Visible = false;

            RatButton.Visible = true;
            MouseButton.Visible = true;

            ratCharacter.Visible = true;
        }

        protected void RatButton_Click(object sender, ImageClickEventArgs e)
        {
             // Visa rätt knappar efter man väljer karaktär

            StartButton.Visible = false;
            RulesLink.Visible = false;
            NewTurnButton.Visible = true;
            RatButton.Visible = false;
            MouseButton.Visible = false;

            bodyDiv.Visible = true;
        } 

        protected void NewTurn_Click(object sender, ImageClickEventArgs e)
        {
            StartButton.Visible = false;
            RulesLink.Visible = false;
            NewTurnButton.Visible = true;
            CheeseButton.Visible = false;

            NewTurnButton.Attributes.Add("onclick", "javascript:" + NewTurnButton.ClientID + ".disabled=true;" + ClientScript.GetPostBackEventReference(NewTurnButton, ""));

            if (Session["PrevObject"] == null)
            {
                // Skapa karaktär 1 och läs in stats
                Character player = new Character(1);
                Session["PrevObject"] = player;
            }


            Character prevObj = (Character)Session["PrevObject"];

            prevObj.plusTurn();

            int turn = prevObj.getTurns();

            if (turn == 6)          // På ostrutan
            {
                CombatLog.Text = "Katten sover framför ostskafferiet. Det är en 10% risk att katten vaknar.";
                CheeseButton.Visible = true;
                ratCharacter.Style.Add("left", "70%");
            }

            if(turn == 7)           
            {
                ratCharacter.ImageUrl = "../Images/råtta.png";
                ratCharacter.Style.Add("left", "70%");
            }

            if (turn != 6 && turn < 6)      // På väg dit
            {
                int pixels = (200 * turn);
                string pixelString = pixels.ToString();

                ratCharacter.Style.Add("margin-left", pixelString+"px");

                prevObj = CreateCard(prevObj);

                Session["PrevObject"] = prevObj;
            }

            if (turn != 6 && turn > 6 && turn != 12)      // På väg tillbaka
            {
                ratCharacter.ImageUrl = "../Images/råtta.png";
                ratCharacter.Style.Add("left", "70%");
                int pixels = (200 * (turn - 6));
                string pixelString = pixels.ToString();

                ratCharacter.Style.Add("margin-left", "-" + pixelString + "px");

                prevObj = CreateCard(prevObj);

                Session["PrevObject"] = prevObj;
            }

            cardImage.Visible = true;

            if (turn == 6)
            {
                cardImage.Visible = false;
            }

            if (turn == 12)
            {
                cardImage.Visible = false;
                GameOverWin();
            }
        }

        public Character CreateCard(Character player)
        {
            // Skapa nytt kort
            Card newCard = new Card();

            string header = newCard.GetName();
            string description = newCard.GetDescription();

            // Visa texten
            CardHeader.Text = header;
            CardText.Text = description;

            // Läs av typ av kort
            CardType cardStatus = newCard.GetCardType();


            // ===== Tomt =====
            if (cardStatus == CardType.Empty)
            {
                EmptyCard();
            }

            // ===== Monster =====
            if (cardStatus == CardType.Monster)
            {
                player = MonsterCard(newCard, player);
            }

            // ===== Föremål ======
            if (cardStatus == CardType.Item)
            {
                player = ItemCard(newCard, player);
            }

            // ===== Fälla =====
            if (cardStatus == CardType.Trap)
            {
                player = TrapCard(newCard, player);
            }

            int playerHealth = player.getHealth();
            int playerIntelligence = player.getIntelligence();
            int playerStrength = player.getStrength();
            int playerAgility = player.getAgility();
            string playerName = player.getName();

            statsBox.Text = "Namn: " + playerName + "<br />Hälsa: " + playerHealth + "<br />Styrka: " + playerStrength +
                "<br />Smidighet: " + playerAgility + "<br />Intelligens: " + playerIntelligence;   // Stats

            cardImage.ImageUrl = newCard.getImage();
            return player;
        }

        public void EmptyCard()
        {
        }

        public Character MonsterCard(Card newCard, Character player)
        {
            int loops = 1;
            int monsterHighestAttribute = 0;
            int playerHighestAttribute = 0;

            // Monsterstats

            int monsterHealth = newCard.GetHealth();
            int monsterIntelligence = newCard.GetIntelligence();
            int monsterStrength = newCard.GetStrength();
            int monsterAgility = newCard.GetAgility();
            string monsterName = newCard.GetName();

            // Spelarstats

            int playerHealth = player.getHealth();
            int playerIntelligence = player.getIntelligence();
            int playerStrength = player.getStrength();
            int playerAgility = player.getAgility();
            string playerName = player.getName();

            do
            {
                if (monsterIntelligence > monsterStrength && monsterIntelligence > monsterAgility)      // Int  
                {
                    monsterHighestAttribute = monsterIntelligence;
                    playerHighestAttribute = playerIntelligence;
                }

                else if (monsterStrength > monsterIntelligence && monsterStrength > monsterAgility)     // Str
                {
                    monsterHighestAttribute = monsterStrength;
                    playerHighestAttribute = playerStrength;
                }

                else if (monsterAgility > monsterIntelligence && monsterAgility > monsterStrength)      // Agi
                {
                    monsterHighestAttribute = monsterAgility;
                    playerHighestAttribute = playerAgility;
                }

                // ====== KASTA TÄRNINGEN ==========

                Random random = new Random();

                int dice = random.Next(1, 7);
                int monsterResult = 0;
                int playerResult = 0;
                string boxText;

                monsterResult = monsterHighestAttribute + dice;

                boxText = monsterName + " rullade " + dice + ". (" + monsterHighestAttribute + " + " + dice + " = " + monsterResult + ")";     // Monstrets tärningskast
  

                System.Threading.Thread.Sleep(300);

                dice = random.Next(1, 7);

                playerResult = playerHighestAttribute + dice;

                boxText += "<br />" + playerName + " rullade " + dice + ". (" + playerHighestAttribute + " + " + dice + " = " + playerResult + ")";       // Spelarens tärningskast   

                if (monsterResult > playerResult)       // Monster vinner
                {
                    playerHealth--;
                    boxText += "<br /><b>" + playerName + " tog 1 skada och har nu " + playerHealth + " hälsa kvar.</b>";

                    if (playerHealth <= 0) // Om spelaren är död
                    {
                        GameOver();
                    }
                }

                if (monsterResult < playerResult)       // Spelare vinner
                {
                    monsterHealth--;
                    boxText += "<br /><b>" + monsterName + " tog 1 skada och har nu " + monsterHealth + " hälsa kvar.</b>";

                    if (monsterHealth <= 0) // Om monster död
                    {
                        monsterHealth = 0;
                    }
                }

                if (monsterResult == playerResult)
                {
                    boxText += "<br /><b>Lika! Ingen tar skada.</b>";
                }

                CombatLog.Text += "<br /><br /><b>Drag " + loops + "</b>:<br />" + boxText;
               // LabelRead.Text = CombatLog.Text.Replace(Environment.NewLine, "<BR/>");

                loops++;
            } while (playerHealth != 0 && monsterHealth != 0);

            if (monsterHealth == 0)
            {
                CombatLog.Text += "<br /><b>" + monsterName + " dog!</b>";
            }

            player.setHealth(playerHealth);
            return player;
        }

        public Character ItemCard(Card theCard, Character player)
        {
            int code = theCard.GetActionCode();

            int playerStrength = player.getStrength();
            int playerAgility = player.getAgility();
            int playerIntelligence = player.getIntelligence();
            int playerHealth = player.getHealth();
            string playerName = player.getName();
            int playerMaxHealth = player.getMaxHealth();


            if (code == 1)      // Helande ost
            {
                playerHealth = playerMaxHealth;

                PlayerBox.Text = playerName + " får full hälsa!";
            }

            if (code == 2)      // Möglig Ost
            {
                playerHealth = playerHealth - 3;

                if(playerHealth < 0)        // Om det blir mindre än 0
                {
                    playerHealth = 0;
                }

                PlayerBox.Text = playerName + " -3 hälsa";

                if (playerHealth <= 0)          // Om spelaren dog
                {
                    GameOver();
                }
            }

            if (code == 3)      // Marsvinspellets
            {
                playerStrength = playerStrength + 3;

                PlayerBox.Text = playerName + " +3 styrka!";
            }

            if (code == 4)       // Kaffepulver
            {
                playerAgility = playerAgility + 3;

                PlayerBox.Text = playerName + " +3 smidighet!";
            }

            if (code == 5)       // Broschyr
            {
                playerIntelligence = playerIntelligence + 3;

                PlayerBox.Text = playerName + " +3 intelligens!";
            }

            player.setIntelligence(playerIntelligence);
            player.setStrength(playerStrength);
            player.setAgility(playerAgility);
            player.setHealth(playerHealth);
            return player;
        }

        public Character TrapCard(Card theCard, Character player)
        {
            int code = theCard.GetActionCode();

            int playerStrength = player.getStrength();
            int playerAgility = player.getAgility();
            int playerIntelligence = player.getIntelligence();
            int playerHealth = player.getHealth();
            string playerName = player.getName();
            int playerMaxHealth = player.getMaxHealth();
            Random random = new Random();

            int dice = random.Next(1, 7);
            string boxText;

            if (code == 6)      // Musfälla
            {
                if (dice > playerStrength)
                {
                    playerHealth = playerHealth - 4;

                    if (playerHealth < 0)
                    {
                        playerHealth = 0;
                    }
                }

                boxText = playerName + " rullade " + dice + ".";
                CombatBox.Text = boxText;

                if (playerHealth <= 0)
                {
                    GameOver();
                }
            }

            if (code == 7)      // Kvast-attack!
            {
                if (dice > playerAgility)
                {
                    playerHealth = playerHealth - 4;

                    if (playerHealth < 0)
                    {
                        playerHealth = 0;
                    }
                }

                boxText = playerName + " rullade " + dice + ".";
                CombatBox.Text = boxText;

                if (playerHealth <= 0)
                {
                    GameOver();
                }
            }

            if (code == 8)      // Musfälla
            {
                if (dice > playerIntelligence)
                {
                    playerHealth = playerHealth - 4;

                    if (playerHealth < 0)
                    {
                        playerHealth = 0;
                    }
                }

                boxText = playerName + " rullade " + dice + ".";
                CombatBox.Text = boxText;

                if (playerHealth <= 0)
                {
                    GameOver();
                }
            }

            player.setHealth(playerHealth);
            return player;
        }

        public int CheeseRaid(Cheese cheese)
        {
            cheese.randomCheese();
            string cheeseName = cheese.getName();
            int cheeseValue = cheese.getValue();
            int timesCalled = cheese.getTimesCalled();

            Random random = new Random();

            int catWakes = random.Next(1, 101);

            if (catWakes <= (timesCalled * 10))
            {
                CombatLog.Text = "Katten vaknade och dödade dig innan du hann säga 'pip'!";
                GameOver();
            }

            else
            {
                CombatBox.Text = "Du fick en " + cheeseName + " värde " + cheeseValue + " poäng!";

                cheese.timesCalledPlus();
                timesCalled = cheese.getTimesCalled();
                CombatLog.Text = "Katten sover framför ostskafferiet. Det är en " + (timesCalled * 10) + "% risk att katten vaknar.";
            }

            return cheeseValue;
        }

        public void GameOver()
        {
            StartButton.Visible = false;
            RulesLink.Visible = false;
            NewTurnButton.Visible = false;
            CheeseButton.Visible = false;
            RatButton.Visible = false;


            TryAgainButton.Visible = true; 
        }

        protected void CheeseButton_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["CheeseObject"] == null)
            {
                Cheese cheese = new Cheese();
                Session["CheeseObject"] = cheese;
            }

            StartButton.Visible = false;
            RulesLink.Visible = false;
            NewTurnButton.Visible = true;
            CheeseButton.Visible = true;

            Cheese prevObj = (Cheese)Session["CheeseObject"];
            ratCharacter.Style.Add("left", "70%");

            GlobalScore.SCORE += CheeseRaid(prevObj);
            Session["CheeseObject"] = prevObj;

            
        }

        protected void TryAgainButton_Click(object sender, ImageClickEventArgs e)
        {
            Session["CheeseObject"] = null;
            Session["PrevObject"] = null;
            GlobalScore.SCORE = 0;

            Response.Redirect(Request.RawUrl);
        }

        public void GameOverWin()
        {
            StartButton.Visible = false;
            RulesLink.Visible = false;
            NewTurnButton.Visible = false;
            CheeseButton.Visible = false;
            RatButton.Visible = false;

            CombatLog.Text = "GRATTIS! Du överlevde och fick " + GlobalScore.SCORE + " poäng!";
            TryAgainButton.Visible = true;
        }
    }
}