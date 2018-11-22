using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4_3
{
    class Grafos
    {

        char[] vertices;//Aqui estaran los puntos
        bool[,] links;//Aqui las conexiones entre puntos

        public void CrearVertices(char[] arreglo)//Crea vertices
        {
            vertices = arreglo;
            links = new bool[arreglo.Length, arreglo.Length];
        }

        public void AgregarLink(char vertice, char[] link)//Agrega links a vertices
        {
            int x = Array.IndexOf(vertices, vertice);
            for (int i = 0; i < link.Length; i++)
            {
                links[x, Array.IndexOf(vertices, link[i])] = true;
            }
        }

        public void Recorridos()//metodo recursivo de recorridos
        {
            string puntos = "";
            for (int i = 0; i < vertices.Length; i++)
            {
                ImprimirUniones();
                Caminos(i, puntos, links);
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void ImprimirUniones()//Imprime  tabla 
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                Console.SetCursorPosition((i * 7) + 5, 0);
                Console.Write(vertices[i]);
            }

            for (int i = 0; i < vertices.Length; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write(vertices[i]);
            }

            for (int i = 0; i < vertices.Length; i++)
            {
                for (int o = 0; o < vertices.Length; o++)
                {
                    Console.SetCursorPosition((i * 7) + 3, o + 1);
                    Console.Write(links[i, o]);
                }
            }
            Console.SetCursorPosition(0, vertices.Length + 2);
        }
        private void Caminos(int vertice, string puntosRecorridos, bool[,] relaciones)
        {
            bool relacion = false;
            bool[,] temporal;//variable temporal
            puntosRecorridos = puntosRecorridos + " >>> " + vertices[vertice];
            for (int i = 0; i < vertices.Length; i++)
            {//Pasa por los recorridos de grafos
                if (relaciones[vertice, i] == true)//Si hay una relacion
                {
                    temporal = relaciones;//Se copia la tabla
                    relacion = true;//Se indica que existe una relacion
                    for (int o = 0; o < vertices.Length; o++)//modificacion 
                    {
                        temporal[o, vertice] = false;
                        temporal[o, i] = false;
                    }
                    Caminos(i, puntosRecorridos, temporal);
                }
            }
            if (!relacion)//Se imprime si ya no hay ningun camino a recorrer
            {
                Console.WriteLine(puntosRecorridos);
            }
        }
    }
}
