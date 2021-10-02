using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Compis_1201619
{
    public class Scanner
    {
        private string _Operacion = "";
        private int _index = 0;
        private int _state = 0;

        public Scanner(String Operacion)
        {
            _Operacion = Operacion + (char)TokenType.EOF;
            _index = 0;
            _state = 0;
        }

        public Token GetToken()
        {
            Token resultado = new Token() { Value = (char)0 };
            bool tokenEncontrado = false;
            while (!tokenEncontrado)
            {
                char peek = _Operacion[_index];
                switch (_state)
                {
                    case 0:
                        while (char.IsWhiteSpace(peek))
                        {
                            _index++;
                            peek = _Operacion[_index];
                        }
                        if (peek =='\\')
                        {
                            _state = 1;
                        }
                        else
                        {
                            switch (peek)
                            {
                                case (char)TokenType.LParen:
                                case (char)TokenType.RParen:
                                case (char)TokenType.Multi:
                                case (char)TokenType.Div:
                                case (char)TokenType.Mas:
                                case (char)TokenType.Menos:
                                //case (char)TokenType.entero:
                                case (char)TokenType.EOF:
                                    tokenEncontrado = true;
                                    resultado.Tag = (TokenType)peek;
                                    break;
                                
                                default:
                                    tokenEncontrado = true;
                                    resultado.Tag = TokenType.Entero;
                                    resultado.Value = peek;
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
                
                _index++;

            }

            _state = 0;
            return resultado;
        }
    }
}
