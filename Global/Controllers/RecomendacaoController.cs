using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace Global.Controllers
{

    public class DadosConsumo
    {
        [LoadColumn(0)] public string data_medida { get; set; }
        [LoadColumn(1)] public float valor_corrente { get; set; }
        [LoadColumn(2)] public float valor_tensao { get; set; }
        [LoadColumn(3)] public float valor_consumo { get; set; }
        [LoadColumn(4)] public float Label { get; set; }
    }

    public class PredicaoConsumo
    {
        [ColumnName("Score")]
        public float PontuacaoPredicao { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloConsumo.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "dados_consumo.csv");
        private readonly MLContext mlContext;

        public ConsumoController()
        {
            mlContext = new MLContext();

            if (!System.IO.File.Exists(caminhoModelo))
            {
                Console.WriteLine("Modelo não encontrado. Iniciando treinamento...");
                TreinarModelo();
            }
        }

        // Método para prever o consumo com base na corrente e tensão
        [HttpGet("prever/{valor_corrente}/{valor_tensao}")]
        public IActionResult Prever(float valor_corrente, float valor_tensao)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("O modelo ainda não foi treinado.");
            }

            ITransformer modelo;
            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                modelo = mlContext.Model.Load(stream, out var modeloSchema);
            }

            var enginePredicao = mlContext.Model.CreatePredictionEngine<DadosConsumo, PredicaoConsumo>(modelo);

            var predicao = enginePredicao.Predict(new DadosConsumo
            {
                valor_corrente = valor_corrente,
                valor_tensao = valor_tensao
            });

            return Ok(new
            {
                valor_corrente,
                valor_tensao,
                consumo_previsto = predicao.PontuacaoPredicao
            });
        }

        private void TreinarModelo()
        {
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
                Console.WriteLine($"Diretório criado: {pastaModelo}");
            }

            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<DadosConsumo>(
                path: caminhoTreinamento, hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(DadosConsumo.valor_consumo))
                .Append(mlContext.Transforms.Concatenate("Features", nameof(DadosConsumo.valor_corrente), nameof(DadosConsumo.valor_tensao)))
                .Append(mlContext.Regression.Trainers.FastTree());

            var modelo = pipeline.Fit(dadosTreinamento);

            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
            Console.WriteLine($"Modelo treinado e salvo em: {caminhoModelo}");
        }
    }
}
