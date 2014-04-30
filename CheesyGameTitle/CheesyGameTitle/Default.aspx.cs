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
            StartButton.Visible = false;
            RulesLink.Visible = false;

            RatButton.Visible = true;
            MouseButton.Visible = true;

            


            Character player = new Character(1);


        }

        protected void RatButton_Click(object sender, ImageClickEventArgs e)
        {
            StartButton.Visible = false;
            RulesLink.Visible = false;
            NewTurnButton.Visible = true;
            RatButton.Visible = false;
            MouseButton.Visible = false;
        } 

        protected void NewTurn_Click(object sender, EventArgs e)
        {
            StartButton.Visible = false;
            RulesLink.Visible = false;
            NewTurnButton.Visible = true;

            

            Card newCard = new Card();

            string header = newCard.GetName();

            string description = newCard.GetDescription();

            System.Threading.Thread.Sleep(2000);
            CardHeader.Text = header;
            CardText.Text = description;
        }

        
    }
}