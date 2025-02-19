namespace InfijoToPostfijo.Components.Services
{
    public class ConverterPostfijo
    {
        private Dictionary<char, int> precedencia = new Dictionary<char, int>
        {
            { '+', 1 }, { '-', 1 }, { '*', 2 }, { '/', 2 }, { '^', 3 }
        };

        public string Convertir(string expresionInfija)
        {

            Pila pila = new Pila (expresionInfija.Length);

            String salida = "";

            foreach (char c in expresionInfija)
            {
                if (char.IsLetterOrDigit(c))
                {
                    salida += c;
                }
                else if (c == '(')
                {
                    pila.push(c);
                }
                else if (c == ')')
                {
                    while (!pila.isEmpty() && pila.getTope() != '(')
                    {
                        salida += pila.pop();
                    }
                    pila.pop(); // Eliminar '('
                }
                else
                {
                    while (!pila.isEmpty() && precedencia.ContainsKey(pila.getTope()) && precedencia[pila.getTope()] >= precedencia[c])
                    {
                        salida += pila.pop();
                    }
                    pila.push(c);
                }
            }

            while (!pila.isEmpty())
            {
                salida+= pila.pop();
            }

            return salida;
        }
    }
}
