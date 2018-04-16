using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoja_de_Trabajo_3.TablaSimbolos
{
    public class Tabla
    {
        public Simbolos raiz, ultimo;
        public Tabla() { raiz = ultimo = null; }

        public void insertar(Simbolos nuevo)
        {
            if (raiz == null) { raiz = ultimo = nuevo; }
            else
            {
                ultimo.sig = nuevo;
                nuevo.ant = ultimo;
                ultimo = nuevo;
            }
        }

        public Simbolos buscar(String nombre)
        {
            Simbolos aux = raiz;
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
        public void addValor(Simbolos v)
        {
            Simbolos a = buscar(v.nombre);
            if (a != null)
            {
                a.valor = v.valor;
            }
        }
    }
}
