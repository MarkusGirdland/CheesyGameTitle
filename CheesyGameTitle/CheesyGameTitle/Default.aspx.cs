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
        }

        protected void StartButton_Click(object sender, EventArgs e)
        {
            // Visa knappar efter man trycker på start

            StartButton.Visible = false;
            RulesLink.Visible = false;

            RatButton.Visible = true;
            MouseButton.Visible = true;
        }

        protected void RatButton_Click(object sender, ImageClickEventArgs e)
        {
             // Visa rätt knappar efter man väljer karaktär

            StartButton.Visible = false;
            RulesLink.Visible = false;
            NewTurnButton.Visible = true;
            RatButton.Visible = false;
            MouseButton.Visible = false;
        } 

        protected void NewTurn_Click(object sender, ImageClickEventArgs e)
        {
            StartButton.Visible = false;
            RulesLink.Visible = false;
            NewTurnButton.Visible = true;

            if (Session["PrevObject"] == null)
            {
                // Skapa karaktär 1 och läs in stats
                Character player = new Character(1);
                Session["PrevObject"] = player;
            }

            Character prevObj = (Character)Session["PrevObject"];

            // TODO: Disable newTurn knapp samt visa det visuellt

            prevObj = CreateCard(prevObj);

            Session["PrevObject"] = prevObj;
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

            return player;
        }

        public void EmptyCard()
        {
            // TODO: Visa kortet som dras
        }

        public Character MonsterCard(Card newCard, Character player)
        {
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

            // TODO: Tona ner bakgrund samt visa två kort

            if (monsterIntelligence > monsterStrength && monsterIntelligence > monsterAgility)      // Int  
            {
                MonsterBox.Text = monsterName + "<br />Hälsa: " + monsterHealth + "<br />Intelligens: " + monsterIntelligence;

                PlayerBox.Text = playerName + "<br />Hälsa: " + playerHealth + "<br />Intelligens: " + playerIntelligence;

                monsterHighestAttribute = monsterIntelligence;
                playerHighestAttribute = playerIntelligence;
            }

            else if (monsterStrength > monsterIntelligence && monsterStrength > monsterAgility)     // Str
            {
                MonsterBox.Text = monsterName + "<br />Hälsa: " + monsterHealth + "<br />Styrka: " + monsterStrength;

                PlayerBox.Text = playerName + "<br />Hälsa: " + playerHealth + "<br />Styrka: " + playerStrength;

                monsterHighestAttribute = monsterStrength;
                playerHighestAttribute = playerStrength;
            }

            else if (monsterAgility > monsterIntelligence && monsterAgility > monsterStrength)      // Agi
            {
                MonsterBox.Text = monsterName + "<br />Hälsa: " + monsterHealth + "<br />Smidighet: " + monsterAgility;

                PlayerBox.Text = playerName + "<br />Hälsa: " + playerHealth + "<br />Smidighet: " + playerAgility;

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
            CombatBox.Text = boxText;

            System.Threading.Thread.Sleep(1000);

            dice = random.Next(1, 7);

            playerResult = playerHighestAttribute + dice;

            boxText += "<br />" + playerName + " rullade " + dice + ". (" + playerHighestAttribute + " + " + dice + " = " + playerResult + ")";       // Spelarens tärningskast   
            CombatBox.Text = boxText;

            // ===== RESULTAT =======

            // TODO: Lägg in -1 bild


            if (monsterResult > playerResult)       // Monster vinner
            {
                playerHealth--;

                if (playerHealth <= 0) // Om spelaren är död
                {
                    GameOver();
                }

                else
                {
                    // TODO: -1 bild
                }
            }

            if (monsterResult < playerResult)       // Spelare vinner
            {
                monsterHealth--;

                if (monsterHealth <= 0) // Om monster död
                {
                }

                else
                {
                    // TODO: -1 bild
                }
            }

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

                PlayerBox.Text = playerName + "<br />Hälsa: " + playerHealth;
            }

            if (code == 2)      // Möglig Ost
            {
                playerHealth = playerHealth - 3;

                if(playerHealth < 0)        // Om det blir mindre än 0
                {
                    playerHealth = 0;
                }

                PlayerBox.Text = playerName + "<br />Hälsa: " + playerHealth;

                if (playerHealth <= 0)          // Om spelaren dog
                {
                    GameOver();
                }
            }

            if (code == 3)      // Marsvinspellets
            {
                playerStrength = playerStrength + 3;

                PlayerBox.Text = playerName + "<br />Styrka: " + playerStrength;
            }

            if (code == 4)       // Kaffepulver
            {
                playerAgility = playerAgility + 3;

                PlayerBox.Text = playerName + "<br />Smidighet: " + playerAgility;
            }

            if (code == 5)       // Broschyr
            {
                playerIntelligence = playerIntelligence + 3;

                PlayerBox.Text = playerName + "<br />Intelligens: " + playerIntelligence;
            }

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

                PlayerBox.Text = playerName + "<br />Hälsa: " + playerHealth + "<br />Styrka: " + playerStrength;

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

                PlayerBox.Text = playerName + "<br />Hälsa: " + playerHealth + "<br />Smidighet: " + playerAgility;

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

                PlayerBox.Text = playerName + "<br />Hälsa: " + playerHealth + "<br />Intelligens: " + playerIntelligence;

                boxText = playerName + " rullade " + dice + ".";
                CombatBox.Text = boxText;

                if (playerHealth <= 0)
                {
                    GameOver();
                }
            }

            return player;
        }

        public void GameOver()
        {
            // TODO: Game over
        }
    }
}