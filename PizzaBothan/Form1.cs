using System.Reflection.Metadata;

namespace PizzaBothan
{
    public partial class PizzaBothan : Form
    {
        //Prices dont change so setting constants for calculations.
        private const Decimal HamPizzaPrice = 7.99m;
        private const Decimal PepperoniPizzaPrice = 8.99m;
        private const Decimal PineapplePizzaPrice = 9.99m;
        private const Decimal CalzoniPrice = 12.99m;
        
        //Creating variables for calcultions for later in summary tables
        private int OverallHam, OverallPepperoni, OverallPineapple, OverallCalzoni;
        private int CompanyTransactions, TotalPizzasOrdered;
        private decimal CompanyReceipts, AvgTransaction;


        public PizzaBothan()
        {
            InitializeComponent();

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            //making other views false for start up, and naming form for second page view//
            MenuBox.Visible = true;
            HamPizzaTxtBox.Focus();
            var ServerName = ServerNameTxtBox.Text;
            var TableNumber = TableNumberTxtBox.Text;
            this.Text = ServerName + " @ Table " + TableNumber;

            ServerNameBox.Visible = false;
            PictureBox1.Visible = false;
            ButtonBox.Visible = true;
            SummaryBtn.Enabled = false;
            pictureBox2.Visible = true;
        }
        private void OrderBtn_Click(object sender, EventArgs e)
        {
            //Creating local Variables 
            int HamPizzaOrderd, PepperoniPizzaOrderd, PineapplePizzaOrderd, CalzoniOrderd, TotalPizzasSold;

            decimal TotalTableRecipts;


            //Changing text values to deisired variables by parsing method.
            try
            {
                HamPizzaOrderd = int.Parse(HamPizzaTxtBox.Text);
                

                try
                {
                    PepperoniPizzaOrderd = int.Parse(PepperoniTxtBox.Text);

                    try
                    {
                        PineapplePizzaOrderd = int.Parse(PineappleTxtBox.Text);

                        try
                        {
                            CalzoniOrderd = int.Parse(CalzoniTxtBox.Text);

                            //Calculations for Table Order Summary Data 

                            TotalTableRecipts = HamPizzaPrice * HamPizzaOrderd + PepperoniPizzaPrice * PepperoniPizzaOrderd
                            + PineapplePizzaOrderd * PineapplePizzaPrice + CalzoniOrderd + CalzoniPrice;
                            
                            TotalPizzasSold = HamPizzaOrderd + PineapplePizzaOrderd + PepperoniPizzaOrderd + CalzoniOrderd;

                            OverallHam = OverallHam + HamPizzaOrderd;
                            OverallPepperoni = OverallPepperoni + PepperoniPizzaOrderd;
                            OverallPineapple = OverallPineapple + PepperoniPizzaOrderd;
                            OverallCalzoni = OverallCalzoni + CalzoniOrderd;

                            CompanyTransactions = CompanyTransactions + 1;
                          
                            ServerNameSummaryLabel.Text = ServerNameTxtBox.Text;
                            NumberPizzasLabel.Text = TotalPizzasSold.ToString();
                            TableReceiptsLabel.Text = TotalTableRecipts.ToString("C");

                           //Toggling with table visibility for next step of form.

                            TableOrderDataBox.Visible = true;
                            OrderBtn.Enabled = false;
                            MenuBox.Enabled = false;
                            this.Text = "Table Summary";
                            SummaryBtn.Enabled = true;
                            ClearBtn.Focus();
                           
                        }

                        //Helping user with messageboxs and walking them through any areas where
                        //they may have entered incorrect data
                        catch
                        {
                            MessageBox.Show("Please enter numercial value for Calzonis ", "Invalid Input",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CalzoniTxtBox.Focus();
                            CalzoniTxtBox.SelectAll();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please enter numercial value for Pineapple Pizza's ", "Invalid Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PineappleTxtBox.Focus();
                        PineappleTxtBox.SelectAll();
                    }
                }
                catch
                {
                    MessageBox.Show("Please enter numercial value for Pepperoni Pizza's ", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PepperoniTxtBox.Focus();
                    PepperoniTxtBox.SelectAll();
                }
            }
            catch
            {
                MessageBox.Show("Please enter numercial value for Ham Pizza's ", "Invalid Input",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                HamPizzaTxtBox.Focus();
                HamPizzaTxtBox.SelectAll();
            }

        }
        private void ClearBtn_Click(object sender, EventArgs e)

         //Bringing user back to start of form to add additional orders.
        {
            ServerNameBox.Visible = true;
            MenuBox.Visible = false;
            TableOrderDataBox.Visible = false;
            ButtonBox.Visible = false;
            ServerNameBox.Text = "";
            TableNumberTxtBox.Text = "0";
            HamPizzaTxtBox.Text = "0";
            PepperoniTxtBox.Text = "0";
            PineappleTxtBox.Text = "0";
            CalzoniTxtBox.Text = "0";
            NumberPizzasLabel.Text = "0";
            TableReceiptsLabel.Text = "0";
            ServerNameBox.Focus();
            MenuBox.Enabled = true;
            OrderBtn.Enabled = true;

        }

        private void SummaryBtn_Click(object sender, EventArgs e)
   
        
        {
            OrderBtn.Enabled = false;
            SummaryBtn.Enabled = false;
            MenuBox.Visible = false;
            TableOrderDataBox.Visible = false;
            PizzaSoldBox.Visible = true;
            CompanySummaryDataBox.Visible = true;
            this.Text = "Company Summary Data";

            //Output to Summary Tables

            HamSoldTxtBox.Text = OverallHam.ToString();
            PepperoniSoldTxtBox.Text = OverallPepperoni.ToString();
            PineappleSoldTxtBox.Text = OverallPineapple.ToString();
            CalzoniSoldTxtBox.Text = OverallCalzoni.ToString();

            //Calculations for Company Summary Data 

            TotalPizzasOrdered = OverallHam + OverallPepperoni + OverallPineapple + OverallCalzoni;
          
            TotalNumberPizzasCompanyLabel.Text = TotalPizzasOrdered.ToString();
           
            CompanyReceipts = OverallHam * HamPizzaPrice + OverallPepperoni * PepperoniPizzaPrice +
            OverallPineapple * PineapplePizzaPrice + OverallCalzoni * CalzoniPrice;

            TotalCompanyReceiptsLabel.Text = "€" + CompanyReceipts.ToString();

            AvgTransaction = CompanyReceipts / CompanyTransactions;

            TotalTransactionLabel.Text = CompanyTransactions.ToString();



            AvgTransactionValueLabel.Text =  AvgTransaction.ToString("C2");

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //Adding exit button so user can fully close application.
            this.Close();

        }

    }
}

    




