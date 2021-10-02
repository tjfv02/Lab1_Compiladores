using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Compis_1201619
{
    public enum TokenType
    {
        LParen = '(',
        RParen = ')',
        Multi = '*',
        Div = '/',
        Mas = '+',
        Menos = '-',
        EOF = (char)0,
        Entero = (char)1,
        Vacio = (char)2
    }
}
