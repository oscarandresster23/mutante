using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mutante.Modelos;

namespace Mutante.Funciones
{
    public class dnaUtils    {
        public bool isDnaValid(string[] dna)
        {
            int filas;
            filas = dna.Length;
            foreach (string cadena in dna)
            {
                if (cadena.Length != filas)
                {
                    return false;
                }
            }
            if (filas < 4)
            {
                return false;
            }
            return true;
        }


        public bool isMutant(string[] adn)
        {
            short coincidencias = 0;
            coincidencias = verticalVerify(adn, coincidencias);
            coincidencias = horizontalVerify(adn, coincidencias);
            coincidencias = diagonal1Verify(adn, coincidencias);
            coincidencias = diagonal2Verify(adn, coincidencias);
            return (coincidencias > 1);
        }


        private short verticalVerify(string[] adn, short coincidencias)
        {
            char charA, charB, charC, charD;
            for (int i = 0; i < adn.Length; i++)
            {
                for (int j = 0; j < adn.Length - 3; j++)
                {
                    charA = char.Parse(adn[j].Substring(i, 1));
                    charB = char.Parse(adn[j + 1].Substring(i, 1));
                    charC = char.Parse(adn[j + 2].Substring(i, 1));
                    charD = char.Parse(adn[j + 3].Substring(i, 1));
                    if (charCompare(charA, charB, charC, charD))
                    {
                        coincidencias++;
                    }
                }
            }
            return coincidencias;
        }

        private short horizontalVerify(string[] adn, short coincidencias)
        {
            char charA, charB, charC, charD;
            foreach (string cadena in adn)
            {
                for (int i = 0; i < cadena.Length - 3; i++)
                {
                    charA = char.Parse(cadena.Substring(i, 1));
                    charB = char.Parse(cadena.Substring(i + 1, 1));
                    charC = char.Parse(cadena.Substring(i + 2, 1));
                    charD = char.Parse(cadena.Substring(i + 3, 1));
                    if (charCompare(charA, charB, charC, charD))
                    {
                        coincidencias++;

                    }
                }
            }
            return coincidencias;
        }

        private short diagonal1Verify(string[] adn, short coincidencias)
        {
            char charA, charB, charC, charD;

            for (int i = 0; i < adn.Length - 3; i++)
            {
                for (int j = 0; j < adn.Length - 3; j++)
                {
                    charA = char.Parse(adn[j].Substring(i, 1));
                    charB = char.Parse(adn[j + 1].Substring(i + 1, 1));
                    charC = char.Parse(adn[j + 2].Substring(i + 2, 1));
                    charD = char.Parse(adn[j + 3].Substring(i + 3, 1));
                    if (charCompare(charA, charB, charC, charD))
                    {
                        coincidencias++;
                    }
                }
            }
            return coincidencias;
        }

        private short diagonal2Verify(string[] adn, short coincidencias)
        {
            char charA, charB, charC, charD;

            for (int i = adn.Length - 1; i > 3; i--)
            {
                for (int j = 0; j < adn.Length - 3; j++)
                {
                    charA = char.Parse(adn[i].Substring(j, 1));
                    charB = char.Parse(adn[i - 1].Substring(j + 1, 1));
                    charC = char.Parse(adn[i - 2].Substring(j + 2, 1));
                    charD = char.Parse(adn[i - 3].Substring(j + 3, 1));
                    if (charCompare(charA, charB, charC, charD))
                    {
                        coincidencias++;
                    }
                }
            }
            return coincidencias;
        }

        private bool charCompare(char charA, char charB, char charC, char charD)
        {
            return (charA == charB && charB == charC && charC == charD);
        }

    }
}
