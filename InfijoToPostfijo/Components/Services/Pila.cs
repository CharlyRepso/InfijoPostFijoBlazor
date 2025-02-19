using Microsoft.AspNetCore.Components;

namespace InfijoToPostfijo.Components.Services
{
    public class Pila
    {
        private char[] pila { get; set; }
        private int longitud { get; set; }
        private int tope { get; set; }

        public Pila(int longitud)
        {
            this.longitud = longitud;
            this.pila = new char[this.longitud];
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

        public bool push(char elemento)
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

        public char pop()
        {
            char element = ' ';
            if (!this.isEmpty())
            {
                element = pila[tope];
                pila[tope] = ' ';
                tope--;
            }

            return element;
        }

        public char getTope()
        {
            return this.pila[tope - 1];
        }
    }
}
