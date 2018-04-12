using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public  class ListVar
    {
        public NodoVar raiz, ultimo;
        public ListVar() { raiz = ultimo = null; }

        public void insertar(NodoVar nuevo)
        {
            if (raiz == null) { raiz = ultimo = nuevo; }
            else
            {
                ultimo.sig = nuevo;
                nuevo.ant = ultimo;
                ultimo = nuevo;
            }
        }

        public NodoVar buscar(String nombre)
        {
            NodoVar aux = raiz;
            while (aux != null)
            {
                if (aux.nombre.Equals(nombre))
                {
                    return aux;
                }
                aux = aux.sig;
            }
            return null;
        }
        public void addValor(NodoVar v)
        {
            NodoVar a = buscar(v.nombre);
            if (a != null)
            {
                a.valor = v.valor;
            }
        }
    }
}
