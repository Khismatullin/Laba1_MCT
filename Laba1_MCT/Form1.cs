using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
if <логическое выражение> then
    <операторы>
[elseif < логическое выражение > then
    <операторы>] 
… 
[ else  
    <операторы> ]
end

<логическое выражение> → <операнд> | <операнд><операция сравнения><операнд> 

<операция сравнения> → < | > | <= | >= | = | <> 

<операнд> → <идентификатор>|<константа> 

<операторы> → <идентификатор> = <арифметическое выражение> 

<арифметическое выражение> → <операнд> |  <операнд><арифметическая операция><арифметическое выражение> 

<арифметическая операция> → +|-
*/

namespace Laba1_MCT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool constant = false;
        bool variable = false;
        bool restart = false;
        bool reallyoperation = false;

        int s;
        int x;
        int y;
        int z;

        //output changing variable
        void outputInStack(string variable, int value)
        {
            richTextBoxStack.Text += variable + " = " + value;
            richTextBoxStack.Text += Environment.NewLine;
        }

        void outputPolis(string operand)
        {
            textBoxPolis.Text += operand + " ";
        }

        void waitingThen(string input, int index)
        {
            if (input != "then ")
            {
                MessageBox.Show("Ожидается then, вместо '" + input + "' ! (" + index + ")");
                Application.Restart();
                this.Dispose();
            }
        }

        void waitingElseif(string input, int index)
        {
            if (input != "elseif ")
            {
                MessageBox.Show("Ожидается elseif, вместо '" + input + "' ! (" + index + ")");
                Application.Restart();
                this.Dispose();
            }
        }

        void waitingElse(string input, int index)
        {
            if (input != "else ")
            {
                MessageBox.Show("Ожидается else, вместо '" + input + "' ! (" + index + ")");
                Application.Restart();
                this.Dispose();
            }
        }

        void checkOnSemicolon(string input)
        {
            if (input[0] != ';' && (input.Length != 1))
                MessageBox.Show("Ожидается ';' вместо '" + input + "' !");
        }

        void checkOnArithmetic(string input)
        {
            if (input[0] != '+' && input[0] != '-')
                MessageBox.Show("Ожидается '+' или '-' вместо '" + input + "' !");
        }

        void checkOnOperand(string input, int index)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '<' || input[i] == '>' || input[i] == '=' || input[i] == ';' || input[i] == '+' || input[i] == '-')
                {
                    MessageBox.Show("Ожидается операнд, а не '" + input + "' ! (" + index + ")");
                    restart = true;
                    break;
                }
            }
            if (restart)
            {
                restart = false;
                Application.Restart();
                this.Dispose();
            }
        }

        void findAndOutput(string input)
        {
            //finding string on dgv
            for (int num = 0; num < dataGridViewIdentificators.RowCount; num++)
            {
                if (dataGridViewIdentificators.Rows[num].Cells[1].Value.ToString() == input)
                    textBoxLeksem.Text += (++num) + " ";
            }
        }

        void determineType(string input)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Convert.ToInt64(input[0]) == (i + 48))
                {
                    for (int k = 1; k < input.Length; k++)
                    {
                        if (Convert.ToInt64(input[k]) != (i + 48))
                        {
                            MessageBox.Show("Данное выражение ('" + input + "')" + " не является константой или переменной!");
                            break;
                        }
                        else
                        {
                        }
                    }
                    constant = true;
                }
            }
            variable = true;
        }

        bool duplicateInDgv(string input)
        {
            int count = 0;
            for (int num = 0; num < dataGridViewIdentificators.RowCount; num++)
            {
                if (dataGridViewIdentificators.Rows[num].Cells[1].Value.ToString() == input)
                    count++;
            }

            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        void isConst(string input)
        {
            //const ?
            for (int i = 0; i < 10; i++)
            {
                if (Convert.ToInt64(input[0]) == (i + 48))
                {
                    MessageBox.Show("Невозможно переопределить значение константы '" + input + "' !");
                    break;
                }
                else
                {
                    if (i == 9)
                        findAndOutput(input);
                }
            }
        }

        string findAndOutputLeksem(int input)
        {
            //finding string on dgv
            return (dataGridViewIdentificators.Rows[input - 1].Cells[1].Value).ToString();
        }

        private void buttonAnalysis_Click(object sender, EventArgs e)
        {
            textBoxLeksem.Text = "";
            textBoxPolis.Text = "";
            dataGridViewIdentificators.Rows.Clear();

            //default values variables
            s = 3;
            x = 8;
            y = 4;
            z = 5;

            //output on richTextBoxStack
            outputInStack("s", s);
            outputInStack("x", x);
            outputInStack("y", y);
            outputInStack("z", z);

            //default
            dataGridViewIdentificators.Rows.Add(1, "if", "If");
            dataGridViewIdentificators.Rows.Add(2, "elseif", "Elseif");
            dataGridViewIdentificators.Rows.Add(3, "then", "Then");
            dataGridViewIdentificators.Rows.Add(4, "else", "Else");
            dataGridViewIdentificators.Rows.Add(5, ";", "semic");
            dataGridViewIdentificators.Rows.Add(6, ">", "rel");
            dataGridViewIdentificators.Rows.Add(7, "<", "rel");
            dataGridViewIdentificators.Rows.Add(8, "==", "rel");
            dataGridViewIdentificators.Rows.Add(9, ">=", "rel");
            dataGridViewIdentificators.Rows.Add(10, "<=", "rel");
            dataGridViewIdentificators.Rows.Add(11, "<>", "rel");
            dataGridViewIdentificators.Rows.Add(12, "=", "as");
            dataGridViewIdentificators.Rows.Add(13, "+", "ar");
            dataGridViewIdentificators.Rows.Add(14, "-", "ar");

            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string th = "";
            string elsei = "";
            string els = "";
            string savedoperation = "";
            string secondsavedoperation = "";
            string address = "";
            int numberIf = 0;
            string invertString = "";
            int i1 = 0;
            int i2 = 0;
            int savedindex = 0;
            bool endElseif = false;
            bool offset1Right = false;
            bool emptyString = true;

            if (textBoxMainText.Text[0] == 'i' && textBoxMainText.Text[1] == 'f' && textBoxMainText.Text[2] == ' ')
            {
                //if
                findAndOutput("if");

                //variable or const ?
                while (textBoxMainText.Text[3 + i1] != ' ')
                {
                    str1 += textBoxMainText.Text[3 + i1];
                    i1++;
                }

                checkOnOperand(str1, 3 + i1 - 1);

                //add in Dgv
                if (!duplicateInDgv(str1))
                {
                    determineType(str1);
                    if (constant)
                    {
                        dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str1, "const");
                        constant = false;
                    }
                    else
                    {
                        dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str1, "var");
                        variable = false;
                    }
                }

                findAndOutput(str1);

                //output on textBoxPolis
                outputPolis(str1);

                //only 1 operand ?
                if (textBoxMainText.Text[i1 + 4] != 't')
                {
                    //operator(>,<,==,>=,<=)
                    if (textBoxMainText.Text[i1 + 4] == '>' || textBoxMainText.Text[i1 + 4] == '<' || (textBoxMainText.Text[i1 + 4] == '=' && textBoxMainText.Text[i1 + 5] == '=') || (textBoxMainText.Text[i1 + 4] == '>' && textBoxMainText.Text[i1 + 5] == '=') || (textBoxMainText.Text[i1 + 4] == '<' && textBoxMainText.Text[i1 + 5] == '='))
                    {
                        if (textBoxMainText.Text[i1 + 5] == ' ')//<,>
                        {
                            findAndOutput(textBoxMainText.Text[i1 + 4].ToString());

                            //save operation in string
                            savedoperation = textBoxMainText.Text[i1 + 4].ToString();

                            //variable
                            while (textBoxMainText.Text[i1 + 6 + i2] != ' ')
                            {
                                str2 += textBoxMainText.Text[i1 + 6 + i2];
                                i2++;
                            }

                            savedindex = i1 + 6 + i2;

                            checkOnOperand(str2, savedindex - 1);

                            //add in Dgv
                            if (!duplicateInDgv(str2))
                            {
                                determineType(str2);
                                if (constant)
                                {
                                    dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str2, "const");
                                    constant = false;
                                }
                                else
                                {
                                    dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str2, "var");
                                    variable = false;
                                }
                            }

                            //find on dgv and output on textBoxLexsem
                            findAndOutput(str2);
                            outputPolis(str2);
                            outputPolis(savedoperation);
                            savedoperation = "";
                        }
                        else//>=,<=,==,<>
                        {
                            //offset on 1 right
                            offset1Right = true;

                            findAndOutput((textBoxMainText.Text[i1 + 4].ToString() + textBoxMainText.Text[i1 + 5]));
                            savedoperation = textBoxMainText.Text[i1 + 4] + textBoxMainText.Text[i1 + 5].ToString();

                            //variable
                            while (textBoxMainText.Text[i1 + 7 + i2] != ' ')
                            {
                                str2 += textBoxMainText.Text[i1 + 7 + i2];
                                i2++;
                            }

                            savedindex = i1 + 7 + i2;

                            checkOnOperand(str2, savedindex - 1);

                            //add in Dgv
                            if (!duplicateInDgv(str2))
                            {
                                determineType(str2);
                                if (constant)
                                {
                                    dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str2, "const");
                                    constant = false;
                                }
                                else
                                {
                                    dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str2, "var");
                                    variable = false;
                                }
                            }

                            //find on dgv and write on textBoxLexsem
                            findAndOutput(str2);
                            outputPolis(str2);
                            outputPolis(savedoperation);
                            savedoperation = "";
                        }
                        th = "";
                        th += textBoxMainText.Text[savedindex + 1] + textBoxMainText.Text[savedindex + 2].ToString() + textBoxMainText.Text[savedindex + 3] + textBoxMainText.Text[savedindex + 4] + " ";
                        waitingThen(th, savedindex);
                    }
                    else
                    {
                        waitingThen(textBoxMainText.Text[i1 + 4].ToString(), i1 + 4);
                    }
                }
                else
                {
                    savedindex = 4 + i1;
                    th = "";
                    th += textBoxMainText.Text[savedindex] + textBoxMainText.Text[savedindex + 1].ToString() + textBoxMainText.Text[savedindex + 2] + textBoxMainText.Text[savedindex + 3] + " ";
                    waitingThen(th, savedindex);

                    //something fail
                    savedindex = savedindex - 1;
                }

                //address(on I1) and transition
                outputPolis("00 JZ");

                //then
                findAndOutput("then");

                //" then "
                savedindex = savedindex + 6;

                //all operators
                while (endElseif == false)
                {
                    //only variable
                    while (textBoxMainText.Text[savedindex] != ' ')
                    {
                        str3 += textBoxMainText.Text[savedindex];
                        savedindex++;
                    }

                    //operand ?
                    checkOnOperand(str3, savedindex - 1);

                    //add in Dgv
                    if (!duplicateInDgv(str3))
                    {
                        determineType(str3);
                        if (constant)
                        {
                            dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str3, "const");
                            constant = false;
                        }
                        else
                        {
                            dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str3, "var");
                            variable = false;
                        }
                    }

                    //if const write error, else call findAndOutput()
                    isConst(str3);
                    outputPolis(str3);

                    //"="
                    findAndOutput("=");
                    savedoperation = "=";

                    //variable or const
                    while (textBoxMainText.Text[savedindex + 3] != ' ')
                    {
                        str4 += textBoxMainText.Text[savedindex + 3];
                        savedindex++;
                    }
                    savedindex = savedindex + 3;

                    checkOnOperand(str4, savedindex - 1);

                    //add in Dgv
                    if (!duplicateInDgv(str4))
                    {
                        determineType(str4);
                        if (constant)
                        {
                            dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str4, "const");
                            constant = false;
                        }
                        else
                        {
                            dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str4, "var");
                            variable = false;
                        }
                    }

                    //find on dgv and write on textBoxLexsem
                    findAndOutput(str4);
                    outputPolis(str4);

                    //if available another variables and arithmetics operations
                    while (textBoxMainText.Text[savedindex + 1] != ';')
                    {
                        str5 = "";

                        //+ or -
                        if (textBoxMainText.Text[savedindex + 1] == '+' && textBoxMainText.Text[savedindex + 2] == ' ')
                        {
                            findAndOutput("+");
                            if (emptyString == false && secondsavedoperation[secondsavedoperation.Length - 1] != ' ')
                            {
                                secondsavedoperation += " " + "+";
                            }
                            else
                            {
                                secondsavedoperation += "+";
                                emptyString = false;
                            }
                        }

                        if (textBoxMainText.Text[savedindex + 1] == '-' && textBoxMainText.Text[savedindex + 2] == ' ')
                        {
                            findAndOutput("-");
                            if (emptyString == false && secondsavedoperation[secondsavedoperation.Length - 1] != ' ')
                            {
                                secondsavedoperation += " " + "-";
                            }
                            else
                            {
                                secondsavedoperation += "-";
                                emptyString = false;
                            }
                        }

                        checkOnArithmetic(textBoxMainText.Text[savedindex + 1].ToString());

                        //variable
                        while (textBoxMainText.Text[savedindex + 3] != ' ')
                        {
                            str5 += textBoxMainText.Text[savedindex + 3];
                            savedindex++;
                        }

                        savedindex = savedindex + 3;

                        checkOnOperand(str5, savedindex - 1);

                        //add in Dgv
                        if (!duplicateInDgv(str5))
                        {
                            determineType(str5);
                            if (constant)
                            {
                                dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str5, "const");
                                constant = false;
                            }
                            else
                            {
                                dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str5, "var");
                                variable = false;
                            }
                        }

                        findAndOutput(str5);
                        outputPolis(str5);
                    }
                    emptyString = true;
                    //;
                    findAndOutput(";");

                    //invert string secondsavedoperation
                    invertString = "";
                    for (int i = secondsavedoperation.Length - 1; i >= 0; i--)
                    {
                        invertString += secondsavedoperation[i];
                    }

                    if (invertString != "")
                        outputPolis(invertString);

                    outputPolis(savedoperation);
                    savedoperation = "";
                    secondsavedoperation = "";

                    //the last operator? (elseif)
                    if (textBoxMainText.Text[savedindex + 3] == 'e')
                    {
                        if (textBoxMainText.Text[savedindex + 4] == 'l' && textBoxMainText.Text[savedindex + 5] == 's' && textBoxMainText.Text[savedindex + 6] == 'e' && textBoxMainText.Text[savedindex + 7] == 'i' && textBoxMainText.Text[savedindex + 8] == 'f' && textBoxMainText.Text[savedindex + 9] == ' ')
                        {
                            endElseif = true;
                        }
                        else
                        {
                            elsei = "";
                            elsei += textBoxMainText.Text[savedindex + 3] + textBoxMainText.Text[savedindex + 4].ToString() + textBoxMainText.Text[savedindex + 5] + textBoxMainText.Text[savedindex + 6] + " ";
                            waitingElseif(elsei, savedindex);
                        }
                        ///else

                    }
                    else
                    {
                        savedindex = savedindex + 3;
                    }

                    str1 = "";
                    str2 = "";
                    str3 = "";
                    str4 = "";
                    str5 = "";
                    i1 = 0;
                    i2 = 0;
                }
                endElseif = false;

                //address(on Finally) and transition
                outputPolis("0N JMP");

                bool beginElse = false;

                while (beginElse == false)
                {
                    //elseif
                    if (textBoxMainText.Text[savedindex + 3] == 'e' && textBoxMainText.Text[savedindex + 4] == 'l' && textBoxMainText.Text[savedindex + 5] == 's' && textBoxMainText.Text[savedindex + 6] == 'e' && textBoxMainText.Text[savedindex + 7] == 'i' && textBoxMainText.Text[savedindex + 8] == 'f' && textBoxMainText.Text[savedindex + 9] == ' ')
                    {
                        findAndOutput("elseif");
                    }
                    else
                    {
                        elsei = "";
                        elsei += textBoxMainText.Text[savedindex + 3] + textBoxMainText.Text[savedindex + 4].ToString() + textBoxMainText.Text[savedindex + 5] + textBoxMainText.Text[savedindex + 6] + " ";
                        waitingElseif(elsei, savedindex);
                    }

                    //variable or const
                    while (textBoxMainText.Text[savedindex + 10 + i1] != ' ')
                    {
                        str1 += textBoxMainText.Text[savedindex + 10 + i1];
                        i1++;
                    }

                    checkOnOperand(str1, savedindex + 10 + i1 - 1);

                    //add in Dgv
                    if (!duplicateInDgv(str1))
                    {
                        determineType(str1);
                        if (constant)
                        {
                            dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str1, "const");
                            constant = false;
                        }
                        else
                        {
                            dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str1, "var");
                            variable = false;
                        }
                    }

                    findAndOutput(str1);
                    outputPolis(str1);

                    //only 1 operand ?
                    if (textBoxMainText.Text[i1 + savedindex + 11] != 't')
                    {
                        //operator(>,<,==,>=,<=,<>!)
                        if (textBoxMainText.Text[i1 + savedindex + 11] == '>' || textBoxMainText.Text[i1 + savedindex + 11] == '<' || (textBoxMainText.Text[i1 + savedindex + 11] == '=' && textBoxMainText.Text[i1 + savedindex + 12] == '=') || (textBoxMainText.Text[i1 + savedindex + 11] == '>' && textBoxMainText.Text[i1 + savedindex + 12] == '=') || (textBoxMainText.Text[i1 + savedindex + 11] == '<' && textBoxMainText.Text[i1 + savedindex + 12] == '='))
                        {
                            if (textBoxMainText.Text[i1 + savedindex + 12] == ' ')//<,>
                            {
                                findAndOutput(textBoxMainText.Text[i1 + savedindex + 11].ToString());
                                savedoperation = textBoxMainText.Text[i1 + savedindex + 11].ToString();

                                //variable
                                while (textBoxMainText.Text[i1 + savedindex + 13 + i2] != ' ')
                                {
                                    str2 += textBoxMainText.Text[i1 + savedindex + 13 + i2];
                                    i2++;
                                }

                                savedindex = i1 + savedindex + 13 + i2;

                                checkOnOperand(str2, savedindex - 1);

                                //add in Dgv
                                if (!duplicateInDgv(str2))
                                {
                                    determineType(str2);
                                    if (constant)
                                    {
                                        dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str2, "const");
                                        constant = false;
                                    }
                                    else
                                    {
                                        dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str2, "var");
                                        variable = false;
                                    }
                                }

                                //find on dgv and output on textBoxLexsem
                                findAndOutput(str2);
                                outputPolis(str2);
                                outputPolis(savedoperation);
                                savedoperation = "";
                            }
                            else//>=,<=,==,<>
                            {
                                //offset on 1 right
                                offset1Right = true;

                                findAndOutput((textBoxMainText.Text[i1 + savedindex + 11].ToString() + textBoxMainText.Text[i1 + savedindex + 12]));
                                savedoperation = textBoxMainText.Text[i1 + savedindex + 11] + textBoxMainText.Text[i1 + savedindex + 12].ToString();

                                //variable
                                while (textBoxMainText.Text[i1 + savedindex + 14 + i2] != ' ')
                                {
                                    str2 += textBoxMainText.Text[i1 + savedindex + 14 + i2];
                                    i2++;
                                }

                                savedindex = i1 + savedindex + 14 + i2;

                                checkOnOperand(str2, savedindex - 1);

                                //add in Dgv
                                if (!duplicateInDgv(str2))
                                {
                                    determineType(str2);
                                    if (constant)
                                    {
                                        dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str2, "const");
                                        constant = false;
                                    }
                                    else
                                    {
                                        dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str2, "var");
                                        variable = false;
                                    }
                                }

                                //find on dgv and write on textBoxLexsem
                                findAndOutput(str2);
                                outputPolis(str2);
                                outputPolis(savedoperation);
                                savedoperation = "";
                            }
                        }
                        else
                        {
                            waitingThen(textBoxMainText.Text[i1 + savedindex + 11].ToString(), i1 + savedindex + 11);
                        }
                    }
                    else
                    {
                        savedindex = savedindex + 12 + i1;
                        th = "";
                        th += textBoxMainText.Text[savedindex] + textBoxMainText.Text[savedindex + 1].ToString() + textBoxMainText.Text[savedindex + 2] + textBoxMainText.Text[savedindex + 3] + " ";
                        waitingThen(th, savedindex);
                    }

                    //address(on I2) and transition
                    numberIf++;
                    outputPolis("0" + numberIf + " JZ");

                    //then
                    findAndOutput("then");

                    //
                    savedindex = savedindex + 6;

                    //all operators
                    while (endElseif == false)
                    {
                        //only variable
                        while (textBoxMainText.Text[savedindex] != ' ')
                        {
                            str3 += textBoxMainText.Text[savedindex];
                            savedindex++;
                        }

                        checkOnOperand(str3, savedindex - 1);

                        //adding in Dgv
                        if (!duplicateInDgv(str3))
                        {
                            determineType(str3);
                            if (constant)
                            {
                                dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str3, "const");
                                constant = false;
                            }
                            else
                            {
                                dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str3, "var");
                                variable = false;
                            }
                        }

                        //if const write error, else call findAndOutput()
                        isConst(str3);
                        outputPolis(str3);

                        //"="
                        findAndOutput("=");
                        savedoperation = "=";

                        //variable or const
                        while (textBoxMainText.Text[savedindex + 3] != ' ')
                        {
                            str4 += textBoxMainText.Text[savedindex + 3];
                            savedindex++;
                        }
                        savedindex = savedindex + 3;

                        checkOnOperand(str4, savedindex - 1);

                        //add in Dgv
                        if (!duplicateInDgv(str4))
                        {
                            determineType(str4);
                            if (constant)
                            {
                                dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str4, "const");
                                constant = false;
                            }
                            else
                            {
                                dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str4, "var");
                                variable = false;
                            }
                        }

                        //find on dgv and write on textBoxLexsem
                        findAndOutput(str4);
                        outputPolis(str4);

                        //if available another variables and arithmetics operations
                        while (textBoxMainText.Text[savedindex + 1] != ';')
                        {
                            str5 = "";

                            //+ or -
                            if (textBoxMainText.Text[savedindex + 1] == '+' && textBoxMainText.Text[savedindex + 2] == ' ')
                            {
                                findAndOutput("+");
                                if (emptyString == false && secondsavedoperation[secondsavedoperation.Length - 1] != ' ')
                                {
                                    secondsavedoperation += " " + "+";
                                }
                                else
                                {
                                    secondsavedoperation += "+";
                                    emptyString = false;
                                }
                            }

                            if (textBoxMainText.Text[savedindex + 1] == '-' && textBoxMainText.Text[savedindex + 2] == ' ')
                            {
                                findAndOutput("-");
                                if (emptyString == false && secondsavedoperation[secondsavedoperation.Length - 1] != ' ')
                                {
                                    secondsavedoperation += " " + "-";
                                }
                                else
                                {
                                    secondsavedoperation += "-";
                                    emptyString = false;
                                }
                            }

                            checkOnArithmetic(textBoxMainText.Text[savedindex + 1].ToString());

                            //variable
                            while (textBoxMainText.Text[savedindex + 3] != ' ')
                            {
                                str5 += textBoxMainText.Text[savedindex + 3];
                                savedindex++;
                            }

                            savedindex = savedindex + 3;

                            checkOnOperand(str5, savedindex - 1);

                            //add in Dgv
                            if (!duplicateInDgv(str5))
                            {
                                determineType(str5);
                                if (constant)
                                {
                                    dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str5, "const");
                                    constant = false;
                                }
                                else
                                {
                                    dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str5, "var");
                                    variable = false;
                                }
                            }

                            findAndOutput(str5);
                            outputPolis(str5);
                        }
                        emptyString = true;

                        //;
                        findAndOutput(";");

                        //invert string secondsavedoperation
                        invertString = "";
                        for (int i = secondsavedoperation.Length - 1; i >= 0; i--)
                        {
                            invertString += secondsavedoperation[i];
                        }

                        if (invertString != "")
                            outputPolis(invertString);

                        outputPolis(savedoperation);
                        savedoperation = "";
                        secondsavedoperation = "";

                        //the last elseif ? (else)
                        if (textBoxMainText.Text[savedindex + 3] == 'e')
                        {
                            if (textBoxMainText.Text[savedindex + 4] == 'l' && textBoxMainText.Text[savedindex + 5] == 's' && textBoxMainText.Text[savedindex + 6] == 'e' && textBoxMainText.Text[savedindex + 7] == ' ')
                            {
                                endElseif = true;
                                beginElse = true;
                            }
                            else
                            {
                                if (textBoxMainText.Text[savedindex + 7] != 'i')//fail
                                {
                                    els = "";
                                    els += textBoxMainText.Text[savedindex + 4] + textBoxMainText.Text[savedindex + 5].ToString() + textBoxMainText.Text[savedindex + 6] + textBoxMainText.Text[savedindex + 7] + " ";
                                    waitingElse(els, savedindex);
                                }
                            }
                        }

                        //the last operator? (elseif)
                        if (textBoxMainText.Text[savedindex + 3] == 'e' && textBoxMainText.Text[savedindex + 4] == 'l' && textBoxMainText.Text[savedindex + 5] == 's' && textBoxMainText.Text[savedindex + 6] == 'e' && textBoxMainText.Text[savedindex + 7] == 'i' && textBoxMainText.Text[savedindex + 8] == 'f' && textBoxMainText.Text[savedindex + 9] == ' ')
                        {
                            endElseif = true;
                        }
                        else
                        {
                            savedindex = savedindex + 3;

                        }

                        str1 = "";
                        str2 = "";
                        str3 = "";
                        str4 = "";
                        str5 = "";
                        i1 = 0;
                        i2 = 0;


                    }//end while(endElseif == false) -- last operator
                    endElseif = false;

                    //address(on Finally) and transition
                    outputPolis("0N JMP");

                }//end while(beginElse == false)

                //else
                if (textBoxMainText.Text[savedindex] == 'e' && textBoxMainText.Text[savedindex + 1] == 'l' && textBoxMainText.Text[savedindex + 2] == 's' && textBoxMainText.Text[savedindex + 3] == 'e' && textBoxMainText.Text[savedindex + 4] == ' ')
                {
                    findAndOutput("else");
                }
                else
                {
                    els = "";
                    els += textBoxMainText.Text[savedindex] + textBoxMainText.Text[savedindex + 1].ToString() + textBoxMainText.Text[savedindex + 2] + textBoxMainText.Text[savedindex + 3] + " ";
                    waitingElse(els, savedindex);
                }

                //
                savedindex = savedindex + 5;

                //all operators
                while (endElseif == false)
                {
                    //only variable
                    while (textBoxMainText.Text[savedindex] != ' ')
                    {
                        str3 += textBoxMainText.Text[savedindex];
                        savedindex++;
                    }

                    checkOnOperand(str3, savedindex - 1);

                    //adding in Dgv
                    if (!duplicateInDgv(str3))
                    {
                        determineType(str3);
                        if (constant)
                        {
                            dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str3, "const");
                            constant = false;
                        }
                        else
                        {
                            dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str3, "var");
                            variable = false;
                        }
                    }

                    //if const write error, else call findAndOutput()
                    isConst(str3);
                    outputPolis(str3);

                    //"="
                    findAndOutput("=");
                    savedoperation = "=";

                    //variable or const
                    while (textBoxMainText.Text[savedindex + 3] != ' ')
                    {
                        str4 += textBoxMainText.Text[savedindex + 3];
                        savedindex++;
                    }
                    savedindex = savedindex + 3;

                    checkOnOperand(str4, savedindex - 1);

                    //add in Dgv
                    if (!duplicateInDgv(str4))
                    {
                        determineType(str4);
                        if (constant)
                        {
                            dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str4, "const");
                            constant = false;
                        }
                        else
                        {
                            dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str4, "var");
                            variable = false;
                        }
                    }

                    //find on dgv and write on textBoxLexsem
                    findAndOutput(str4);
                    outputPolis(str4);

                    //if available another variables and arithmetics operations
                    while (textBoxMainText.Text[savedindex + 1] != ';')
                    {
                        str5 = "";

                        //+ or -
                        if (textBoxMainText.Text[savedindex + 1] == '+' && textBoxMainText.Text[savedindex + 2] == ' ')
                        {
                            findAndOutput("+");
                            if (emptyString == false && secondsavedoperation[secondsavedoperation.Length - 1] != ' ')
                            {
                                secondsavedoperation += " " + "+";
                            }
                            else
                            {
                                secondsavedoperation += "+";
                                emptyString = false;
                            }
                        }

                        if (textBoxMainText.Text[savedindex + 1] == '-' && textBoxMainText.Text[savedindex + 2] == ' ')
                        {
                            findAndOutput("-");
                            if (emptyString == false && secondsavedoperation[secondsavedoperation.Length - 1] != ' ')
                            {
                                secondsavedoperation += " " + "-";
                            }
                            else
                            {
                                secondsavedoperation += "-";
                                emptyString = false;
                            }
                        }

                        checkOnArithmetic(textBoxMainText.Text[savedindex + 1].ToString());

                        //variable
                        while (textBoxMainText.Text[savedindex + 3] != ' ')
                        {
                            str5 += textBoxMainText.Text[savedindex + 3];
                            savedindex++;
                        }

                        savedindex = savedindex + 3;

                        checkOnOperand(str5, savedindex - 1);

                        //add in Dgv
                        if (!duplicateInDgv(str5))
                        {
                            determineType(str5);
                            if (constant)
                            {
                                dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str5, "const");
                                constant = false;
                            }
                            else
                            {
                                dataGridViewIdentificators.Rows.Add(dataGridViewIdentificators.RowCount + 1, str5, "var");
                                variable = false;
                            }
                        }

                        findAndOutput(str5);
                        outputPolis(str5);
                    }
                    emptyString = true;

                    //;
                    findAndOutput(";");

                    //invert string secondsavedoperation
                    invertString = "";
                    for (int i = secondsavedoperation.Length - 1; i >= 0; i--)
                    {
                        invertString += secondsavedoperation[i];
                    }

                    if (invertString != "")
                        outputPolis(invertString);

                    outputPolis(savedoperation);
                    savedoperation = "";
                    secondsavedoperation = "";

                    //the last operator? (end - " ")
                    if (textBoxMainText.Text[savedindex + 3] == ' ')
                    {
                        endElseif = true;
                    }
                    else
                    {
                        savedindex = savedindex + 3;
                    }

                    str1 = "";
                    str2 = "";
                    str3 = "";
                    str4 = "";
                    str5 = "";
                    i1 = 0;
                    i2 = 0;

                }//end while(ending == false)
                endElseif = false;
            }
            else
            {
                MessageBox.Show("Ожидается if !");
                Application.Restart();
                this.Dispose();
            }


        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            //checking
            textBoxProverka.Text = "";
            for (int i = 0; i < textBoxLeksem.Text.Length - 1; i++)
            {
                string allnumber = "";

                //from num to leksem
                while (textBoxLeksem.Text[i] != ' ')
                {
                    allnumber += textBoxLeksem.Text[i];
                    i++;
                }
                textBoxProverka.Text += findAndOutputLeksem(Convert.ToInt32(allnumber)) + " ";
            }
        }
        //x 5 < 00 JZ x s 1 y - + = s x 2 + = 0N JMP x 6 < 01 JZ y s x + = 0N JMP x 7 < 02 JZ z x 1 + = y z 4 - = 0N JMP s x z + = z s y - = 
        void checkOnReallyOperation(string input)
        {
            if (input == ">" || input == "<" || input == "==" || input == "<=" || input == ">=" || input == "<>")
                reallyoperation = true;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            //1 space for sign end of string
            textBoxPolis.Text += " ";

            for (int i = 0; i < textBoxPolis.Text.Length - 1; i++)
            {
                string varOroper1 = "";
                string varOroper2 = "";
                int var1 = 9999;
                int var2 = 9999;
                string operation = "";
                bool expression = false;
                bool exit = false;

                while (textBoxPolis.Text[i] != ' ')
                {
                    varOroper1 += textBoxPolis.Text[i];
                    i++;
                }

                while (textBoxPolis.Text[i + 1] != ' ')
                {
                    varOroper2 += textBoxPolis.Text[i + 1];
                    i++;
                }

                while (textBoxPolis.Text[i + 2] != ' ')
                {
                    operation += textBoxPolis.Text[i + 2];
                    i++;
                }

                if (varOroper1 == "s")
                    var1 = s;

                if (varOroper1 == "x")
                    var1 = x;

                if (varOroper1 == "y")
                    var1 = y;

                if (varOroper1 == "z")
                    var1 = z;

                if (varOroper2 == "s")
                    var2 = s;

                if (varOroper2 == "x")
                    var2 = x;

                if (varOroper2 == "y")
                    var2 = y;

                if (varOroper2 == "z")
                    var2 = z;

                if (var1 != s && var1 != x && var1 != y && var1 != z)
                {
                    var1 = Convert.ToInt32(varOroper1);
                }

                if (var2 != s && var2 != x && var2 != y && var2 != z)
                {
                    var2 = Convert.ToInt32(varOroper2);
                }

                if (operation == ">")
                    if (var1 > var2)
                        expression = true;

                if (operation == "<")
                    if (var1 < var2)
                        expression = true;

                if (operation == "==")
                    if (var1 == var2)
                        expression = true;

                if (operation == ">=")
                    if (var1 >= var2)
                        expression = true;

                if (operation == "<=")
                    if (var1 <= var2)
                        expression = true;

                if (operation == "<>")
                    if (var1 != var2)
                        expression = true;

                if (expression == false)
                {
                    checkOnReallyOperation(operation);
                    for (int j = i; j < textBoxPolis.Text.Length - 1; j++)
                    {
                        if ((textBoxPolis.Text[j] == ' ' && textBoxPolis.Text[j+1] == ' ') ||(textBoxPolis.Text[j] == 'J' && textBoxPolis.Text[j + 1] == 'M' && textBoxPolis.Text[j + 2] == 'P'))
                        {
                            //reallyoperation ---- >, <, >=, <=, ==, <>
                            if (reallyoperation == true)
                            {
                                reallyoperation = false;
                                i = j + 3;
                                break;
                            }
                            else
                            {
                                //position operation
                                i = i+1;

                                //if 1 operand (e.x. - s x =)
                                if (operation == "=")
                                {
                                    if (varOroper1 == "s")
                                    {
                                        s = var2;
                                        outputInStack("s", s);
                                    }

                                    if (varOroper1 == "x")
                                    {
                                        x = var2;
                                        outputInStack("x", x);
                                    }

                                    if (varOroper1 == "y")
                                    {
                                        y = var2;
                                        outputInStack("y", y);
                                    }

                                    if (varOroper1 == "z")
                                    {
                                        z = var2;
                                        outputInStack("z", z);
                                    }

                                    break;
                                }
                                else
                                {
                                    //if more operands(+,-)

                                    string var3 = operation;

                                    //next operand
                                    i = i + 2;

                                    //go right to first '-' or '+'
                                    while (textBoxPolis.Text[i] != '-' && textBoxPolis.Text[i] != '+')
                                    {
                                        i = i + 1;
                                    }
                                    string plusorminus = textBoxPolis.Text[i].ToString();

                                    string op1 = "";
                                    string op2 = "";
                                    int intop1 = 999;
                                    int intop2 = 999;

                                    //left to one operand
                                    i = i-2;
                                    
                                    while (textBoxPolis.Text[i] != ' ')
                                    {
                                        op2 += textBoxPolis.Text[i];
                                        i--;
                                    }

                                    //left to other operand
                                    i = i - 1;

                                    while (textBoxPolis.Text[i] != ' ')
                                    {
                                        op1 += textBoxPolis.Text[i];
                                        i--;
                                    }

                                    //calculate
                                    int tempresult = 9999;

                                    if (op1 == "s")
                                        intop1 = s;

                                    if (op1 == "x")
                                        intop1 = x;

                                    if (op1 == "y")
                                        intop1 = y;

                                    if (op1 == "z")
                                        intop1 = z;

                                    if (op2 == "s")
                                        intop2 = s;

                                    if (op2 == "x")
                                        intop2 = x;

                                    if (op2 == "y")
                                        intop2 = y;

                                    if (op2 == "z")
                                        intop2 = z;

                                    if (intop1 != s && intop1 != x && intop1 != y && intop1 != z)
                                    {
                                        intop1 = Convert.ToInt32(op1);
                                    }

                                    if (intop2 != s && intop2 != x && intop2 != y && intop2 != z)
                                    {
                                        intop2 = Convert.ToInt32(op2);
                                    }

                                    if (plusorminus == "+")
                                        tempresult = intop1 + intop2;

                                    if (plusorminus == "-")
                                        tempresult = intop1 - intop2;
                                }
                                    

                                //else (all operators)
                                while (textBoxPolis.Text[i] == ' ' && textBoxPolis.Text[i + 1] == ' ')
                                {
                                    

                                    i = i + 1;
                                }
                                //end one ";" (operator)



                                //or end else, or end if 
                                if ((textBoxPolis.Text[i] == ' ')||(textBoxPolis.Text[i] == '0' && textBoxPolis.Text[i+3] == 'J' && textBoxPolis.Text[i + 4] == 'M' && textBoxPolis.Text[i + 5] == 'P') )
                                    exit = true;
                            }
                        }
                    }
                    //else (operators)
                    

                    //the end ?
                    if (exit == true)
                        break;
                }
            }
        }
    }
}