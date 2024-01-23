using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace definit
{
    public partial class MainPage : ContentPage
    {
        private string entradaActual = "";
        private string operadorActual = "";
        private double num1 = 0.0;
        private bool numeroIngresado = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void print(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string numero = button.Text;

            if (entradaActual == "0" || !numeroIngresado)
            {
                Resultado.Text = "";
                entradaActual = "";
                numeroIngresado = true;
            }
            entradaActual += numero;
            Resultado.Text += numero;
        }

        private void Erase(object sender, EventArgs e)
        {
            if (Resultado.Text.Length > 0)
            {
                Resultado.Text = Resultado.Text.Substring(0, Resultado.Text.Length - 1);
                entradaActual = Resultado.Text;
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            Resultado.Text = "";
            entradaActual = "";
            operadorActual = "";
            num1 = 0.0;
            numeroIngresado = false;
        }

        public double Calculadora(double primerNumero, double segundoNumero, string operacion)
        {
            switch (operacion)
            {
                case "+":
                    return primerNumero + segundoNumero;
                case "-":
                    return primerNumero - segundoNumero;
                case "*":
                    return primerNumero * segundoNumero;
                case "/":
                    if (segundoNumero != 0)
                    {
                        return primerNumero / segundoNumero;
                    }
                    else
                    {
                        Resultado.Text = "Error: División por cero";
                        return 0;
                    }
                default:
                    return 0;
            }
        }

        private void Operacion(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string operador = button.Text;

            if (numeroIngresado)
            {
                double num2 = double.Parse(entradaActual);

                if (operadorActual != "")
                {
                    num1 = Calculadora(num1, num2, operadorActual);
                    Resultado.Text = num1.ToString();
                }
                else
                {
                    num1 = num2;
                }
            }

            operadorActual = operador;
            numeroIngresado = false;
        }

        private void Igual(object sender, EventArgs e)
        {
            if (numeroIngresado)
            {
                double num2 = double.Parse(entradaActual);
                entradaActual = Calculadora(num1, num2, operadorActual).ToString();
                Resultado.Text = entradaActual;
                num1 = double.Parse(entradaActual); // Actualiza num1 con el resultado
                operadorActual = "";
                numeroIngresado = false;
            }
        }

        private void Decimal(object sender, EventArgs e)
        {
            if (!entradaActual.Contains("."))
            {
                entradaActual += ".";
                Resultado.Text += ".";
            }
        }
    }
}

