using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace PocTest.StepDefinitions
{
    [Binding]
    public class CalculosStepDefinitions
    {
        public int Numero1 { get; set; }
        public int Numero2 { get; set; }
        public int Resultado { get; set; }

        [Given(@"Que tenho dois numeros, sendo eles o numero ""([^""]*)"" e o número ""([^""]*)""")]
        public void GivenQueTenhoDoisNumerosSendoElesONumeroEONumero(string numero1, string numero2)
        {
            Numero1 = int.Parse(numero1);
            Numero2 = int.Parse(numero2);
        }

        [When(@"somado os dois números")]
        public void WhenSomadoOsDoisNumeros()
        {
            Resultado = Numero1 + Numero2;
        }

        [Then(@"então a soma deles deve ser ""([^""]*)""")]
        public void ThenEntaoASomaDelesDeveSer(string resultado)
        {
            Assert.AreEqual(int.Parse(resultado), Resultado);
        }
    }
}