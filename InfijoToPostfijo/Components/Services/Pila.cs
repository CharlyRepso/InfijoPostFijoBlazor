using Microsoft.AspNetCore.Components;

namespace InfijoToPostfijo.Components.Services
{
    public class Pila
    {
        private string[] pila { get; set; }
        private int longitud { get; set; }
        private int tope { get; set; }

        public Pila(int longitud)
        {
            this.longitud = longitud;
            this.pila = new string[this.longitud];
            this.tope = 0;
        }

        public bool isFull()
        {
            return this.longitud == this.tope;
        }

        public bool isEmpty()
        {
            return this.tope == 0;
        }

        public bool push(string elemento)
        {
            if (!this.isFull()) { 
                this.pila[tope] = elemento;
                this.tope++;
                return true;
            }
            else
            {
                return false;
            }

        }

        public string pop()
        {
            string element = "";
            if (!this.isEmpty())
            {
                tope--;
                element = pila[tope];
                pila[tope] = "";
            }

            return element;
        }

        public string getTope()
        {
            return this.pila[tope - 1];
        }
    }
}
