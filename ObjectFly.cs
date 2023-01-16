using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Re2
{
    public partial class ObjectFly : Form
    {

        double cof, V, ugl, t;
        bool trig = false;
        Pen pen;
        
        Fly telo;
        Label main = new Label();
        Label warn = new Label();

        Label skorL = new Label();
        Label ugolL = new Label();
        Label maXL = new Label();
        Label maYL = new Label();
        Label tiL = new Label();

        TextBox skor = new TextBox();
        TextBox ugol = new TextBox();
        TextBox maX = new TextBox();
        TextBox maY = new TextBox();
        TextBox ti = new TextBox();

        Button doit = new Button();
        Button comeback = new Button();

        Brush brush = new SolidBrush(Color.Red);
        public ObjectFly()
        {
            InitializeComponent();
            this.Text = "Баллистика";
            this.MinimumSize = new Size(600, 400);
            this.MaximumSize = new Size(600, 400);
            timer1.Interval = 50;
            pen = new Pen(Color.Black);
            this.BackColor = Color.White;
            main.Text = "Полет тела, брошенного под углом к горизонту";
            main.Size = new Size(520, 30);
            main.Location = new Point(40, 10);
            main.Font = new Font(skorL.Font.FontFamily, 15, skorL.Font.Style);

            warn.Size = new Size(210, 30);
            warn.Location = new Point(5, 265);
            warn.Font = new Font(skorL.Font.FontFamily, 10, skorL.Font.Style);

            skorL.Size = new Size(220, 20);
            ugolL.Size = new Size(220, 20);
            maXL.Size = new Size(220, 20);
            maYL.Size = new Size(220, 20);
            tiL.Size = new Size(220, 20);

            skor.Size = new Size(50, 20);
            ugol.Size = new Size(50, 20);
            maX.Size = new Size(50, 20);
            maY.Size = new Size(50, 20);
            ti.Size = new Size(50, 20);

            skorL.Location = new Point(5, 57);
            ugolL.Location = new Point(5, 82);
            maXL.Location = new Point(5, 107);
            maYL.Location = new Point(5, 132);
            tiL.Location = new Point(5, 157);
            
            skor.Location = new Point(230, 55);
            ugol.Location = new Point(230, 80);
            ti.Location = new Point(230, 155);
            maX.Location = new Point(230, 105);
            maY.Location = new Point(230, 130);

            skorL.Text = "Скорость тела, м/с: ";
            ugolL.Text = "Угол, градусы (0-90): ";
            maXL.Text = "Максимальное расстояние полета, м: ";
            maYL.Text = "Максимальная высота полета, м: ";
            tiL.Text = "Время полета,с: ";

            doit.Text = "Построить";
            doit.Size = new Size(100, 45);
            doit.Location = new Point(75, 195);
            comeback.Size = new Size(100, 45);
            comeback.Location = new Point(75, 310);
            comeback.Text = "Вернуться в меню";

            maX.ReadOnly = true;
            maY.ReadOnly = true;
            ti.ReadOnly = true;

            Controls.Add(skorL);
            Controls.Add(ugolL);
            Controls.Add(maXL);
            Controls.Add(maYL);
            Controls.Add(tiL);
            Controls.Add(skor);
            Controls.Add(ugol);
            Controls.Add(maX);
            Controls.Add(maY);
            Controls.Add(ti);
            Controls.Add(doit);
            Controls.Add(main);
            Controls.Add(warn);
            Controls.Add(comeback);
            doit.MouseDown += butt1Click;
            comeback.MouseDown += ComeBackClick;
        }

        private void ObjectFly_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void butt1Click(object sender, EventArgs e)
        {
            warn.Text = "";
            try
            {
                trig = true;
                V = Convert.ToDouble(skor.Text);
                ugl = Convert.ToDouble(ugol.Text);
            }
            catch (FormatException)
            {
                warn.Text = "!Неверный формат данных!";
                trig = false;
            }
            if (ugl<0 || ugl > 90)
            {
                trig = false;
                warn.Text = "!!!Неверно задан угол!!!";
            }
            if (V < 0)
            {
                trig = false;
                warn.Text = "!!!Неверно задана скорость!!!";
            }
            if (trig)
            {
                telo = new Fly(V, ugl);
                t = 0;
                cof = telo.ComeBack("xma") > telo.ComeBack("hma") ? telo.ComeBack("xma") / 260 : telo.ComeBack("hma") / 260;
                timer1.Start();

                maX.Text = "";
                maY.Text = "";
                ti.Text = "";
                doit.Visible = false;
            }

        }
        private void Field_Paint(object sender, PaintEventArgs e)
        {
            if (trig)
            {
                e.Graphics.FillRectangle(brush, (int)(telo.ComeBack("x") / cof), (int)(Field.Height - (telo.ComeBack("y") / cof)), (int)(5), (int)(5));
                e.Graphics.DrawLine(pen, 0, 0, 0, Field.Height);
                e.Graphics.DrawLine(pen, 0, Field.Height-1, Field.Width, Field.Height-1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (telo.ComeBack("y") >= 0)
            {
                t += 0.1;
                telo.Change(t);
            }
            else
            {
                maX.Text = Convert.ToString(telo.ComeBack("xma"));
                maY.Text = Convert.ToString(telo.ComeBack("hma"));
                ti.Text = Convert.ToString(telo.ComeBack("tma"));
                trig = false;
                timer1.Stop();
                doit.Visible = true;
            }
            Field.Refresh();
        }
        public void ComeBackClick(object sender, EventArgs e)
        {
            StartForm fl = new StartForm();
            fl.Show();
            this.Hide();
            maX.Text = "0";
            maY.Text = "0";
            ti.Text = "0";
            skor.Text = "0";
            ugol.Text = "0";
            timer1.Stop();
        }
    }
}
