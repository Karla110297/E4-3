using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Grafos Grafo = new Grafos();

            Grafo.CrearVertices(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' });//se crean  vertices

            Grafo.AgregarLink('a', new char[] { 'a', 'b' });//Se agregan links a cada uno de los vertices
            Grafo.AgregarLink('b', new char[] { 'a', 'c', 'g' });
            Grafo.AgregarLink('c', new char[] { 'b', 'g', 'd' });
            Grafo.AgregarLink('d', new char[] { 'c', 'e', 'f' });
            Grafo.AgregarLink('e', new char[] { 'd', 'f' });
            Grafo.AgregarLink('f', new char[] { 'g', 'd', 'e' });
            Grafo.AgregarLink('g', new char[] { 'b', 'c', 'f' });
            Grafo.ImprimirUniones();//Imprimimos uniones
            Grafo.Recorridos();//imprime recorridos
            Console.ReadKey();

        }
    }
}
