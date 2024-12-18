﻿using TestCalculosTributarios.Entidade;
using MotorTributarioNet.Impostos.Csts;
using MotorTributarioNet.Flags;
using Xunit;

namespace TestCalculosTributarios.Cst
{
    public class Cst70Test
    {
        [Fact]
        public void CalculoCst70()
        {
            var produto = new Produto
            {
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualReducao = 10.00m,
                PercentualReducaoSt = 10.00m,
                ValorProduto = 100.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 100.00m
            };

            var cst = new Cst70();
            cst.Calcula(produto);
            Assert.Equal(ModalidadeDeterminacaoBcIcms.ValorOperacao, cst.ModalidadeDeterminacaoBcIcms);
            Assert.Equal(10.00m, cst.PercentualReducao);
            Assert.Equal(90.00m, cst.ValorBcIcms);
            Assert.Equal(18.00m, cst.PercentualIcms);
            Assert.Equal(16.20m, cst.ValorIcms);
            Assert.Equal(ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado, cst.ModalidadeDeterminacaoBcIcmsSt);
            Assert.Equal(100.00m, cst.PercentualMva);
            Assert.Equal(10.00m, cst.PercentualReducaoSt);
            Assert.Equal(180.00m, cst.ValorBcIcmsSt);
            Assert.Equal(18.00m, cst.PercentualIcmsSt);
            Assert.Equal(16.20m, cst.ValorIcmsSt);
        }

        [Fact]
        public void CalculoCst70_DescontoCondicional()
        {
            var produto = new Produto
            {
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualReducao = 10.00m,
                PercentualReducaoSt = 10.00m,
                ValorProduto = 80.00m,
                Desconto = 20.00m,
                QuantidadeProduto = 1.000m,
                PercentualMva = 40.00m
            };

            var cst = new Cst70(tipoDesconto: TipoDesconto.Condincional);
            cst.Calcula(produto);
            Assert.Equal(ModalidadeDeterminacaoBcIcms.ValorOperacao, cst.ModalidadeDeterminacaoBcIcms);
            Assert.Equal(10.00m, cst.PercentualReducao);
            Assert.Equal(90.00m, cst.ValorBcIcms);
            Assert.Equal(18.00m, cst.PercentualIcms);
            Assert.Equal(16.20m, cst.ValorIcms);
            Assert.Equal(ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado, cst.ModalidadeDeterminacaoBcIcmsSt);
            Assert.Equal(40.00m, cst.PercentualMva);
            Assert.Equal(18.00m, cst.PercentualIcmsSt);
            Assert.Equal(10.00m, cst.PercentualReducaoSt);
            Assert.Equal(126.00m, cst.ValorBcIcmsSt);
            Assert.Equal(6.48m, cst.ValorIcmsSt);
        }

        [Fact]
        public void CalculoCst70_ValoresSeparados()
        {
            var produto = new Produto
            {
                QuantidadeProduto = 1.000m,
                ValorProduto = 80.00m,
                Frete = 5.00m,
                Seguro = 2.00m,
                OutrasDespesas = 3.00m,
                Desconto = 20.00m,
                PercentualIpi = 5.00m,
                PercentualIcms = 18.00m,
                PercentualIcmsSt = 18.00m,
                PercentualReducao = 61.11m,
                PercentualReducaoSt = 61.11m,
                PercentualMva = 52.90m
            };

            var cst = new Cst70();
            cst.Calcula(produto);
            Assert.Equal(ModalidadeDeterminacaoBcIcms.ValorOperacao, cst.ModalidadeDeterminacaoBcIcms);
            Assert.Equal(18.00m, cst.PercentualIcms);
            Assert.Equal(61.11m, cst.PercentualReducao);
            Assert.Equal(27.22m, cst.ValorBcIcms);
            Assert.Equal(4.90m, cst.ValorIcms);
            Assert.Equal(ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado, cst.ModalidadeDeterminacaoBcIcmsSt);
            Assert.Equal(18.00m, cst.PercentualIcmsSt);
            Assert.Equal(61.11m, cst.PercentualReducaoSt);
            Assert.Equal(52.90m, cst.PercentualMva);
            Assert.Equal(43.71m, cst.ValorBcIcmsSt);
            Assert.Equal(2.97m, cst.ValorIcmsSt);
        }
    }
}