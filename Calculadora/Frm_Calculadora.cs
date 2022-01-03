using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Frm_Calculadora : Form
    {
        // Variáveis
        double num1, num2, numAtual, numAtualInvertido;
        bool novoNum = true;
        string operacao;
        string textoSaida;

        public Frm_Calculadora()
        {
            InitializeComponent();
        }

        // Funções Auxiliares
        private bool OperacaoEstaPendente()
        {
            return !string.IsNullOrEmpty(operacao);
        }
        private void OperacaoClick(string operacaoParam)
        {
            if (!string.IsNullOrWhiteSpace(this.Txt_Saida.Text))
            {
                if (!novoNum)
                {
                    Calcular();
                    novoNum = true;
                    num1 = double.Parse(this.Txt_Saida.Text);
                    operacao = operacaoParam;
                }
            }
        }
        private void NumClick(string num)
        {
            if (novoNum)
            {
                this.Txt_Saida.Text = num;
                novoNum = false;
            }
            else
            {
                this.Txt_Saida.AppendText(num);
            }
        }
        private void Calcular()
        {
            if (OperacaoEstaPendente())
            {
                num2 = double.Parse(this.Txt_Saida.Text);

                switch (operacao)
                {
                    case "+":
                        this.Txt_Saida.Text = (num1 + num2).ToString("F2");
                        break;
                    case "-":
                        this.Txt_Saida.Text = (num1 - num2).ToString("F2");
                        break;
                    case "/":
                        this.Txt_Saida.Text = (num1 / num2).ToString("F2");
                        break;
                    case "*":
                        this.Txt_Saida.Text = (num1 * num2).ToString("F2");
                        break;
                }
            }
        }

        // Funções OnClick
        private void Btn_Zero_Click(object sender, EventArgs e)
        {
            NumClick("0");
        }
        private void Btn_Um_Click(object sender, EventArgs e)
        {
            NumClick("1");
        }
        private void Btn_Dois_Click(object sender, EventArgs e)
        {
            NumClick("2");
        }
        private void Btn_Tres_Click(object sender, EventArgs e)
        {
            NumClick("3");
        }
        private void Btn_Quatro_Click(object sender, EventArgs e)
        {
            NumClick("4");
        }
        private void Btn_Cinco_Click(object sender, EventArgs e)
        {
            NumClick("5");
        }
        private void Btn_Seis_Click(object sender, EventArgs e)
        {
            NumClick("6");
        }
        private void Btn_Sete_Click(object sender, EventArgs e)
        {
            NumClick("7");
        }
        private void Btn_Oito_Click(object sender, EventArgs e)
        {
            NumClick("8");
        }
        private void Btn_Nove_Click(object sender, EventArgs e)
        {
            NumClick("9");
        }

        private void Btn_Virgula_Click(object sender, EventArgs e)
        {
            if (!this.Txt_Saida.Text.Contains(',') && !string.IsNullOrWhiteSpace(this.Txt_Saida.Text))
            {
                this.Txt_Saida.AppendText(",");
            }
        }
        private void Btn_Adicao_Click(object sender, EventArgs e)
        {
            OperacaoClick("+");
        }
        private void Btn_Subtracao_Click(object sender, EventArgs e)
        {
            OperacaoClick("-");
        }
        private void Btn_Multiplicacao_Click(object sender, EventArgs e)
        {
            OperacaoClick("*");
        }
        private void Btn_Divisao_Click(object sender, EventArgs e)
        {
            OperacaoClick("/");
        }
        private void Btn_Igual_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.Txt_Saida.Text))
            {
                Calcular();
            }
        }
        private void Btn_Inverte_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.Txt_Saida.Text) && !this.Txt_Saida.Text.StartsWith("0"))
            {
                numAtual = (double.Parse(this.Txt_Saida.Text));

                numAtualInvertido = numAtual * -1;

                this.Txt_Saida.Text = numAtualInvertido.ToString();
            }
        }
        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            this.Txt_Saida.ResetText();
            novoNum = true;
            num1 = 0;
            operacao = string.Empty;
        }
        private void Btn_BackSpace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.Txt_Saida.Text))
            {
                textoSaida = this.Txt_Saida.Text;
                textoSaida = textoSaida.Substring(0, textoSaida.Length - 1);

                this.Txt_Saida.Text = textoSaida;
            }
        }
    }
}