using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class GrafoDir
    {
        private int max;
        private bool[] mark;
        private bool[] inuse;
        private bool[][] matAdj;

        public void Mark(int n) { mark[n] = true; }
        public void UnMark(int n) { mark[n] = false; }
        public bool isMarked(int n) { return mark[n] == true; }

        /* CRIACAO com capacidade para n nodos */
        public GrafoDir(int n) {

    max = 100;
    if ( n > 0 ) max = n;

    mark = new bool[max];
    inuse = new bool[max];
    matAdj = new bool[max][];
  }

        /* Retorna numero de nodos maximo do grafo */
        public int NumNodos()
        {
            return max;
        }

        /* Retorna numero de nodos em uso */
        public int CapNodos()
        {
            int i, res = 0;
            for (i = 0; i < max; i++)
                if (inuse[i]) res++;
            return res;
        }

        /* Retorna lista de nodos sendo usados no grafo: 0, 1, 2,..., n - 1 */
        public List<int> Nodos()
        {

            List<int> res = new List<int>();

            int i;
            for (i = 0; i < max; i++)
                if (inuse[i])
                    res.Add(i);
            return res;
        }

        /* Retorna numero total de arestas */
        public int NumArestas()
        {
            int i, j, res = 0;
            for (i = 0; i < max; i++)
                for (j = 0; j < max; j++)
                    if (matAdj[i][j] == true) res++;
            return res;
        }

        /* Insere Aresta */
        /* A inserÃ§Ã£o de aresta tambÃ©m cria os nodos se for preciso */
        public void InsereAresta(int orig, int dest)
        {
            if (orig >= 0 && orig < max)
                if (dest >= 0 && dest < max)
                {
                    inuse[orig] = true;
                    inuse[dest] = true;
                    matAdj[orig][dest] = true;
                    return;
                }
            throw new ArgumentException("Insere aresta: Nodo(s) Invalidos(s)");
        }

        /* Remove Aresta */
        public void RemoveAresta(int orig, int dest)
        {
            if (orig >= 0 && orig < max)
                if (dest >= 0 && dest < max)
                {
                    matAdj[orig][dest] = false;
                    return;
                }
            throw new ArgumentException("RemoveAresta: Nodo(s) Invalidos(s)");
        }

        /* Testa se existe aresta */
        public bool ExisteAresta(int orig, int dest)
        {
            if (orig >= 0 && orig < max)
                if (dest >= 0 && dest < max)
                    return matAdj[orig][dest];
            throw new ArgumentException("Existe aresta: Nodo(s) Invalidos(s)");
        }

        /* Desmarca todos os nodos */
        public void DesmarcaNodos()
        {
            foreach (var n in Nodos())
            {
                UnMark(n);
            }
        }

        /* Marca um nodo */
        public void Marca(int n)
        {
            if (n >= 0 && n < max)
            {
                Mark(n);
                return;
            }
            throw new ArgumentException("Marca nodo: Nodo Invalido");
        }

        /* Desenho de grafos, ver http://www.graphviz.org/Gallery.php */
        public void Graphviz()
        {
            Console.WriteLine("digraph G {");
            Console.WriteLine("   rankdir = LR; ");
            Console.WriteLine("   node [shape = circle]; ");
            int i, j;
            for (i = 0; i < max; i++)
                for (j = 0; j < max; j++)
                    if (ExisteAresta(i, j))
                        Console.WriteLine("   " + i + " -> " + j + ";");
            Console.WriteLine("}");
        }

        /* Retorna lista de vizinhos de um nodo */
        public List<int> Vizinhos(int elem)
        {

            List<int> res = new List<int>();

            if (elem < 0 || elem >= max)
                throw new ArgumentException("Nodo Invalido");
            else
            {
                int i;
                for (i = 0; i < max; i++)
                    if (ExisteAresta(elem, i)) res.Add(i);
            }
            return res;
        }

        /* ????????????????????? */
        public void Explore(int u)
        {

            DesmarcaNodos();
            Marca(u);

            List<int> L = new List<int>();
            L.Add(u);

            foreach (var i in L)
            {
                L.Remove(0);

                L.Remove(0);
                Console.WriteLine(i);

                foreach (var v in Vizinhos(i))
                {
                    if (!isMarked(v))
                    {
                        Mark(v);
                        L.Add(v);
                    }
                }
            }
        }
    }
}
