using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace optimal_uzim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string ifoda;
        public DataGridView[] J_massiv;
        List<DataGridView> ArraySourse = new List<DataGridView>();
        public void Aptimallash(string str)
        {
            ifoda = str;
            DataGridView[] ArraySecond = new DataGridView[100];
            int temp = 0;
            string BeginEnd = "", A = "", B = "";
            int amallar_soni = 0;
            for (int i = 0; i < ifoda.Length; i++)
                if (ifoda[i] == '+' || ifoda[i] == '-' || ifoda[i] == '*' || ifoda[i] == '/')
                    amallar_soni++;
            ArraySecond[temp] = new DataGridView();
            ArraySourse.Add(ArraySecond[temp]);
            ArraySecond[temp].RowCount = amallar_soni;
            ArraySecond[temp].ColumnCount = 6;
            int amal = 1, qavs_ochilishi = 0, qavs_yopilishi = 0;
            bool qavs;
            while (amal < amallar_soni + 1)
            {
                qavs_ochilishi = 0; qavs_yopilishi = 0;
                qavs = false;
                for (int i = 0; i < ifoda.Length; i++)
                    if (ifoda[i] == ')')
                    {
                        qavs_yopilishi = i; break;
                    }
                for (int i = qavs_yopilishi - 1; i >= 0; i--)
                    if (ifoda[i] == '(')
                    {
                        qavs_ochilishi = i; qavs = true; break;
                    }

                if (qavs)
                {
                    string trr = "";
                    int AmmallarSoniN = 0, AmallarS = 1;
                    BeginEnd = "";
                    for (int i = qavs_ochilishi + 1; i < qavs_yopilishi; i++)
                        BeginEnd = BeginEnd + ifoda[i];
                    for (int i = 0; i < BeginEnd.Length; i++)
                        if (BeginEnd[i] == '+' || BeginEnd[i] == '-' || BeginEnd[i] == '*' || BeginEnd[i] == '/') AmmallarSoniN++;
                    while (AmallarS <= AmmallarSoniN)
                    {
                        for (int i = 0; i < BeginEnd.Length; i++)
                        {
                            if (BeginEnd[i] == '*' || BeginEnd[i] == '/')
                            {
                                string tr = "";
                                bool a = false; int J = -1, H = BeginEnd.Length + 1;
                                for (int j = i - 1; j >= 0; j--)
                                    if (BeginEnd[j] == '/' || BeginEnd[j] == '*' || BeginEnd[j] == '+' || BeginEnd[j] == '-')
                                    { J = j; a = true; break; }

                                if (a)
                                    for (int n = J + 1; n < i; n++)
                                        A = A + BeginEnd[n];
                                else for (int n = 0; n < i; n++) A = A + BeginEnd[n];
                                a = false;
                                for (int j = i + 1; j < BeginEnd.Length; j++)
                                    if (BeginEnd[j] == '*' || BeginEnd[j] == '/' || BeginEnd[j] == '+' || BeginEnd[j] == '-')
                                    { a = true; H = j; break; }
                                if (a)
                                    for (int n = i + 1; n < H; n++) B = B + BeginEnd[n];
                                else
                                    for (int n = i + 1; n < BeginEnd.Length; n++) B = B + BeginEnd[n];
                                        ArraySourse[temp].Rows[amal - 1].Cells[0].Value = "M" + amal.ToString();
                                if (BeginEnd[i] == '*')
                                    ArraySourse[temp].Rows[amal - 1].Cells[1].Value = '*';
                                else
                                    ArraySourse[temp].Rows[amal - 1].Cells[1].Value = '/';
                                ArraySecond[temp].Rows[amal - 1].Cells[2].Value = A;
                                ArraySecond[temp].Rows[amal - 1].Cells[3].Value = B;
                                ArraySecond[temp].Rows[amal - 1].Cells[4].Value = (amal - 1).ToString();
                                if (amal < amallar_soni) ArraySecond[temp].Rows[amal - 1].Cells[5].Value = (amal + 1).ToString();
                                else
                                    ArraySecond[temp].Rows[amal - 1].Cells[5].Value = "0";
                                A = ""; B = "";
                                for (int p = 0; p <= J; p++)
                                    tr = tr + BeginEnd[p];
                                tr = tr + "M" + amal.ToString();
                                for (int p = H; p < BeginEnd.Length; p++)
                                    tr = tr + BeginEnd[p];
                                BeginEnd = tr; tr = "";
                                amal++; AmallarS++;
                                i = J;
                            }
                        }

                        A = ""; B = "";
                        for (int i = 0; i < BeginEnd.Length; i++)
                        {
                            if (BeginEnd[i] == '+' || BeginEnd[i] == '-')
                            {
                                string tr = "";
                                bool a = false; int J = -1, H = BeginEnd.Length + 1;
                                for (int j = i - 1; j >= 0; j--)
                                    if (BeginEnd[j] == '/' || BeginEnd[j] == '*' || BeginEnd[j] == '+' || BeginEnd[j] == '-')
                                    { J = j; a = true; break; }

                                if (a)
                                    for (int n = J + 1; n < i; n++)
                                        A = A + BeginEnd[n];
                                else
                                    for (int n = 0; n < i; n++) A = A + BeginEnd[n];
                                a = false;
                                for (int j = i + 1; j < BeginEnd.Length; j++)
                                    if (BeginEnd[j] == '*' || BeginEnd[j] == '/' || BeginEnd[j] == '+' || BeginEnd[j] == '-')
                                    { a = true; H = j; break; }
                                if (a)
                                    for (int n = i + 1; n < H; n++) B = B + BeginEnd[n];
                                else
                                    for (int n = i + 1; n < BeginEnd.Length; n++) B = B + BeginEnd[n];
                                ArraySecond[temp].Rows[amal - 1].Cells[0].Value = "M" + amal.ToString();
                                if (BeginEnd[i] == '+')
                                    ArraySecond[temp].Rows[amal - 1].Cells[1].Value = '+';
                                else
                                    ArraySecond[temp].Rows[amal - 1].Cells[1].Value = '-';
                                ArraySecond[temp].Rows[amal - 1].Cells[2].Value = A;
                                ArraySecond[temp].Rows[amal - 1].Cells[3].Value = B;
                                ArraySecond[temp].Rows[amal - 1].Cells[4].Value = (amal - 1).ToString();
                                if (amal < amallar_soni) ArraySecond[temp].Rows[amal - 1].Cells[5].Value = (amal + 1).ToString();
                                else
                                    ArraySecond[temp].Rows[amal - 1].Cells[5].Value = "0";
                                A = ""; B = "";
                                for (int p = 0; p <= J; p++)
                                    tr = tr + BeginEnd[p];
                                tr = tr + "M" + amal.ToString();
                                for (int p = H; p < BeginEnd.Length; p++)
                                    tr = tr + BeginEnd[p];
                                BeginEnd = tr; tr = "";
                                amal++; AmallarS++;
                                i = J;
                            }
                        }
                        A = ""; B = "";

                        if (AmallarS == AmmallarSoniN) break;
                    }
                    for (int i = 0; i < qavs_ochilishi; i++) trr = trr + ifoda[i];
                    trr = trr + BeginEnd;
                    for (int i = qavs_yopilishi + 1; i < ifoda.Length; i++) trr = trr + ifoda[i];
                    ifoda = trr;
                    trr = "";
                }
                else
                {
                    BeginEnd = ifoda;
                    int amallar_Soni = AmmalarSoniFunction(BeginEnd), amallar_ = 1;
                     while (amallar_ <= amallar_Soni + 1)
                    {
                        for (int i = 0; i < BeginEnd.Length; i++)
                        {
                            if (BeginEnd[i] == '*' || BeginEnd[i] == '/')
                            {
                                string tr = "";
                                bool a = false; int J = -1, H = BeginEnd.Length + 1;
                                for (int j = i - 1; j >= 0; j--)
                                    if (BeginEnd[j] == '/' || BeginEnd[j] == '*' || BeginEnd[j] == '+' || BeginEnd[j] == '-')
                                    { J = j; a = true; break; }
                                if (a)
                                    for (int n = J + 1; n < i; n++)
                                        A = A + BeginEnd[n];
                                else
                                    for (int n = 0; n < i; n++) A = A + BeginEnd[n];
                                a = false;
                                for (int j = i + 1; j < BeginEnd.Length; j++)
                                    if (BeginEnd[j] == '*' || BeginEnd[j] == '/' || BeginEnd[j] == '+' || BeginEnd[j] == '-')
                                    { a = true; H = j; break; }
                                if (a)
                                    for (int n = i + 1; n < H; n++) B = B + BeginEnd[n];
                                else
                                    for (int n = i + 1; n < BeginEnd.Length; n++) B = B + BeginEnd[n];
                                ArraySecond[temp].Rows[amal - 1].Cells[0].Value = "M" + amal.ToString();
                                if (BeginEnd[i] == '*')
                                    ArraySecond[temp].Rows[amal - 1].Cells[1].Value = '*';
                                else
                                    ArraySecond[temp].Rows[amal - 1].Cells[1].Value = '/';
                                ArraySecond[temp].Rows[amal - 1].Cells[2].Value = A;
                                ArraySecond[temp].Rows[amal - 1].Cells[3].Value = B;
                                ArraySecond[temp].Rows[amal - 1].Cells[4].Value = (amal - 1).ToString();
                                if (amal < amallar_soni) ArraySecond[temp].Rows[amal - 1].Cells[5].Value = (amal + 1).ToString();
                                else
                                    ArraySecond[temp].Rows[amal - 1].Cells[5].Value = "0";
                                A = ""; B = "";
                                for (int p = 0; p <= J; p++)
                                    tr = tr + BeginEnd[p];
                                tr = tr + "M" + amal.ToString();
                                for (int p = H; p < BeginEnd.Length; p++)
                                    tr = tr + BeginEnd[p];
                                BeginEnd = tr; tr = "";
                                amal++; amallar_++;
                                i = J;
                            }
                        }
                        A = ""; B = "";
                        for (int i = 0; i < BeginEnd.Length; i++)
                        {
                            if (BeginEnd[i] == '+' || BeginEnd[i] == '-')
                            {
                                string tr = "";
                                bool a = false; int J = -1, H = BeginEnd.Length + 1;
                                for (int j = i - 1; j >= 0; j--)
                                    if (BeginEnd[j] == '/' || BeginEnd[j] == '*' || BeginEnd[j] == '+' || BeginEnd[j] == '-')
                                    { J = j; a = true; break; }
                                if (a)
                                    for (int n = J + 1; n < i; n++)
                                        A = A + BeginEnd[n];
                                else
                                    for (int n = 0; n < i; n++) A = A + BeginEnd[n];
                                a = false;
                                for (int j = i + 1; j < BeginEnd.Length; j++)
                                    if (BeginEnd[j] == '*' || BeginEnd[j] == '/' || BeginEnd[j] == '+' || BeginEnd[j] == '-')
                                    { a = true; H = j; break; }
                                if (a)
                                    for (int n = i + 1; n < H; n++) B = B + BeginEnd[n];
                                else
                                    for (int n = i + 1; n < BeginEnd.Length; n++) B = B + BeginEnd[n];
                                ArraySecond[temp].Rows[amal - 1].Cells[0].Value = "M" + amal.ToString();
                                if (BeginEnd[i] == '+')
                                    ArraySecond[temp].Rows[amal - 1].Cells[1].Value = '+';
                                else
                                    ArraySecond[temp].Rows[amal - 1].Cells[1].Value = '-';
                                ArraySecond[temp].Rows[amal - 1].Cells[2].Value = A;
                                ArraySecond[temp].Rows[amal - 1].Cells[3].Value = B;
                                ArraySecond[temp].Rows[amal - 1].Cells[4].Value = (amal - 1).ToString();
                                if (amal < amallar_soni) ArraySecond[temp].Rows[amal - 1].Cells[5].Value = (amal + 1).ToString();
                                else
                                    ArraySecond[temp].Rows[amal - 1].Cells[5].Value = "0";
                                A = ""; B = "";
                                for (int p = 0; p <= J; p++)
                                    tr = tr + BeginEnd[p];
                                tr = tr + "M" + amal.ToString();
                                for (int p = H; p < BeginEnd.Length; p++)
                                    tr = tr + BeginEnd[p];
                                BeginEnd = tr; tr = "";
                                amal++; amallar_++;
                                i = J;
                            }
                        }
                        if (amallar_ == amallar_Soni + 1) break;
                    }
                    if (amal == amallar_soni) break;
                }
            }
            ////////////////////////
            bool NewArray = true; int sonCound = 0, S = 0, shortAmal = 0;
            while (NewArray)
            {
                NewArray = false;
                for (int i = 0; i < ArraySecond[sonCound].RowCount - shortAmal; i++)
                {
                    for (int j = i + 1; j < ArraySecond[sonCound].RowCount - shortAmal; j++)
                    {
                        string LookLikeArray = "", Convertion = "";
                        string iA = "", iB = "", jA = "", jB = "", ia = "", ja = "";
                        ia = ia + ArraySecond[sonCound].Rows[i].Cells[1].Value.ToString();
                        ja = ja + ArraySecond[sonCound].Rows[j].Cells[1].Value.ToString();
                        iA = iA + ArraySecond[sonCound].Rows[i].Cells[2].Value.ToString();
                        iB = iB + ArraySecond[sonCound].Rows[i].Cells[3].Value.ToString();
                        jA = jA + ArraySecond[sonCound].Rows[j].Cells[2].Value.ToString();
                        jB = jB + ArraySecond[sonCound].Rows[j].Cells[3].Value.ToString();
                        if (ia == ja && iA == jA && iB == jB || ia == ja && iA == jB && iB == jA && ia != "-" && ia != "/")
                        {
                            S++;
                            LookLikeArray = ArraySecond[sonCound].Rows[j].Cells[0].Value.ToString();
                            Convertion = ArraySecond[sonCound].Rows[i].Cells[0].Value.ToString();
                            temp = sonCound + 1;
                            ArraySecond[temp] = new DataGridView();
                            ArraySecond[temp].Left = temp * 190 + 10;
                            ArraySecond[temp].RowHeadersVisible = false;
                            ArraySecond[temp].ColumnHeadersVisible = false;
                            ArraySecond[temp].Height = 400;
                            ArraySecond[temp].Width = 190;
                            ArraySourse.Add(ArraySecond[temp]);
                            ArraySecond[temp].RowCount = amallar_soni;
                            ArraySecond[temp].ColumnCount = 6;
                            for (int k = 0; k < j; k++)
                            {
                                ArraySecond[temp].Rows[k].Cells[0].Value = ArraySecond[sonCound].Rows[k].Cells[0].Value.ToString();
                                ArraySecond[temp].Rows[k].Cells[1].Value = ArraySecond[sonCound].Rows[k].Cells[1].Value.ToString();
                                ArraySecond[temp].Rows[k].Cells[2].Value = ArraySecond[sonCound].Rows[k].Cells[2].Value.ToString();
                                ArraySecond[temp].Rows[k].Cells[3].Value = ArraySecond[sonCound].Rows[k].Cells[3].Value.ToString();
                                ArraySecond[temp].Rows[k].Cells[4].Value = ArraySecond[sonCound].Rows[k].Cells[4].Value.ToString();
                                ArraySecond[temp].Rows[k].Cells[5].Value = ArraySecond[sonCound].Rows[k].Cells[5].Value.ToString();
                            }
                            for (int k = j + 1; k < ArraySecond[sonCound].RowCount - shortAmal; k++)
                            {
                                ArraySecond[temp].Rows[k - 1].Cells[0].Value = ArraySecond[sonCound].Rows[k].Cells[0].Value.ToString();
                                ArraySecond[temp].Rows[k - 1].Cells[1].Value = ArraySecond[sonCound].Rows[k].Cells[1].Value.ToString();
                                ArraySecond[temp].Rows[k - 1].Cells[2].Value = ArraySecond[sonCound].Rows[k].Cells[2].Value.ToString();
                                ArraySecond[temp].Rows[k - 1].Cells[3].Value = ArraySecond[sonCound].Rows[k].Cells[3].Value.ToString();
                                ArraySecond[temp].Rows[k - 1].Cells[4].Value = ArraySecond[sonCound].Rows[k].Cells[4].Value.ToString();
                                ArraySecond[temp].Rows[k - 1].Cells[5].Value = ArraySecond[sonCound].Rows[k].Cells[5].Value.ToString();
                            }
                            ArraySecond[temp].Rows[j - 1].Cells[5].Value = ArraySecond[temp - 1].Rows[j].Cells[5].Value.ToString();
                            ArraySecond[temp].Rows[j].Cells[4].Value = ArraySecond[temp - 1].Rows[j].Cells[4].Value.ToString();
                            for (int s = 0; s < ArraySecond[temp].RowCount; s++)
                            {
                                if (ArraySecond[temp].Rows[s].Cells[2].Value != null)
                                {
                                    if (ArraySecond[temp].Rows[s].Cells[2].Value.ToString() == LookLikeArray) ArraySecond[temp].Rows[s].Cells[2].Value = Convertion;
                                    if (ArraySecond[temp].Rows[s].Cells[3].Value.ToString() == LookLikeArray) ArraySecond[temp].Rows[s].Cells[3].Value = Convertion;
                                }
                            }
                        }
                        if (S == 1) { break; }
                    }
                    if (S == 1) { NewArray = true; sonCound++; S = 0; shortAmal++; }
                }
                if (!NewArray) break;
            }
        }
        private int AmmalarSoniFunction(string beginEnd)
        {
            int countAmal = 0;
            for (int i = 0; i < beginEnd.Length; i++)
                if (beginEnd[i] == '+' || beginEnd[i] == '-' || beginEnd[i] == '*' || beginEnd[i] == '/') countAmal++;
            return countAmal;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            ArraySourse.Clear();
            if (textBox2.Text.Length >= 3)
            {
                Aptimallash(textBox2.Text);
                dataGridView1.RowCount = ArraySourse[0].RowCount;
                if (ArraySourse.Count > 1)
                {
                    dataGridView2.RowCount = ArraySourse[ArraySourse.Count - 1].RowCount;
                    for (int i = 0; i < ArraySourse[0].RowCount; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            dataGridView2.Rows[i].Cells[j].Value = ArraySourse[ArraySourse.Count - 1].Rows[i].Cells[j].Value;
                        }
                    }
            
                }
                for (int i = 0; i < ArraySourse[0].RowCount; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = ArraySourse[0].Rows[i].Cells[j].Value;
                    }
                }
                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
