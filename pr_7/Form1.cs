using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr_7
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      button1.Text = "Расчет";
      dataGridView1.RowCount = 10;
      dataGridView1.ColumnCount = 10;

      arr_gen();
    }
    int[,] arr = new int[10,10];
    public void arr_gen()
    {
      var rand = new Random();

      for (int i = 0; i < 10; i++)
      {
        for (int j = 0; j < 10; j++)
        {
          arr[i, j] = rand.Next(-100, 100);
          dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(arr[i, j]);
        }
      }

    }
    private void button1_Click(object sender, EventArgs e)
     {
      int min = arr[0,0];
      int max = arr[0,0];
      int min_i = 0;
      int max_i = 0;
      for (int i = 0; i < 10; i++)
      {
        for (int j = 0; j < 10; j++)
        {
          int srav = arr[i, j];
          if (arr[i, j] < min)
          {
            min = arr[i, j];
            min_i = i;
          }

          if (arr[i, j] > max)
          {
            max = arr[i, j];
            max_i = i;
          }
          label1.Text = Convert.ToString(min);
          label2.Text = Convert.ToString(max);
          label3.Text = Convert.ToString(min_i);
          label4.Text = Convert.ToString(max_i);

        }
      }
      

      int temp = 0;
      for (int j = 0; j < 10; j++)
      {
        temp = arr[min_i, j];
        arr[min_i, j] = arr[max_i, j];
        arr[max_i, j] = temp;
      }

      for (int i = 0; i < 10; i++)
      {
        for (int j = 0; j < 10; j++)
        {
          dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(arr[i, j]);
        }
      }

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }
  }
}
