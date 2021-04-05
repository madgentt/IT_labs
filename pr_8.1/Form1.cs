using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace pr_8
{
  public partial class Form1 : Form
  {
    private double XMin = 2;
    private double XMax = 10;
    private double Step = 0.5;
    private double[] x;
    private double[] y1;
    private double[] y2;
    Chart chart;

    public Form1()
    {
      InitializeComponent();
    }


    private void CalcFunction()
    {
      int count = (int)Math.Ceiling((XMax - XMin) / Step) + 1;
      x = new double[count];
      y1 = new double[count];
      y2 = new double[count];
      for (int i = 0; i < count; i++)
      {
        x[i] = XMin + Step * i;
        y1[i] = (((2*Math.Log(x[i])*Math.Cos(2*x[i]))-3*(Math.Pow((x[i]+1), 2))/(x[i] - 1))/(2+Math.Sqrt(x[i])));
        y2[i] = Math.Cos(x[i]);
      }
    }


    private void CreateChart()
    {
      chart = new Chart();
      chart.Parent = this;
      chart.SetBounds(10, 10, ClientSize.Width - 20, ClientSize.Height - 20);
      ChartArea area = new ChartArea();
      area.Name = "myGraph";
      area.AxisX.Minimum = XMin;
      area.AxisX.Maximum = XMax;
      area.AxisX.MajorGrid.Interval = Step;
      chart.ChartAreas.Add(area);

      // Создаём объект для первого графика
      Series series1 = new Series();
      // Ссылаемся на область для построения графика
      series1.ChartArea = "myGraph";
      // Задаём тип графика - сплайны
      series1.ChartType = SeriesChartType.Spline;
      // Указываем ширину линии графика
      series1.BorderWidth = 3;
      // Название графика для отображения в легенде
      // Добавляем в список графиков диаграммы
      chart.Series.Add(series1);
      // Аналогичные действия для второго графика
      Series series2 = new Series();
      series2.ChartArea = "myGraph";
      series2.ChartType = SeriesChartType.Spline;
      series2.BorderWidth = 3;
      chart.Series.Add(series2);

      // Создаёмлегенду, котораябудетпоказыватьназвания
      Legend legend = new Legend();
      chart.Legends.Add(legend);
    }



    private void Form1_Load(object sender, EventArgs e)
    {
      // Создаём элемент управления
      CreateChart();

      // Расчитываем значения точек графиков функций
      CalcFunction();

      // Добавляем вычисленные значения в графики
      chart.Series[0].Points.DataBindXY(x, y1);
    }



  }

}
