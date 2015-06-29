using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            GrafoDir G = new GrafoDir( 50 );

            Console.is

    while ( input.hasNext() ) {
      int i = input.nextInt();
      int j = input.nextInt();
      if ( i == 0 && j == 0 ) break;
      G.InsereAresta( i, j );
    }

    G.Graphviz( );
//  G.Explore( 2 );
        }
    }
}
