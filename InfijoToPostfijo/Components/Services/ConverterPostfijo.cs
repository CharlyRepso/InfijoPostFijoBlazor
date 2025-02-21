using System.Numerics;

namespace InfijoToPostfijo.Components.Services
{
    public class ConverterPostfijo
    {
        private int precedencia(string c)
        {
            int nivel = 0;

            switch (c)
            {
                case "+":
                case "-":
                    nivel = 1;
                    break;
                case "*":
                case "/":
                    nivel = 2;
                    break;
                case "^":
                    nivel = 3;
                    break;
            }
            return nivel;
        }

        public string Convertir(string expresionInfija)
        {

            Pila pila = new Pila(expresionInfija.Length);

            string salida = "";
            string numero = "";


            for (int i = 0; i < expresionInfija.Length; i++)
            {

                char c = expresionInfija[i];

                if (!char.IsLetterOrDigit(c) && c != '(')
                {
                    salida += numero + " ";
                    numero = "";

                }

                if (char.IsLetterOrDigit(c))
                {
                    numero += c;
                    if (i == expresionInfija.Length - 1)
                    {
                        salida += numero+" ";
                    }
                }
                else if (c == '(')
                {
                    pila.push(c.ToString());
                }
                else if (c == ')')
                {
                    while (!pila.isEmpty() && pila.getTope() != "(")
                    {
                        salida += pila.pop()+" ";
                    }
                    pila.pop(); // Eliminar '('
                }
                else
                {
                    while (!pila.isEmpty() && precedencia(c.ToString()) != 0 && precedencia(pila.getTope()) >= precedencia(c.ToString()))
                    {
                        salida += pila.pop()+" ";
                    }
                    pila.push(c.ToString());
                }
            }


            while (!pila.isEmpty())
            {
                salida += pila.pop()+" ";
            }

            return salida;
        }

        public string Operar(string expresionPostfija)
        {
            string resultado;
            string[] elementos = expresionPostfija.Split(' ');
            Pila pila = new Pila(expresionPostfija.Length);
            double a = 0;
            double b = 0;

            for (int i = 0; i < elementos.Length-1; i++)
            {
                string element = elementos[i];
                switch (element)
                {
                    case "+":
                        a = double.Parse(pila.pop());
                        b = double.Parse(pila.pop());
                        
                        pila.push(sumar(a, b).ToString());
                        break;
                    case "-":
                        b = double.Parse(pila.pop());
                        a = double.Parse(pila.pop());
                        pila.push(restar(a, b).ToString());
                        break;
                    case "*":
                        a = double.Parse(pila.pop());
                        b = double.Parse(pila.pop());
                        pila.push(multiplicar(a, b).ToString());
                        break;
                    case "/":
                        b = double.Parse(pila.pop());
                        a = double.Parse(pila.pop());
                        pila.push(dividir(a, b).ToString());
                        break;
                    case "^":
                        b = double.Parse(pila.pop());
                        a = double.Parse(pila.pop());
                        pila.push(Potencia(a, b).ToString());
                        break;
                    default:
                        pila.push(element);
                        break;
                }
            }

            resultado = pila.pop();
            System.Diagnostics.Debug.WriteLine(resultado);

            return resultado;
        }


        private double sumar(double a, double b) { return a + b; }

        private double restar(double a, double b) { return a - b; }

        private double multiplicar (double a, double b) {return a * b; }

        private double dividir (double a, double b) { return a / b; }

        private double Potencia(double a, double b) { return Math.Pow(a,b); }

    }
}
