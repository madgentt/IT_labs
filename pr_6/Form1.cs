using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr_6
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      button1.Text = "Расчет";
      arr_gen();
    }

        private void button1_Click(object sender, EventArgs e)
        {
          pr_6(); 
        }

    int[] arr = new int[20];
    public void arr_gen()
    {
      var rand = new Random();

      for (int i =0;i<20;i++)
      {
        arr[i] = rand.Next(-100, 100);
        textBox1.Text += "A[" + Convert.ToString(i) + "] = " + Convert.ToString(arr[i]) + Environment.NewLine;
      }

    }

    public void pr_6()
    {

      for (int i = 0; i <20;i++)
      {
        if(arr[i] < 0)
        {
          arr[i] = 0;
        }
      }

      for (int i = 0; i < 20; i++)
      {
        textBox2.Text += "A[" + Convert.ToString(i) + "] = " + Convert.ToString(arr[i]) + Environment.NewLine;
      }

    }
    }
}
