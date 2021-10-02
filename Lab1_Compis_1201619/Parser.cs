using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Compis_1201619
{
    class Parser
    {
        Scanner _scanner;
        Token _token;

        //metodos por gramatica
        private double E()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Menos:
                case TokenType.Entero:

                    return T() + EP();
                    break;
                default:
                    return 0;
                    break;
            }
        }

        private double EP()
        {
            switch (_token.Tag)
            {
                case TokenType.Mas:
                    Match(TokenType.Mas);

                    return T() + EP();
                    break;
                case TokenType.Menos:
                    Match(TokenType.Menos);

                    return -T() + EP();
                    break;
                default:
                    return 0;
                    break;
            }
        }

        private double T()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Menos:
                case TokenType.Entero:

                    return F() * TP();
                    break;
                default:
                    return 1;
                    break;
            }
        }

        private double TP()
        {
            switch (_token.Tag)
            {
                case TokenType.Multi:
                    Match(TokenType.Multi);

                    return TP() * F();
                    break;
                case TokenType.Div:
                    Match(TokenType.Div);

                    return 1 / F() * TP();
                    break;
                default:
                    return 1;
                    break;
            }
        }

        private double F()
        {
            string acum;
            switch (_token.Tag)
            {
                case TokenType.LParen:
                    Match(TokenType.LParen);
                    double temp = E();
                    Match(TokenType.RParen);
                    return temp;
                    break;
                case TokenType.Menos:
                    Match(TokenType.Menos);
                    //F();
                    return -F();
                    break;
                case TokenType.Entero:
                    return FP();
                    break;
                default:
                    return 0;
                    break;
            }
        }

       
        private double FP()
        {
            switch (_token.Tag)
            {
                case TokenType.Entero:
                    string acumulador = "";
                    acumulador = acumulador + Convert.ToString(_token.Value);
                    return Convert.ToDouble(acumulador);
                    break;
                
                default:
                    return 0;
                    break;
            }
        }

        private void Match(TokenType tag)    
        {
            if (_token.Tag == tag)
            {
                _token = _scanner.GetToken();
            }
            else
            {
                throw new Exception("Error de Sintaxis");
            }
        }

         public double Parse(string operacion)
        {
            _scanner = new Scanner(operacion + (char)TokenType.EOF);
            _token = _scanner.GetToken();

            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Menos:
                case TokenType.Entero:
                    return E();
            }
            Match(TokenType.EOF);
            return 0;
        }
    }
}
