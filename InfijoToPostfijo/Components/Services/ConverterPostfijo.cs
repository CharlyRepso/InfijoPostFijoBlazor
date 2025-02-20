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

                if (char.IsLetterOrDigit(c))
                {
                    numero += c;
                }
                else if (c == '(')
                {
                    pila.push(c.ToString());
                }
                else if (c == ')')
                {
                    while (!pila.isEmpty() && pila.getTope() != "(")
                    {
                        salida += pila.pop();
                    }
                    pila.pop(); // Eliminar '('
                }
                else
                {
                    while (!pila.isEmpty() && precedencia(c.ToString()) != 0 && precedencia(pila.getTope()) >= precedencia(c.ToString()))
                    {
                        salida += pila.pop();
                    }
                    pila.push(c.ToString());
                }

                if (i < expresionInfija.Length)
                {
                    if (numero != "")
                    {
                        
                    }
                    salida += numero + " ";
                    numero = "";
                }
            }

            




            while (!pila.isEmpty())
            {
                salida += pila.pop();
            }

            return salida;
        }
    }
}
