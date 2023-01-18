using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace currency_converter
{
    //a currency converter which takes the given values and converts it to whatever currency the user decides
    // can convert to dollars, pounds, euros, and yen
    public partial class Form1 : Form
    {
        //a dictionary of every currency type and its respective value
        private readonly Dictionary<string, float> _currencyTypes = new Dictionary<string, float>()
        {
            {"dollar", 1f},
            {"pound", 0.76f},
            {"euro", 0.84f},
            {"yen", 104.53f}
        };
        
        private bool _dollarsChecked = false;
        private bool _poundsChecked = false;
        private bool _eurosChecked = false;
        private bool _yenChecked = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        //gets all values from text boxes and turns them into integers
        //compiles it into a total and then called converting process to get a final amount for every currency type
        private void convertButton_Click(object sender, EventArgs e)
        {
            var hundreds = 0f;
            var fiftys = 0f;
            var twentys = 0f;
            var tens = 0f;
            var fives = 0f;
            var ones = 0f;
            if(!String.IsNullOrEmpty(hundredAmmount.Text))  hundreds = Int32.Parse(hundredAmmount.Text) * 100f;
            if(!String.IsNullOrEmpty(fiftyAmount.Text))  fiftys = Int32.Parse(fiftyAmount.Text) * 50f;
            if(!String.IsNullOrEmpty(twentyAmount.Text))  twentys = Int32.Parse(twentyAmount.Text) * 20f;
            if(!String.IsNullOrEmpty(tenAmount.Text))  tens = Int32.Parse(tenAmount.Text) * 10f;
            if(!String.IsNullOrEmpty(fiveAmount.Text))  fives = Int32.Parse(fiveAmount.Text) * 5f;
            if(!String.IsNullOrEmpty(oneAmount.Text) )  ones = Int32.Parse(oneAmount.Text) * 1f;


            var moneyTotal = hundreds + fiftys + twentys + tens + fives + ones;
            
            if(_dollarsChecked)  convert("dollar", moneyTotal);
            if(_poundsChecked)  convert("pound", moneyTotal);
            if(_eurosChecked)  convert("euro", moneyTotal);
            if(_yenChecked) convert("yen", moneyTotal);
        }

        private void label3_Click(object sender, EventArgs e)
        {
          
        }

        //begins converting by finding out what were converting to
        private void convert(string currencyType, float totalMoney)
        {
            foreach (var currency in _currencyTypes)
            {
                if (currencyType == currency.Key)
                {
                    convertValues(currency.Key, currency.Value, totalMoney);
                }
            }
        }

        //converts the given values into final results for every currency type
        private void convertValues(string currencyName, float currencyValue, float totalMoney)
        {
            var dollarResultVal = 0f;
            var poundResult = 0f;
            var euroResult = 0f;
            var yenResultVal = 0f;
            //total times conversion
            foreach (var conversion in _currencyTypes)
                //convert to dollars then convert to other values
            {
                switch (conversion.Key)
                {
                    case "dollar":
                        dollarResultVal = totalMoney * currencyValue * conversion.Value;

                        break;
                    case "pound":
                        poundResult = totalMoney * currencyValue * conversion.Value;

                        break;
                    case "euro":
                        euroResult = totalMoney * currencyValue * conversion.Value;

                        break;
                    case "yen":
                        yenResultVal = totalMoney * currencyValue * conversion.Value;

                        break;
                }

                this.dollarResult.Text = dollarResultVal.ToString();
                this.poundsResult.Text = poundResult.ToString();
                this.eurosResult.Text = euroResult.ToString();
                this.yenResult.Text = yenResultVal.ToString();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //when a radio button is changed, finds out which one is checked and makes all others false
        private void checkConvert()
        {
            _dollarsChecked = false;
            _poundsChecked = false;
            _eurosChecked = false;
            _yenChecked = false;
            
            if (dollarsRadio.Checked) _dollarsChecked = true;
            if (poundsRadio.Checked) _poundsChecked = true;
            if (eurosRadio.Checked) _eurosChecked = true;
            if (yenRadio.Checked) _yenChecked = true;
        }
        
        //listens to a change in all radio buttons
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkConvert();
        }

        private void poundsRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkConvert();
        }

        private void eurosRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkConvert();
        }

        private void yenRadio_CheckedChanged(object sender, EventArgs e)
        {
            checkConvert();
        }

        private void dollarResult_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}