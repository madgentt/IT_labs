using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form

  {

    static Point PreviousPoint, point; //Точка до перемещения курсора мыши и текущая точка
    static Bitmap bmp;
    static Pen blackPen;
    static Graphics g;
    static int Widg, High;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      
    }


    private void button2_Click(object sender, EventArgs e)
    { //сохранениефайла
      SaveFileDialog savedialog = new SaveFileDialog();//описываемипорождаемобъектsavedialog
                                                       //задаем свойства для savedialog
      savedialog.Title = "Сохранить картинку как ...";
      savedialog.OverwritePrompt = true;
      savedialog.CheckPathExists = true;
      savedialog.Filter =
      "Bitmap File(*.bmp)|*.bmp|" +
      "GIF File(*.gif)|*.gif|" +
      "JPEG File(*.jpg)|*.jpg|" +
      "TIF File(*.tif)|*.tif|" +
      "PNG File(*.png)|*.png";
      savedialog.ShowHelp = true;
      // If selected, save
      if (savedialog.ShowDialog() == DialogResult.OK)//вызываемдиалоговоеокноипроверяемзаданолиимяфайла
      {
        // в строку fileName записываем указанный в savedialog полный путь к файлу
        string fileName = savedialog.FileName;
        // Убираем из имени три последних символа (расширение файла)
        string strFilExtn =
        fileName.Remove(0, fileName.Length - 3);
        // Сохраняем файл в нужном формате и с нужным расширением
        switch (strFilExtn)
        {
          case "bmp":
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
            break;
          case "jpg":
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            break;
          case "gif":
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
            break;
          case "tif":
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
            break;
          case "png":
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            break;
          default:
            break;
        }

      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      blackPen = new Pen(Color.Black, 10); //подготавливаем перо для рисования
      //открытиефайла
      OpenFileDialog dialog = new OpenFileDialog(); //описываемипорождаемобъект dialog классаOpenFileDialog
                                                   //задаемрасширенияфайлов
      dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
      if (dialog.ShowDialog() == DialogResult.OK)//вызываем диалоговое окно и проверяем выбран ли файл
      {
        Image image = Image.FromFile(dialog.FileName); //Загружаем в image изображение из выбранного файла
        int width = image.Width;
        Widg = image.Width;
        High = image.Height;
        int height = image.Height;
        pictureBox1.Width = width;
        pictureBox1.Height = height;

        bmp = new Bitmap(image, width, height); //создаем и загружаем из image изображение в формате bmp

        pictureBox1.Image = bmp; //записываем изображение в формате bmp в pictureBox1
        g = Graphics.FromImage(pictureBox1.Image); //подготавливаем объект Graphics для рисования в pictureBox1

      }

    }


    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    { // обработчик события нажатия кнопки на мыши
      // записываем в предыдущую точку (PreviousPoint) текущие координаты
      PreviousPoint.X = e.X;
      PreviousPoint.Y = e.Y;
    }

  

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {//Обработчик события перемещения мыши по pictuteBox1
      if (e.Button == MouseButtons.Left) //Проверяем нажата ли левая кнопка мыши
      {  //запоминаем в point текущее положение курсора мыши
        point.X = e.X;
        point.Y = e.Y;

        //соеденяем линией предыдущую точку с текущей
        g.DrawLine(blackPen, PreviousPoint, point);

        //текущее положение курсора мыши сохраняем в PreviousPoint
        PreviousPoint.X = point.X;
        PreviousPoint.Y = point.Y;
        pictureBox1.Invalidate();//Принудительновызываемпереррисовку pictureBox1
      }
    }

    static Color swap1;
    static Color swap2;
    static Color swap3;
    private void button3_Click_1(object sender, EventArgs e)
    {


      //циклы для перебора всех пикселей на изображении



      //циклы для перебора всех пикселей на изображении
      for (int i = 1; i < bmp.Width; i++)
      {
        for (int j = 1; j < bmp.Height; j++)
        {
          //swap2 = bmp.GetPixel(i, j);


          swap1 = bmp.GetPixel(bmp.Width-i, j);
          bmp.SetPixel(bmp.Width - i, j, bmp.GetPixel(i, j));
          bmp.SetPixel(i, j, swap1);




        }
        Refresh(); //вызываем функцию перерисовки окна

      }

      
    }

  }
}
