﻿//                      Projeto: Motor Tributario                                                  
//          Biblioteca C# para Cálculos Tributários Do Brasil
//                    NF-e, NFC-e, CT-e, SAT-Fiscal     
//                                                                                                                                           
//  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la 
// sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  
// Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) 
// qualquer versão posterior.                                                   
//                                                                              
//  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   
// NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      
// ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor
// do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              
//                                                                              
//  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto
// com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  
// no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          
// Você também pode obter uma copia da licença em:                              
// https://github.com/AutomacaoNet/MotorTributarioNet/blob/master/LICENSE      

using System;

namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoDifal : IResultadoCalculoDifal
    {
        public decimal BaseCalculo { get; }
        public decimal Fcp { get; }
        public decimal ValorIcmsDestino { get; }
        public decimal ValorIcmsOrigem { get; }
        public decimal Difal { get; }

        public ResultadoCalculoDifal(decimal baseCalculo, decimal difal, decimal fcp, decimal valorIcmsDestino, decimal valorIcmsOrigem)
        {
            BaseCalculo = Math.Round(baseCalculo, 2);
            Difal = Math.Round(difal, 2);
            Fcp = Math.Round(fcp, 2);
            ValorIcmsDestino = Math.Round(valorIcmsDestino, 2);
            ValorIcmsOrigem = Math.Round(valorIcmsOrigem, 2);
        }

        public string GetObservacao(IDadosMensagemDifal dadosMensagemDifal)
        {
            return MontaMensagemDifal(dadosMensagemDifal);
        }

        public static string GetObservacaoDifal(IDadosMensagemDifal dadosMensagemDifal)
        {
            return MontaMensagemDifal(dadosMensagemDifal);
        }

        private static string MontaMensagemDifal(IDadosMensagemDifal dadosMensagemDifal)
        {
            return $"Valores totais do ICMS interstadual: DIFAL da UF destino {dadosMensagemDifal.ValorIcmsDestino} + FCP {dadosMensagemDifal.Fcp}; DIFAL da UF Origem {dadosMensagemDifal.ValorIcmsOrigem}";
        }
    }
}