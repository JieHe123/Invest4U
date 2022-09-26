using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invest4U
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int LoginCount = 0;

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Text = "Enter investment principal";
            //Declare password=ShowMeTheMoney#;
            const string password = "ShowMeTheMoney#";

            //The valid password is "ShowMeTheMoney#", if input password less than 4 times, an error message will be shown. 
            bool ValidPassword = PasswordTextBox.Text == password;
            if (!ValidPassword)
            {
                LoginCount++;

                //if input password wrong less than 4 times,show a message
                if (LoginCount < 4)
                {
                    MessageBox.Show("Sorry, Invalid data entered. Please try again",
                                                     "Data Entry Error",
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Error
                                                     );
                    PasswordTextBox.Focus();
                    PasswordTextBox.SelectAll();
                }



                //when input wrong messages for four times, the application closes with a message to the user 
                if (LoginCount >= 4)
                {

                    MessageBox.Show("Sorry, you have entered the wrong password for 4 times, the app will automaticly close",
                           "Warning",
                           MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Warning
                           );
                    this.Close();
                }


            }
            else
            {
                LogInPanel.Visible = false;
                ButtonPanel.Visible = true;
                InvestmentPriciplePanel.Visible = true;
                InvestmentOptionsGroupBox.Visible = true;
                InvestorDetailsGroupBox.Visible = true;
                TopPictureBox.Visible = true;
                BottomPictureBox.Visible = true;
                SearchTransactionGroupBox.Visible = true;


            }
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            this.Text = "Dispaly the investment term";
            //constant for the monthly interest rate for investment priciple less than 100000.

            const decimal InterestRateOneYearL = 0.00005m, InterestRateThreeYearsL = 0.0000625m,
                InterestRateFiveYearsL = 0.00007125m, InterestRateTenYearsL = 0.0001125m;

            //constant for the monthly interest rate for investment priciple greater than 100000.
            const decimal InterestRateOneYearH = 0.00006m, InterestRateThreeYearsH = 0.0000725m,
                InterestRateFiveYearsH = 0.00008125m, InterestRateTenYearsH = 0.000125m;

            //constant for the months.
            const int monthsOneYear = 12, monthsThreeYear = 36, monthsFiveYear = 60, monthsTenYear = 120;



            //Local variables
            decimal balance;
            int months;
            int DisplayCount = 1;



            //Get the Investment Principal
            if (decimal.TryParse(InvestmentPrincipalTextBox.Text, out balance))
            {
                decimal tempBalance = balance;
                //The following loop caculate the total balance of investment pricipal less or equal than 100000 euros.
                if (balance <= 100000)
                {

                    while (DisplayCount <= monthsOneYear)
                    {

                        //Add this months's interest into balance
                        balance = balance + (InterestRateOneYearL * balance);

                        //months will add by one
                        DisplayCount++;
                        OneYearBalanceTextBox.Text = Math.Round(balance, 4).ToString();
                        OneYearInterestRateTextBox.Text = InterestRateOneYearL.ToString();

                    }
                    balance = tempBalance;
                    DisplayCount = 1;
                    while (DisplayCount <= monthsThreeYear)
                    {

                        //Add this months's interest into balance
                        balance = balance + (InterestRateThreeYearsL * balance);

                        //months will add by one
                        DisplayCount++;
                        ThreeYearBalanceTextBox.Text = Math.Round(balance, 2).ToString();
                        ThreeYearInterestRateTextBox.Text = InterestRateThreeYearsL.ToString();

                    }

                    balance = tempBalance;
                    DisplayCount = 1;
                    while (DisplayCount <= monthsFiveYear)
                    {

                        //Add this months's interest into balance
                        balance = balance + (InterestRateFiveYearsL * balance);

                        //months will add by one
                        DisplayCount++;
                        FiveYearBalanceTextBox.Text = Math.Round(balance, 2).ToString();
                        FiveYearInterestRateTextBox.Text = InterestRateFiveYearsL.ToString();

                    }

                    balance = tempBalance;
                    DisplayCount = 1;
                    while (DisplayCount <= monthsTenYear)
                    {

                        //Add this months's interest into balance
                        balance = balance + (InterestRateTenYearsL * balance);

                        //months will add by one
                        DisplayCount++;
                        TenYearBalanceTextBox.Text = Math.Round(balance, 2).ToString();
                        TenYearInterestRateTextBox.Text = InterestRateTenYearsL.ToString();

                    }
                }
                else if (balance > 100000)
                {
                    balance = tempBalance;
                    DisplayCount = 1;
                    while (DisplayCount <= monthsTenYear)
                    {

                        //Add this months's interest into balance
                        balance = balance + (InterestRateOneYearH * balance);

                        //months will add by one
                        DisplayCount++;
                        OneYearBalanceTextBox.Text = Math.Round(balance, 2).ToString();
                        OneYearInterestRateTextBox.Text = InterestRateOneYearH.ToString();

                    }

                    balance = tempBalance;
                    DisplayCount = 1;
                    while (DisplayCount <= monthsTenYear)
                    {

                        //Add this months's interest into balance
                        balance = balance + (InterestRateThreeYearsH * balance);

                        //months will add by one
                        DisplayCount++;
                        ThreeYearBalanceTextBox.Text = Math.Round(balance, 2).ToString();
                        ThreeYearInterestRateTextBox.Text = InterestRateThreeYearsH.ToString();

                    }

                    balance = tempBalance;
                    DisplayCount = 1;
                    while (DisplayCount <= monthsFiveYear)
                    {

                        //Add this months's interest into balance
                        balance = balance + (InterestRateFiveYearsH * balance);

                        //months will add by one
                        DisplayCount++;
                        FiveYearBalanceTextBox.Text = Math.Round(balance, 2).ToString();
                        FiveYearInterestRateTextBox.Text = InterestRateFiveYearsH.ToString();

                    }

                    balance = tempBalance;
                    DisplayCount = 1;
                    while (DisplayCount <= monthsTenYear)
                    {

                        //Add this months's interest into balance
                        balance = balance + (InterestRateTenYearsH * balance);

                        //months will add by one
                        DisplayCount++;
                        TenYearBalanceTextBox.Text = Math.Round(balance, 2).ToString();
                        TenYearInterestRateTextBox.Text = InterestRateTenYearsH.ToString();

                    }
                }
                InvestmentOptionsGroupBox.Enabled = true;
            }
            else
            {
                MessageBox.Show("Sorry, Invalid data entered. Please enter numberic data for number of the Investment Principal",
                                     "Data Entry Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error
                                     );
                InvestmentPrincipalTextBox.Focus();
                InvestmentPrincipalTextBox.SelectAll();
                return;

            }
        }


        private void ProceedButton_Click(object sender, EventArgs e)
        {
            this.Text = "Proceed the celected investment";
            //declare TransactionRadom
            Random TransactionRandom = new Random();
            bool unique = false;
            string UniqueTransactionNo;
            bool isCheched = false;

            foreach (var item in TermPanel.Controls)
            {
                if (item is RadioButton radio)
                {
                    if (radio.Checked)
                    {

                        do
                        {
                            //get an eight-character transaction number range from 10000000 to 99999999
                            UniqueTransactionNo = TransactionRandom.Next(10000000, 99999999).ToString();

                            //use a GetfileStr method to list all exited transaction number in "I4U_TransactionFile.txt"
                            string fileStr = GetFileStr();

                            //If new tranction number is not conntains in "I4U_TransactionFile.txt", then unique is true
                            if (!fileStr.Contains(UniqueTransactionNo + " "))
                            {
                                unique = true;
                            }

                        } while (!unique);


                        TransactionNoTextBox.Text = UniqueTransactionNo;
                        isCheched = true;
                        //show a short style date on DateTextbox
                        DateTime CurrentTime = DateTime.Now;
                        DateTextBox.Text = CurrentTime.ToShortDateString();
                    }
                }

            }
            if (!isCheched)
            {
                MessageBox.Show("Please select a term first to proceed.",
                                              "Haven't selected a term yet",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Error
                                              );


            }

        }

        //Declare balanceStr
     
        string balanceStr = "";
        decimal totalInvestmentPricipal, totalBalance;
        int totalInvestTimes = 0, totalYears;


        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Text = "Submit the investment";
            if (InvestmentPrincipalTextBox.Text.Length==0)
            {
                //Dispaly an error message
                MessageBox.Show("Please click Proceed before submit",
                                                     "Button click Error",
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Error
                                                     );
                return;
            }
            decimal InvestmentPricipal = decimal.Parse(InvestmentPrincipalTextBox.Text);
            decimal balance = decimal.Parse(balanceStr);
               
                string ClientName = ClientNameTextBox.Text;
                string PhoneNo = PhoneNoTextBox.Text;
                string email = EmailTextBox.Text;


          if(ClientName.Length==0|| PhoneNo.Length == 0|| email.Length == 0)
            {

                //Dispaly an error message
                MessageBox.Show("Sorry, Invalid data entered. Please try again",
                                                     "Data Entry Error",
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Error
                                                     );
                return;
            }


            //Declare of the year
            string yearStr = getYearStr();

            //Messagebox show the details of the transaction and client
            DialogResult dialogResult = MessageBox.Show("Please check if below transaction information are all correct?"
                + "\nThe transaction number is: " + TransactionNoTextBox.Text
                + "\nThe date is: " + DateTextBox.Text
                + "\nThe email of client is: " + EmailTextBox.Text
                + "\nThe name of client is: " + ClientNameTextBox.Text
                 + "\nThe phone no.of client is: " + PhoneNoTextBox.Text
                  + "\nThe investment Pricipal is: " + InvestmentPrincipalTextBox.Text
                  + "\nThe year of investment is: " + yearStr
                   + "\nThe total balance is: " + balanceStr,




                                                     "Check information",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Information
                                                      );
            if (dialogResult == DialogResult.Yes)
            {


                //Declare a StreamWriter Variable
                StreamWriter outputFile;
                //Create a file
                outputFile = File.AppendText("I4U_TransactionFile.txt");
                //Write contents to the file
                outputFile.Write(TransactionNoTextBox.Text + " | ");
                outputFile.Write(DateTextBox.Text + " | ");
                outputFile.Write(EmailTextBox.Text + " | ");
                outputFile.Write(ClientNameTextBox.Text + " | ");
                outputFile.Write(PhoneNoTextBox.Text + " | ");
                outputFile.Write(InvestmentPrincipalTextBox.Text + " | ");
                outputFile.Write(yearStr + " | ");
                outputFile.WriteLine(balanceStr);
                //close the file
                outputFile.Close();
                //Let the user know the contents have been written
                MessageBox.Show("The transaction contents were written",
                                                    "Data Entered successfully",
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Information
                                                     );


                //Clear the textboxes
                DoClear();

                //declare variables
                totalInvestmentPricipal += InvestmentPricipal;
                totalBalance += balance;
                totalInvestTimes++;
                int investedYear = int.Parse(yearStr);
                totalYears += investedYear;

            }
            else
            {
                MessageBox.Show("Operate cancelled.");
                DoClear();
            }







        }

        //A method to show the year which be checked by radio button.
        private string getYearStr()
        {
            string yearStr = "";
            //To ensure any radio buttom has been cheked and get only the number of the year  from radio.text
            foreach (var item in TermPanel.Controls)
            {
                if (item is RadioButton radio)
                {
                    if (radio.Checked)
                    {
                        yearStr = radio.Text.Substring(0, radio.Text.IndexOf(' '));
                    }
                }
            }
            return yearStr;
        }

        //The Method to show the final balance of which checked by the radio button.
        private void OneYearRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton chk)
            {
                if (chk.Checked == true)
                {
                    balanceStr = OneYearBalanceTextBox.Text;
                }
            }
        }
        //The Method to show the final balance of which checked by the radio button.
        private void ThreeYearRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton chk)
            {
                if (chk.Checked == true)
                {
                    balanceStr = ThreeYearBalanceTextBox.Text;
                }
            }
        }
        //The Method to show the final balance of which checked by the radio button.
        private void FiveYearRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton chk)
            {
                if (chk.Checked == true)
                {
                    balanceStr = FiveYearBalanceTextBox.Text;
                }
            }
        }
        //The Method to show the final balance of which checked by the radio button.
        private void TenYearRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton chk)
            {
                if (chk.Checked == true)
                {
                    balanceStr = TenYearBalanceTextBox.Text;
                }
            }
        }


        private void SummaryButton_Click(object sender, EventArgs e)
        {
            this.Text = "Summary of all investment records";
            SummaryGroupBox.Visible = true;
            InvestmentOptionsGroupBox.Visible = false;
            InvestorDetailsGroupBox.Visible = false;



            try
            {
                //Declare a variable to hold a transaction number
                string lineString;

                //Declare a StreamReader variable
                StreamReader inputFile;
                //Open the file and get a StreamReader subject
                inputFile = File.OpenText("I4U_TransactionFile.txt");
                //Clean the listbox
                TransactionNoListBox.Items.Clear();
                //Read file contents
                while (!inputFile.EndOfStream)
                {
                    lineString = inputFile.ReadLine();
                    //Ensure that the transaction number is not null
                    if (lineString.Length > 7)
                    {
                        string transactionNo = "";
                        string date = "";
                        string email = "";
                        string name = "";
                        string phoneNumber = "";
                        string investmentPricipal = "";
                        string investedTerm = "";
                        string totalBalance = "";
                        SearchFile(lineString, out transactionNo, out date, out email, out name, out phoneNumber, out investmentPricipal, out investedTerm, out totalBalance);

                        this.totalInvestmentPricipal += decimal.Parse(investmentPricipal);
                        this.totalBalance += decimal.Parse(totalBalance);
                        this.totalInvestTimes ++;
                        this.totalYears += int.Parse(investedTerm);
                        //Get the eight digital transaction number from a long line string
                        string transactionNo8 = transactionNo.Substring(0, 8);
                        //Add trasaction number to listbox
                        TransactionNoListBox.Items.Add(transactionNo8);
                    }

                }
                //Close the file
                inputFile.Close();
            }
            catch (Exception)
            {
                //Dispaly an error message
                MessageBox.Show("Error occured");

            }
            TotalAmountInvestedTextBox.Text = totalInvestmentPricipal.ToString();
            TotalInterestTextBox.Text = (totalBalance - totalInvestmentPricipal).ToString();
            AverageAmountTextBox.Text = ((decimal)totalInvestmentPricipal / (decimal)totalInvestTimes).ToString();
            AverageDurationTextBox.Text = ((double)totalYears / (double)totalInvestTimes).ToString();
        }
        private void clearButton2_Click(object sender, EventArgs e)
        {
            //use the method of Doclear
            DoClear();
        }

        private void Exitbutton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.Text = "Search the investment records";
            //If searchText.text is null, show a messagebox
            if (SearchTextBox.Text.Length == 0)
            {
                MessageBox.Show("There is no investment record by now, please submit first.",
                     "Have no investment record",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                return;
            }
            try
            {
                //Declare a variable to hold a transaction number
                string lineString;

                //Declare a StreamReader variable
                StreamReader inputFile;
                //Open the file and get a StreamReader subject
                inputFile = File.OpenText("I4U_TransactionFile.txt");
                //Clean the listbox
                TransactionNoListBox.Items.Clear();

                while (!inputFile.EndOfStream)
                {
                    ////Read file contents
                    lineString = inputFile.ReadLine();

                    if (lineString.Length > 7 && lineString.Contains(SearchTextBox.Text))
                    {
                        string transactionNo = "";
                        string date = "";
                        string email = "";
                        string name = "";
                        string phoneNumber = "";
                        string investmentPricipal = "";
                        string investedTerm = "";
                        string totalBalance = "";
                        SearchFile(lineString, out transactionNo, out date, out email, out name, out phoneNumber, out investmentPricipal, out investedTerm, out totalBalance);
                        SearchListBox.Items.Add("Transaction no.:" + transactionNo);
                        SearchListBox.Items.Add("date:" + date);
                        SearchListBox.Items.Add("email:" + email);
                        SearchListBox.Items.Add("name:" + name);
                        SearchListBox.Items.Add("phoneNumber:" + phoneNumber);
                        SearchListBox.Items.Add("investmentPricipal:" + investmentPricipal);
                        SearchListBox.Items.Add("investedTerm:" + investedTerm);
                        SearchListBox.Items.Add("totalBalance:" + totalBalance);
                        //Add a blank line value to achieve the function of line feed
                        SearchListBox.Items.Add("");

                    }

                }
                //Close the file
                inputFile.Close();
            }
            catch (Exception)
            {
                //Dispaly an error message
                MessageBox.Show("Error occured");

            }
        }
        private void SearchFile(string lineString, out string transactionNo, out string date, out string email,
            out string name, out string phoneNumber, out string investmentPricipal, out string investedTerm, out string totalBalance)
        {
            //if lineString length>7, add lineString(Transaction no.) to listbox from first character to the character before ' |'
            transactionNo = lineString.Substring(0, lineString.IndexOf('|') - 1);

            //show lineString from the character from index of('|')+2 to the end of the line.
            lineString = lineString.Substring(lineString.IndexOf('|') + 2,
                lineString.Length - (lineString.IndexOf('|') + 2));

            //select lineString(date) from first character to the character before ' |'
            date = lineString.Substring(0, lineString.IndexOf('|') - 1);

            //show lineString from the character ('|')+2 to the end of the line.
            lineString = lineString.Substring(lineString.IndexOf('|') + 2,
                lineString.Length - lineString.IndexOf('|') - 2);
            //select lineString(email) from first character to the character before ' |'
            email = lineString.Substring(0, lineString.IndexOf('|') - 1);

            //show lineString from the character ('|')+2 to the end of the line.
            lineString = lineString.Substring(lineString.IndexOf('|') + 2,
                lineString.Length - lineString.IndexOf('|') - 2);
            // select lineString(client's name) from first character to the character before ' |'
            name = lineString.Substring(0, lineString.IndexOf('|') - 1);

            //show lineString from the character ('|')+2 to the end of the line.
            lineString = lineString.Substring(lineString.IndexOf('|') + 2,
                lineString.Length - lineString.IndexOf('|') - 2);
            // select lineString(client's phone number) from first character to the character before ' |'
            phoneNumber = lineString.Substring(0, lineString.IndexOf('|') - 1);

            //show lineString from the character ('|')+2 to the end of the line.
            lineString = lineString.Substring(lineString.IndexOf('|') + 2,
               lineString.Length - lineString.IndexOf('|') - 2);
            //select lineString(investment principle) from first character to the character before ' |'
            investmentPricipal = lineString.Substring(0, lineString.IndexOf('|') - 1);

            //show lineString from the character ('|')+2 to the end of the line.
            lineString = lineString.Substring(lineString.IndexOf('|') + 2,
              lineString.Length - lineString.IndexOf('|') - 2);
            // select lineString(invested Term) from first character to the character before ' |'
            investedTerm = lineString.Substring(0, lineString.IndexOf('|') - 1);

            //show lineString from the character ('|')+2 to the end of the line.
            lineString = lineString.Substring(lineString.IndexOf('|') + 2,
              lineString.Length - lineString.IndexOf('|') - 2);
            //select lineString(balance) from first character to the character before ' |'
            totalBalance = lineString;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {

            SearchTextBox.Text = "";
            if (SearchListBox.Items.Count > 0)
            {
                SearchListBox.Items.Clear();
            }
        }

        private void DoClear()
        {
            InvestmentPrincipalTextBox.Text = "";
            TransactionNoTextBox.Text = "";
            DateTextBox.Text = "";
            ClientNameTextBox.Text = "";
            PhoneNoTextBox.Text = "";
            EmailTextBox.Text = "";

            //clear all textbox.text in InvestmentOptionsGroupBox
            foreach (var item in SummaryGroupBox.Controls)
            {
                TransactionNoListBox.Items.Clear();
                if (item is TextBox txt)
                {
                    txt.Text = "";
                }

            }
            foreach (var item in InvestmentOptionsGroupBox.Controls)
            {

                if (item is TextBox txt)
                {
                    txt.Text = "";
                }
            }
            //clear all radiobutton.click in TermPanel
            foreach (var item in TermPanel.Controls)
            {
                if (item is RadioButton radio)
                {
                    radio.Checked = false;
                }
            }
        }
        private string GetFileStr()
        {
            string fileStr = "";
            try
            {
                //Declare a variable to hold a transaction number
                String transactionNo;

                //Declare a StreamReader variable
                StreamReader inputFile;
                //Open the file and get a StreamReader subject
                inputFile = File.OpenText("I4U_TransactionFile.txt");
                //Clean the listbox
                TransactionNoListBox.Items.Clear();
                //Read file contents
                while (!inputFile.EndOfStream)
                {
                    transactionNo = inputFile.ReadLine();
                    if (transactionNo.Length > 7)
                    {
                        //Substring(0,9) to contain a space to avoid too long nubmeric string
                        string code = transactionNo.Substring(0, 9);

                        fileStr += code;
                    }

                }
                //Close the file
                inputFile.Close();
            }
            catch (Exception)
            {
                //Dispaly an error message
                MessageBox.Show("Error occured");

            }
            return fileStr;
        }
    }
}
