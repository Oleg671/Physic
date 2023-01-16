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
    public partial class ObjectMove : Form
    {
        double g = 9.8, F = 0, Fmu = 0, N = 0, m = 0, mu = 0, t = 0, v = 0, v0 = 0, S = 0, a = 0, ugl = 0, FT = 0;
        bool trig;

        Label masL = new Label();
        Label MuL = new Label();
        Label tiL = new Label();
        Label vskorL = new Label();
        Label vskor0L = new Label();
        Label SputL = new Label();
        Label askorL = new Label();
        Label FdvigL = new Label();
        Label FtrenL = new Label();
        Label NoporL = new Label();

        TextBox mas = new TextBox();
        TextBox Mu = new TextBox();
        TextBox ti = new TextBox();
        TextBox vskor = new TextBox();
        TextBox vskor0 = new TextBox();
        TextBox Sput = new TextBox();
        TextBox askor = new TextBox();
        TextBox Fdvig = new TextBox();
        TextBox Ftren = new TextBox();
        TextBox Nopor = new TextBox();

        Button doit = new Button();
        Button comeback = new Button();
        Label unknownL = new Label();
        TextBox ugol = new TextBox();
        Label ugolL = new Label();
        ComboBox unknown = new ComboBox();
        TextBox test = new TextBox();

        Label main = new Label();

        Graphics graph;

        public ObjectMove()
        {
            InitializeComponent();
            test.Multiline = true;
            test.ReadOnly = true;

            this.Text = "Кинематика";
            this.MinimumSize = new Size(600, 450);
            this.MaximumSize = new Size(600, 450);

            this.BackColor = Color.White;
            graph = CreateGraphics();
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            main.Text = "Равноускоренное/равнозамедленное движение тела";
            main.Size = new Size(520, 30);
            main.Location = new Point(40, 10);
            main.Font = new Font(masL.Font.FontFamily, 15, masL.Font.Style);

            masL.Size = new Size(150, 20);
            MuL.Size = new Size(150, 20);
            tiL.Size = new Size(150, 20);
            vskorL.Size = new Size(150, 20);
            vskor0L.Size = new Size(150, 20);
            SputL.Size = new Size(150, 20);
            askorL.Size = new Size(150, 20);
            FdvigL.Size = new Size(150, 20);
            FtrenL.Size = new Size(150, 20);
            NoporL.Size = new Size(150, 20);

            mas.Size = new Size(50, 20);
            Mu.Size = new Size(50, 20);
            ti.Size = new Size(50, 20);
            vskor.Size = new Size(50, 20);
            vskor0.Size = new Size(50, 20);
            Sput.Size = new Size(50, 20);
            askor.Size = new Size(50, 20);
            Fdvig.Size = new Size(50, 20);
            Ftren.Size = new Size(50, 20);
            Nopor.Size = new Size(50, 20);

            mas.Text = "0";
            Mu.Text = "0";
            ti.Text = "0";
            vskor.Text = "0";
            vskor0.Text = "0";
            Sput.Text = "0";
            askor.Text = "0";
            Fdvig.Text = "0";
            Ftren.Text = "0";
            Nopor.Text = "0";
            ugol.Text = "0";

            masL.Text = "Масса, кг (m):";
            MuL.Text = "Коэффицент трения (mu):";
            tiL.Text = "Время, с (t):";
            vskorL.Text = "Конечная скорость, м/c (v):";
            vskor0L.Text = "Начальная скорость, м/c (v0):";
            SputL.Text = "Путь, м (S):";
            askorL.Text = "Ускорение, м/с^2 (a):";
            FdvigL.Text = "Приложенная сила, F (F):";
            FtrenL.Text = "Сила трения, F (Fm):";
            NoporL.Text = "Реакция опоры, F (N):";

            doit.Text = "Решить";
            doit.Size = new Size(100, 45);
            doit.Location = new Point(250, 155);
            comeback.Size = new Size(100, 45);
            comeback.Location = new Point(250, 210);
            comeback.Text = "Вернуться в меню";
            ugol.Size = new Size(50, 20);
            ugol.Location = new Point(160, 327);
            ugolL.Size = new Size(150, 20);
            ugolL.Text = "Угол (градусы) 0-60:";
            ugolL.Location = new Point(5, 330);
            unknown.Size = new Size(50, 20);
            unknown.Location = new Point(160, 372);
            unknownL.Size = new Size(150, 20);
            unknownL.Text = "Необходимо найти:";
            unknownL.Location = new Point(5, 375);

            mas.Location = new Point(160, 55);
            Mu.Location = new Point(160, 80);
            ti.Location = new Point(160, 105);
            vskor.Location = new Point(160, 130);
            vskor0.Location = new Point(160, 155);
            Sput.Location = new Point(160, 180);
            askor.Location = new Point(160, 205);
            Fdvig.Location = new Point(160, 230);
            Ftren.Location = new Point(160, 255);
            Nopor.Location = new Point(160, 280);

            masL.Location = new Point(5, 57);
            MuL.Location = new Point(5, 82);
            tiL.Location = new Point(5, 107);
            vskorL.Location = new Point(5, 132);
            vskor0L.Location = new Point(5, 157);
            SputL.Location = new Point(5, 182);
            askorL.Location = new Point(5, 207);
            FdvigL.Location = new Point(5, 232);
            FtrenL.Location = new Point(5, 257);
            NoporL.Location = new Point(5, 282);

            Controls.Add(mas);
            Controls.Add(Mu);
            Controls.Add(ti);
            Controls.Add(vskor);
            Controls.Add(vskor0);
            Controls.Add(Sput);
            Controls.Add(askor);
            Controls.Add(Fdvig);
            Controls.Add(Ftren);
            Controls.Add(Nopor);

            Controls.Add(masL);
            Controls.Add(MuL);
            Controls.Add(tiL);
            Controls.Add(vskorL);
            Controls.Add(vskor0L);
            Controls.Add(SputL);
            Controls.Add(askorL);
            Controls.Add(FdvigL);
            Controls.Add(FtrenL);
            Controls.Add(NoporL);

            Controls.Add(doit);
            Controls.Add(comeback);
            Controls.Add(unknown);
            Controls.Add(unknownL);
            Controls.Add(ugolL);
            Controls.Add(ugol);

            Controls.Add(main);

            unknown.Items.Add("m");
            unknown.Items.Add("mu");
            unknown.Items.Add("t");
            unknown.Items.Add("v");
            unknown.Items.Add("v0");
            unknown.Items.Add("S");
            unknown.Items.Add("a");
            unknown.Items.Add("F");
            unknown.Items.Add("Fm");
            unknown.Items.Add("N");

            test.Size = new Size(200, 40);
            test.Location = new Point(350, 340);
            Controls.Add(test);
            doit.MouseClick += doitButtClick;
            comeback.MouseDown += ComeBackClick;

            unknown.TextUpdate += unknownTextUpdate;
            unknown.SelectedIndexChanged += unknownTextUpdate;
        }
        public void ComeBackClick(object sender, EventArgs e)
        {
            StartForm fl = new StartForm();
            fl.Show();
            this.Hide();
            mas.ReadOnly = false;
            Mu.ReadOnly = false;
            ti.ReadOnly = false;
            vskor.ReadOnly = false;
            vskor0.ReadOnly = false;
            Sput.ReadOnly = false;
            askor.ReadOnly = false;
            Fdvig.ReadOnly = false;
            Ftren.ReadOnly = false;
            Nopor.ReadOnly = false;
            unknown.Text = "0";
            ugol.Text = "0";
            mas.Text = "0";
            Mu.Text = "0";
            ti.Text = "0";
            vskor.Text = "0";
            vskor0.Text = "0";
            Sput.Text = "0";
            askor.Text = "0";
            Fdvig.Text = "0";
            Ftren.Text = "0";
            Nopor.Text = "0";
            test.Text = "";
            graph.Clear(Color.White);
        }
        private void unknownTextUpdate(object sender, EventArgs e)
        {
            if (unknown.Text == "m")
            {
                mas.ReadOnly = true;
                Mu.ReadOnly = false;
                ti.ReadOnly = false;
                vskor.ReadOnly = false;
                vskor0.ReadOnly = false;
                Sput.ReadOnly = false;
                askor.ReadOnly = false;
                Fdvig.ReadOnly = false;
                Ftren.ReadOnly = false;
                Nopor.ReadOnly = false;
                mas.Text = "0";
            }
            else if (unknown.Text == "mu")
            {
                mas.ReadOnly = false;
                Mu.ReadOnly = true;
                ti.ReadOnly = false;
                vskor.ReadOnly = false;
                vskor0.ReadOnly = false;
                Sput.ReadOnly = false;
                askor.ReadOnly = false;
                Fdvig.ReadOnly = false;
                Ftren.ReadOnly = false;
                Nopor.ReadOnly = false;
                Mu.Text = "0";
            }
            else if (unknown.Text == "t")
            {
                mas.ReadOnly = false;
                Mu.ReadOnly = false;
                ti.ReadOnly = true;
                vskor.ReadOnly = false;
                vskor0.ReadOnly = false;
                Sput.ReadOnly = false;
                askor.ReadOnly = false;
                Fdvig.ReadOnly = false;
                Ftren.ReadOnly = false;
                Nopor.ReadOnly = false;
                ti.Text = "0";
            }
            else if (unknown.Text == "v")
            {
                mas.ReadOnly = false;
                Mu.ReadOnly = false;
                ti.ReadOnly = false;
                vskor.ReadOnly = true;
                vskor0.ReadOnly = false;
                Sput.ReadOnly = false;
                askor.ReadOnly = false;
                Fdvig.ReadOnly = false;
                Ftren.ReadOnly = false;
                Nopor.ReadOnly = false;
                vskor.Text = "0";
            }
            else if (unknown.Text == "v0")
            {
                mas.ReadOnly = false;
                Mu.ReadOnly = false;
                ti.ReadOnly = false;
                vskor.ReadOnly = false;
                vskor0.ReadOnly = true;
                Sput.ReadOnly = false;
                askor.ReadOnly = false;
                Fdvig.ReadOnly = false;
                Ftren.ReadOnly = false;
                Nopor.ReadOnly = false;
                vskor0.Text = "0";
            }
            else if (unknown.Text == "S")
            {
                mas.ReadOnly = false;
                Mu.ReadOnly = false;
                ti.ReadOnly = false;
                vskor.ReadOnly = false;
                vskor0.ReadOnly = false;
                Sput.ReadOnly = true;
                askor.ReadOnly = false;
                Fdvig.ReadOnly = false;
                Ftren.ReadOnly = false;
                Nopor.ReadOnly = false;
                Sput.Text = "0";
            }
            else if (unknown.Text == "a")
            {
                mas.ReadOnly = false;
                Mu.ReadOnly = false;
                ti.ReadOnly = false;
                vskor.ReadOnly = false;
                vskor0.ReadOnly = false;
                Sput.ReadOnly = false;
                askor.ReadOnly = true;
                Fdvig.ReadOnly = false;
                Ftren.ReadOnly = false;
                Nopor.ReadOnly = false;
                askor.Text = "0";
            }
            else if (unknown.Text == "F")
            {
                mas.ReadOnly = false;
                Mu.ReadOnly = false;
                ti.ReadOnly = false;
                vskor.ReadOnly = false;
                vskor0.ReadOnly = false;
                Sput.ReadOnly = false;
                askor.ReadOnly = false;
                Fdvig.ReadOnly = true;
                Ftren.ReadOnly = false;
                Nopor.ReadOnly = false;
                Fdvig.Text = "0";
            }
            else if (unknown.Text == "Fmu")
            {
                mas.ReadOnly = false;
                Mu.ReadOnly = false;
                ti.ReadOnly = false;
                vskor.ReadOnly = false;
                vskor0.ReadOnly = false;
                Sput.ReadOnly = false;
                askor.ReadOnly = false;
                Fdvig.ReadOnly = false;
                Ftren.ReadOnly = true;
                Nopor.ReadOnly = false;
                Ftren.Text = "0";
            }
            else if (unknown.Text == "N")
            {
                mas.ReadOnly = false;
                Mu.ReadOnly = false;
                ti.ReadOnly = false;
                vskor.ReadOnly = false;
                vskor0.ReadOnly = false;
                Sput.ReadOnly = false;
                askor.ReadOnly = false;
                Fdvig.ReadOnly = false;
                Ftren.ReadOnly = false;
                Nopor.ReadOnly = true;
                Nopor.Text = "0";
            }
            else
            {
                mas.ReadOnly = false;
                Mu.ReadOnly = false;
                ti.ReadOnly = false;
                vskor.ReadOnly = false;
                vskor0.ReadOnly = false;
                Sput.ReadOnly = false;
                askor.ReadOnly = false;
                Fdvig.ReadOnly = false;
                Ftren.ReadOnly = false;
                Nopor.ReadOnly = false;
            }
        }

        double SilaT()
        {
            if (ugl != 0 && m != 0)
            {
                FT = m * g * Math.Sin(ugl * Math.PI / 180);
            }
            return FT;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        double uskor(out string formula)
        {
            formula = "";
            if (F != 0 && m != 0)
            {
                a = (F - Fmu) / m;
                formula = "a = (F - Fmu) / m = ";
            }
            else if (v != 0)
            {
                if (S != 0)
                {
                    a = ((v * v - v0 * v0) / S) * 2;
                    formula = "a = ((v * v - v0 * v0) / S) * 2 = ";
                }
                if (t != 0)
                {
                    a = (v - v0) / t;
                    formula = "a = (v - v0) / t = ";
                }
            }
            else if (S != 0 && t != 0)
            {
                a = ((S - (v0 * t)) * 2) / (t * t);
                formula = "a = ((S - (v0 * t)) * 2) / (t * t) = ";
            }
            return a;
        }
        double massa(out string formula)
        {
            formula = "";
            if (F != 0 && a != 0)
            {
                m = F / a;
                formula = "m = F / a = ";
            }
            else if (N != 0)
            {
                m = N / g;
                formula = "m = N / g = ";
            }
            else if (S != 0 && t != 0 && F != 0)
            {
                m = ((F - Fmu) * (t * t)) / ((S - v0 * t) * 2);
                formula = "m = ((F - Fmu) * (t * t)) / ((S - v0 * t) * 2) = ";
            }
            return m;
        }
        double Opor(out string formula)
        {
            formula = "";
            if (m != 0)
            {
                N = m * g;
                formula = "N = m * g = ";
            }
            else if (Fmu != 0 && mu != 0)
            {
                N = Fmu / mu;
                formula = "N = Fmu / mu = ";
            }
            return N;
        }
        double MU(out string formula)
        {
            formula = "";
            if (Fmu != 0 && N != 0)
            {
                mu = Fmu / N;
                formula = "mu = Fmu / N = ";
            }
            return mu;
        }
        double FMu(out string formula)
        {
            formula = "";
            if (mu != 0 && N != 0)
            {
                Fmu += mu * N;
                formula = "Fmu = mu * N = ";
            }
            else if (t != 0 && S != 0 && m != 0)
            {
                Fmu = Math.Abs(F - FT - ((2 * m * (S - v0 * t)) / (t * t)));
                formula = "Fmu = F - FT - ((2 * m * (S - v0 * t)) / (t * t)) = ";
            }
            return Fmu;
        }
        double puti(out string formula)
        {
            formula = "";
            if ((t != 0) & (v0 != 0 || a != 0))
            {
                S = v0 * t + ((a * t * t) / 2);
                formula = "S = v0 * t + ((a * t * t) / 2) = ";
            }
            else if (v != 0 && t != 0)
            {
                S = (v + v0) * t / 2;
                formula = "S = (v + v0) * t / 2 = ";
            }
            return S;
        }
        double Ff(out string formula)
        {
            formula = "";
            if (a != 0 && m != 0)
            {
                F = m * a;
                formula = "F = m * a = ";
            }
            else if (t != 0 && S != 0 && m != 0)
            {
                F = Fmu + ((2 * m * (S - v0 * t)) / (t * t));
                formula = "Fmu + ((2 * m * (S - v0 * t)) / (t * t)) = ";
            }
            return F;
        }
        double Ttime(out string formula)
        {
            formula = "";
            if (v != 0 && v0 != 0 && a != 0 && v != v0)
            {
                t = Math.Abs((v - v0) / a);
                formula = "t = Math.Abs((v - v0) / a) = ";
            }
            else if (S != 0 && v0 != 0)
            {
                t = S / v0;
                formula = "t = S / v0 = ";
            }
            return t;
        }
        double vskorost0(out string formula)
        {
            formula = "";
            if (v != 0 && t != 0)
            {
                v0 = v - a * t;
                formula = "v0 = v - a * t = ";
            }
            else if (S != 0 && t != 0 && m != 0)
            {
                v0 = (S - ((F - Fmu) / m) * (t * t) / 2) / t;
                formula = "v0 = (S - ((F - Fmu) / m) * (t * t) / 2) / t = ";
            }
            else if (S != 0 && t != 0)
            {
                v0 = S / t;
                formula = "v0 = S / t = ";
            }
            return v0;
        }
        double vskorost(out string formula)
        {
            formula = "";
            if (a != 0 && t != 0)
            {
                v = v0 + a * t;
                formula = "v = v0 + a * t = ";
            }
            return v;
        }
        private void risunok()
        {
            string formula = "";
            if (N == 0)
                Opor(out formula);
            if (F == 0)
                Ff(out formula);
            if (Fmu == 0)
                FMu(out formula);
            risunki ris = new risunki(ugl);
            ris.DrawEarth(graph);
            ris.DrawBody(graph);
            ris.DrawPowers(graph, F, N, Fmu);
        }




        private void doitButtClick(object sender, EventArgs e)
        {
            test.Text = "";
            graph.Clear(Color.White);
            bool tr;
            trig = true;
            tr = double.TryParse(mas.Text, out m);
            if (!tr)
            {
                mas.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            tr = double.TryParse(Mu.Text, out mu);
            if (!tr)
            {
                Mu.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            tr = double.TryParse(ti.Text, out t);
            if (!tr)
            {
                ti.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            tr = double.TryParse(vskor.Text, out v);
            if (!tr)
            {
                vskor.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            tr = double.TryParse(vskor0.Text, out v0);
            if (!tr)
            {
                vskor0.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            tr = double.TryParse(Sput.Text, out S);
            if (!tr)
            {
                Sput.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            tr = double.TryParse(Fdvig.Text, out F);
            if (!tr)
            {
                Fdvig.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            tr = double.TryParse(askor.Text, out a);
            if (!tr)
            {
                askor.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            tr = double.TryParse(Ftren.Text, out Fmu);
            if (!tr)
            {
                Ftren.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            tr = double.TryParse(Nopor.Text, out N);
            if (!tr)
            {
                Nopor.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            tr = double.TryParse(ugol.Text, out ugl);
            if (!tr)
            {
                ugol.Text = " ";
                test.Text = "Неверный формат данных";
                trig = false;
            }
            FT = 0;

            if (ugl < 0 || ugl > 60)
            {
                trig = false;
                test.Text = "Неверно задан угол";
            }
            if (m<0 || mu<0 || t<0 || N<0 || FT<0 || m>1000 || mu>=1 || v>1000 || v0>1000 || S>100000 || a>1000 || F>10000 || Fmu>10000 || N>10000)
            {
                test.Text = "Невозможные значения";
                trig = false;
            }
            if (trig)
            {
                if (unknown.Text == "t")
                {
                    string formula = "";
                    t = Ttime(out formula);
                    test.Text = formula + t.ToString() + " с";
                }
                else if (unknown.Text == "S")
                {
                    string formula = "";
                    if (N == 0)
                        N = Opor(out formula);
                    if (FT == 0)
                        FT = SilaT();
                    if (Fmu == 0)
                        Fmu = FMu(out formula);
                    Fmu += FT;
                    if (m == 0)
                        m = massa(out formula);
                    if (t == 0)
                        t = Ttime(out formula);
                    if (a == 0)
                        a = uskor(out formula);
                    if (v0 == 0 && v == 0)
                        v0 = vskorost0(out formula);
                    if (v == 0)
                        v = vskorost(out formula);
                    S = puti(out formula);
                    test.Text = formula + S.ToString() + " м";
                }
                else if (unknown.Text == "a")
                {
                    string formula = "";
                    if (m == 0)
                        m = massa(out formula);
                    if (N == 0)
                        N = Opor(out formula);
                    if (F == 0)
                        F = Ff(out formula);
                    if (v0 == 0 && v == 0)
                        v0 = vskorost0(out formula);
                    if (t == 0)
                        t = Ttime(out formula);
                    if (v == 0 && v0 == 0)
                        v = vskorost(out formula);
                    if (S == 0)
                        S = puti(out formula);
                    if (FT == 0)
                        FT = SilaT();
                    if (Fmu == 0)
                        Fmu = FMu(out formula);
                    Fmu += FT;
                    a = uskor(out formula);
                    test.Text = formula + a.ToString() + " м/с^2";
                }
                else if (unknown.Text == "v")
                {
                    string formula = "";
                    if (m == 0)
                        m = massa(out formula);
                    if (N == 0)
                        N = Opor(out formula);
                    if (t == 0)
                        t = Ttime(out formula);
                    if (FT == 0)
                        FT = SilaT();
                    if (Fmu == 0)
                        Fmu = FMu(out formula);
                    Fmu += FT;
                    if (a == 0)
                        a = uskor(out formula);
                    if (v0 == 0 && v == 0)
                        v0 = vskorost0(out formula);
                    v = vskorost(out formula);
                    test.Text = formula + v.ToString() + " м/с";
                }
                else if (unknown.Text == "v0")
                {
                    string formula = "";
                    if (m == 0)
                        m = massa(out formula);
                    if (N == 0)
                        N = Opor(out formula);
                    if (t == 0)
                        t = Ttime(out formula);
                    if (FT == 0)
                        FT = SilaT();
                    if (Fmu == 0)
                        Fmu = FMu(out formula);
                    Fmu += FT;
                    if (a == 0)
                        a = uskor(out formula);
                    v0 = vskorost(out formula);
                    test.Text = formula + v0.ToString() + " м/с";
                }
                else if (unknown.Text == "F")
                {
                    string formula = "";
                    if (m == 0)
                        m = massa(out formula);
                    if (N == 0)
                        N = Opor(out formula);
                    if (S == 0)
                        S = puti(out formula);
                    if (t == 0)
                        t = Ttime(out formula);
                    if (FT == 0)
                        FT = SilaT();
                    if (Fmu == 0)
                        Fmu = FMu(out formula);
                    Fmu += FT;
                    if (a == 0)
                        a = uskor(out formula);
                    F = Ff(out formula);
                    test.Text = formula + F.ToString() + " F";
                }
                else if (unknown.Text == "Fm")
                {
                    string formula = "";
                    if (m == 0)
                        m = massa(out formula);
                    if (N == 0)
                        N = Opor(out formula);
                    if (mu == 0)
                        mu = MU(out formula);
                    if (a == 0)
                        a = uskor(out formula);
                    if (S == 0)
                        S = puti(out formula);
                    if (t == 0)
                        t = Ttime(out formula);
                    if (FT == 0)
                        FT = SilaT();
                    Fmu = FMu(out formula);
                    test.Text = formula + Fmu.ToString() + " F";
                }
                else if (unknown.Text == "N")
                {
                    string formula = "";
                    if (m == 0)
                        m = massa(out formula);
                    if (FT == 0)
                        FT = SilaT();
                    if (Fmu == 0)
                        Fmu = FMu(out formula);
                    Fmu += FT;
                    N = Opor(out formula);
                    test.Text = formula + N.ToString() + " F";
                }
                else if (unknown.Text == "mu")
                {
                    string formula = "";
                    if (FT == 0)
                        FT = SilaT();
                    if (Fmu == 0)
                        Fmu = FMu(out formula);
                    Fmu += FT;
                    if (m == 0)
                        m = massa(out formula);
                    if (N == 0)
                        N = Opor(out formula);
                    mu = MU(out formula);
                    test.Text = formula + mu.ToString();
                }
                else if (unknown.Text == "m")
                {
                    string formula = "";
                    if (F == 0)
                        F = Ff(out formula);
                    if (N == 0)
                        N = Opor(out formula);
                    if (FT == 0)
                        FT = SilaT();
                    if (Fmu == 0)
                        Fmu = FMu(out formula);
                    Fmu += FT;
                    if (a == 0)
                        a = uskor(out formula);
                    if (S == 0)
                        S = puti(out formula);
                    if (t == 0)
                        t = Ttime(out formula);
                    m = massa(out formula);
                    test.Text = formula + m.ToString() + " кг";
                }
                else
                    test.Text = "Такой переменной не существует в данном контексте";
                risunok();
            }
        }
    }
}