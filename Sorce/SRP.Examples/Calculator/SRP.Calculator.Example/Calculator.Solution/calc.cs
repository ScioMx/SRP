using System;
using System.Windows.Forms;
using System.Drawing;

namespace Calculator.Separation
{
    public class CalculatorForm : Form
    {

        Button[] b = new Button[10];
        Button bDot, bPlus, bSub, bMul, bDiv, bEqu, bClr;
        Panel panCalc;
        TextBox txtCalc;

        Double dblAcc;
        Double dblSec;
        bool blnClear, blnFrstOpen;
        String strOper;

        public CalculatorForm()
        {
            try
            {
                this.Text = "Calculator";
                txtCalc = new TextBox
                              {
                                  Location = new Point(10, 10),
                                  Size = new Size(150, 10),
                                  ReadOnly = true,
                                  RightToLeft = RightToLeft.Yes
                              };

                panCalc = new Panel
                              {
                                  Size = new Size(200, 200), 
                                  BackColor = Color.Aqua
                              };

                panCalc.Controls.Add(txtCalc);
                addButtons(panCalc);
                this.Size = new Size(200, 225);
                this.Controls.Add(panCalc);

                dblAcc = 0;
                dblSec = 0;
                blnFrstOpen = true;
                blnClear = false;
                strOper = "=";
            }
            catch (Exception e)
            {
                Console.WriteLine("error ......  " + e.StackTrace);
            }
        }

        private void addButtons(Panel p)
        {
            for (int i = 0; i <= 9; i++)
            {
                b[i] = new Button
                           {
                               Text = Convert.ToString(i), 
                               Size = new Size(25, 25), 
                               BackColor = Color.White
                           };
                b[i].Click += btn_clk;
                p.Controls.Add(b[i]);
            }
            b[0].Location = new Point(10, 160);
            b[1].Location = new Point(10, 120);
            b[4].Location = new Point(10, 80);
            b[7].Location = new Point(10, 40);

            b[2].Location = new Point(50, 120);
            b[5].Location = new Point(50, 80);
            b[8].Location = new Point(50, 40);

            b[3].Location = new Point(90, 120);
            b[6].Location = new Point(90, 80);
            b[9].Location = new Point(90, 40);

            bDot = new Button
                       {
                           Size = new Size(25, 25), 
                           Location = new Point(50, 160), 
                           BackColor = Color.White, 
                           Text = "."
                       };
            bDot.Click += btn_clk;

            bPlus = new Button
                        {
                            Size = new Size(25, 25), 
                            Location = new Point(130, 160), 
                            BackColor = Color.White, 
                            Text = "+"
                        };
            bPlus.Click += btn_Oper;

            bSub = new Button
                       {
                           Size = new Size(25, 25), 
                           Location = new Point(130, 120), 
                           BackColor = Color.White, 
                           Text = "-"
                       };
            bSub.Click += btn_Oper;

            bMul = new Button
                       {
                           Size = new Size(25, 25), 
                           Location = new Point(130, 80), 
                           BackColor = Color.White, 
                           Text = "*"
                       };
            bMul.Click += btn_Oper;

            bDiv = new Button
                       {
                           Size = new Size(25, 25), 
                           Location = new Point(130, 40), 
                           BackColor = Color.White, 
                           Text = "/"
                       };
            bDiv.Click += btn_Oper;

            bEqu = new Button
                       {
                           Size = new Size(25, 25), 
                           Location = new Point(90, 160), 
                           BackColor = Color.White, 
                           Text = "="
                       };
            bEqu.Click += btn_equ;

            bClr = new Button
                       {
                           Size = new Size(20, 45), 
                           Location = new Point(170, 40), 
                           BackColor = Color.Orange, 
                           Text = "AC"
                       };
            bClr.Click += btn_clr;

            p.Controls.Add(bDot);
            p.Controls.Add(bPlus);
            p.Controls.Add(bSub);
            p.Controls.Add(bMul);
            p.Controls.Add(bDiv);
            p.Controls.Add(bEqu);
            p.Controls.Add(bClr);
        }

        private void btn_clk(object obj, EventArgs ea)
        {
            if (blnClear)
                txtCalc.Text = "";

            Button b3 = (Button)obj;

            txtCalc.Text += b3.Text;

            if (txtCalc.Text == ".")
                txtCalc.Text = "0.";
            dblSec = Convert.ToDouble(txtCalc.Text);

            blnClear = false;
        }

        private static void Main()
        {
            Application.Run(new CalculatorForm());
        }

        private void btn_Oper(object obj, EventArgs ea)
        {
            Button tmp = (Button)obj;
            strOper = tmp.Text;
            if (blnFrstOpen)
                dblAcc = dblSec;
            else
                Calc();

            blnFrstOpen = false;
            blnClear = true;
        }

        private void btn_clr(object obj, EventArgs ea)
        {
            Clear();
        }

        private void btn_equ(object obj, EventArgs ea)
        {
            Calc();
        }

        private void Calc()
        {
            dblAcc = Calculator.Compute(strOper, dblAcc, dblSec);

            strOper = "=";
            blnFrstOpen = true;
            txtCalc.Text = Convert.ToString(dblAcc);
            dblSec = dblAcc;
        }

        private void Clear()
        {
            dblAcc = 0;
            dblSec = 0;
            blnFrstOpen = true;
            txtCalc.Text = "";
            txtCalc.Focus();

        }
    }
}
