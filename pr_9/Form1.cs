using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;




namespace pr_9
{

  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    static int coefX = 1;
    static int coefY = 1;
    static int x = coefX * 150;
    static int y = coefY * 20;
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      g.Clear(Color.White);
      button1.BringToFront();
      g.FillRectangle(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#666666")), new Rectangle(100, 0, 400, 500));

      
      

      g.FillRectangle(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#f3f3f3")), new Rectangle(275, 10, 40, 100));
      g.FillRectangle(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#f3f3f3")), new Rectangle(275, 140, 40, 100));
      g.FillRectangle(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#f3f3f3")), new Rectangle(275, 270, 40, 100));
      g.FillRectangle(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#f3f3f3")), new Rectangle(275, 400, 40, 100));
      g.FillRectangle(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#9900ff")), new Rectangle(x, y, 70, 150));

      for (int i = 0; i < 10; i++)
      {
        g.FillRectangle(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#9900ff")), new Rectangle(i * 10 + x, i * 10 + y, 70, 150));
        Thread.Sleep(500);
        g.FillRectangle(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#666666")), new Rectangle(i * 10+x, i * 10 + +y, 70, 150));
        
        g.FillRectangle(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#9900ff")), new Rectangle((i+1)*10+x, (i+1) * 10 + y, 70, 150));
      }

      
      




      g.DrawLine(new Pen(Brushes.Black, 2), 10, 20, 500, 20);

   
    }

    private void button1_Click(object sender, EventArgs e)
    {
      coefX = 2; 
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {

    }

    private void button4_Click(object sender, EventArgs e)
    {

    }
  }
}
