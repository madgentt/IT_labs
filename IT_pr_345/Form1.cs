using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_pr_4
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      radioButton1.Checked = false;
      label2.Visible = false;
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      Fx_switch = 1;
      label1.Text = "Введите x";
      textBox1.Visible = true;
      label1.Visible = true;
      textBox2.Visible = true;
      listBox1.Visible = false;
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
      Fx_switch = 2;
      label1.Text = "Введите x";
      textBox1.Visible = true;
      label1.Visible = true;
      textBox2.Visible = true;
      listBox1.Visible = false;
    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
      Fx_switch = 3;
      label1.Text = "Введите x";
      textBox1.Visible = true;
      label1.Visible = true;
      textBox2.Visible = true;
      listBox1.Visible = false;
    }

    int Fx_switch = 0;


    public void pr_3(double x)
    {
      double y = 0;
      switch (Fx_switch)
      {
        case 1:
          y = Math.Sinh(x);
          break;
        case 2:
          y = Math.Cosh(x);
          break;
        case 3:
          y = Math.Exp(x);
          break;
      }
      if ((x >= 0) && (x <= 3))
      {
        y = 2;
      }
      else if (x > 3)
      { 
        y = y * 0.5;
      }
      else if (x < 0)
      {
        y = 1 * y;
      }

      textBox1.Text = "При x = " + Convert.ToString(x) + Environment.NewLine + "y =" + Convert.ToString(y);

    }

    public double fact(int number)
    {
      if (number == 1)
        return 1;
      if (number == 0)
        return 1;
      else
        return number * fact(number - 1);

      
    }
    public void pr_4(double eps)
    {
      double sum = 0;
      double toch = eps+1;
      int i = 1;
      while (eps<toch)
      {
        toch = 2 / (Math.Sqrt(fact(i) + 4));
        sum += toch;
        
        i++;
      }
      textBox1.Text = "При eps = " + Convert.ToString(eps) + Environment.NewLine + "sum =" + Convert.ToString(sum);


    }

    public void pr_5()
    {
      int index = listBox1.SelectedIndex;
      string str = (string)listBox1.Items[index];
      int len = str.Length;
      int i = 0;
      int count = 0;
      while (i < len)
      {
        if ((str[i] == '.')|| (str[i] == '!')|| (str[i] == '?'))
          count++;
        i++;
      }
      label2.Visible = true;
      label2.Text = "Колличеств предложений = " + Convert.ToString(count);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      double x = 0;
      if (Fx_switch == 6)
      {
        pr_6();

      }
      if (Fx_switch == 5)
      {
        pr_5();
      }
     
      if (double.TryParse(textBox2.Text, out x))  
      {
        if (Fx_switch == 4)
        {
          pr_4(x);
        }
        
          //pr_3(x);
      }
      else
      {
        textBox1.Text = "Ошибка ввода!  ";
      }
      
    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {
      Fx_switch = 4;
      label1.Text = "Введите точность";
      textBox1.Visible = true;
      label1.Visible = true;
      textBox2.Visible = true;
      listBox1.Visible = false;
    }

    private void radioButton5_CheckedChanged(object sender, EventArgs e)
    {
      Fx_switch = 5;
      textBox1.Visible = false;
      label1.Visible = false;
      textBox2.Visible = false;
      listBox1.Visible = true;
    }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
      Fx_switch = 6;
      label1.Text = "Введите верхнюю границу";
      textBox1.Visible = true;
      label1.Visible = true;
      textBox2.Visible = true;
      listBox1.Visible = false;
    }

    public void pr_6()
    {
      double sum = 1;
      int n = 0;
      double nf = 0;
      if (int.TryParse(textBox2.Text, out n))
      {
        for (int i = 1; i < n+1; i++)
        {
          nf = fact(i);
          sum = sum * (((3 * nf) - 1) / (i + 1));
        }
        textBox1.Text = "При n = " + Convert.ToString(n)   + "sum =" + Convert.ToString(sum);
      }
    }
  }
}
