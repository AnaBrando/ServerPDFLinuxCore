using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Domain.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace HTMLtoPDF_Linux.Controllers
{
    public class ProfessorController: Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ProfessorController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index(){
            return null;
        }
        
         
        public string TabelaResposta(RelatorioFinalObjectDTO dTO){
                var tabela = string.Empty;
                    
                    StringBuilder body = new StringBuilder();

                        foreach (var item in dTO.Perguntas)
                        {
                            body.Append("<tr>");
                            body.Append($"<td>{item.Descricao}</td>");
                        }
                        foreach (var item in dTO.Resposta)
                        {
                            body.Append($"<td>{item.Acertou}</td>");
                            body.Append("</tr>");
                        }
                     
                    var retorno = body.ToString();
                    return retorno;
                }
                
        [HttpPost]
         public IActionResult RelatorioProfessor([FromBody]List<RelatorioFinalObjectDTO> dTO){
             StringBuilder stringB = new StringBuilder();
             foreach(var item in dTO){
                       var perguntas = item.Perguntas.ToArray();
            var respostas = item.Resposta.ToArray();
            var porcentagem = ((respostas.Where(x=>x.Acertou).Count() * 100 )/10);
            stringB.Append(@"<html>
                                    <head>
                                    <meta charset='UTF-8'>
                                    <style>
                                        body{width:80%;position:relative;left:10%}
                                        p{font-family: 'Roboto', sans-serif;font-size:2em;text-align:center}
                                        th, td {bz'order: 1px solid black;}
                                    </style>
                                        <link rel='preconnect' href='https://fonts.gstatic.com'>
                                        <link href='https://fonts.googleapis.com/css2?family=Dancing+Script&family=Roboto&display=swap' rel='stylesheet'>
                                    </head>
                                        <body>
                                            <p>Parabéns por finalizar o quizz Web</p>"+
                                            $"<p>{item.NomeAluno}</p>"
                                            +@"<br>
                                            <h5>Rendimento:</h5>
                                            <table border='1' style='width:100%'>
                                                <tr>
                                                    <th>Pergunta</th>                        
                                                    <th>Situacao da Resposta</th>
                                                    <th>Resposta</th>  
                                                    <th>Pontuacao</th>     
                                                    <th>Resposta Certa</th>                          
                                                </tr>
                                                    <tr style='text-align:center;'>"+$"<td>{perguntas[0].Descricao}</td>"+$"<td>{(respostas[0].Acertou == true  ? "Acertou":"Errou")}</td>"+$"<td>{respostas[0].Descricao}</td>"+$"<td>{respostas[0].Valor}</td>"+$"<td>{perguntas[0].OpcaoCerta}</td>"+"</tr>" +
                                                    " <tr style='text-align:center;'>"+$"<td>{perguntas[1].Descricao}</td>"+$"<td>{(respostas[1].Acertou == true  ? "Acertou":"Errou")}</td>"+$"<td>{respostas[1].Descricao}</td>"+$"<td>{respostas[1].Valor}</td>"+$"<td>{perguntas[1].OpcaoCerta}</td>"+"</tr>" +
                                                    " <tr style='text-align:center;'>"+$"<td>{perguntas[2].Descricao}</td>"+$"<td>{(respostas[2].Acertou == true  ? "Acertou":"Errou")}</td>"+$"<td>{respostas[2].Descricao}</td>"+$"<td>{respostas[2].Valor}</td>"+$"<td>{perguntas[2].OpcaoCerta}</td>"+"</tr>" +
                                                    " <tr style='text-align:center;'>"+$"<td>{perguntas[3].Descricao}</td>"+$"<td>{(respostas[3].Acertou == true  ? "Acertou":"Errou")}</td>"+$"<td>{respostas[3].Descricao}</td>"+$"<td>{respostas[3].Valor}</td>"+$"<td>{perguntas[3].OpcaoCerta}</td>"+"</tr>" +
                                                    " <tr style='text-align:center;'>"+$"<td>{perguntas[4].Descricao}</td>"+$"<td>{(respostas[4].Acertou == true  ? "Acertou":"Errou")}</td>"+$"<td>{respostas[4].Descricao}</td>"+$"<td>{respostas[4].Valor}</td>"+$"<td>{perguntas[4].OpcaoCerta}</td>"+"</tr>" +
                                                    " <tr style='text-align:center;'>"+$"<td>{perguntas[5].Descricao}</td>"+$"<td>{(respostas[5].Acertou == true  ? "Acertou":"Errou")}</td>"+$"<td>{respostas[5].Descricao}</td>"+$"<td>{respostas[5].Valor}</td>"+$"<td>{perguntas[5].OpcaoCerta}</td>"+"</tr>" +
                                                    " <tr style='text-align:center;'>"+$"<td>{perguntas[6].Descricao}</td>"+$"<td>{(respostas[6].Acertou == true  ? "Acertou":"Errou")}</td>"+$"<td>{respostas[6].Descricao}</td>"+$"<td>{respostas[6].Valor}</td>"+$"<td>{perguntas[6].OpcaoCerta}</td>"+"</tr>" +
                                                    " <tr style='text-align:center;'>"+$"<td>{perguntas[7].Descricao}</td>"+$"<td>{(respostas[7].Acertou == true  ? "Acertou":"Errou")}</td>"+$"<td>{respostas[7].Descricao}</td>"+$"<td>{respostas[7].Valor}</td>"+$"<td>{perguntas[7].OpcaoCerta}</td>"+"</tr>" +
                                                    " <tr style='text-align:center;'>"+$"<td>{perguntas[8].Descricao}</td>"+$"<td>{(respostas[8].Acertou == true  ? "Acertou":"Errou")}</td>"+$"<td>{respostas[8].Descricao}</td>"+$"<td>{respostas[8].Valor}</td>"+$"<td>{perguntas[8].OpcaoCerta}</td>"+"</tr>" +
                                                     " <tr style='text-align:center;'>"+$"<td>{perguntas[9].Descricao}</td>"+$"<td>{(respostas[9].Acertou == true  ? "Acertou":"Errou")}</td>"+$"<td>{respostas[9].Descricao}</td>"+$"<td>{respostas[9].Valor}</td>"+$"<td>{perguntas[9].OpcaoCerta}</td>"+"</tr>" +
                                                $@"
                                            </table>
                                            <h3>Porcentagem de acerto : {porcentagem} % </h3>
                                        </body>
                                </html>");

 
             }
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
                    //Initialize HTML to PDF converter 
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
                    
            WebKitConverterSettings settings = new WebKitConverterSettings();
            string htmlText = stringB.ToString(); 
            string baseUrl = string.Empty;
           //Set WebKit path
            settings.WebKitPath = Path.Combine(_hostingEnvironment.ContentRootPath, "QtBinariesLinux");
                    
            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;
                    
            //Convert HTML string to PDF
            PdfDocument document = htmlConverter.Convert(htmlText,baseUrl);//"http://www.google.com");
                    
            //Save the document into stream
            MemoryStream stream = new MemoryStream();
                    
            document.Save(stream);
                    
            stream.Position = 0;
                    
            //Close the document
            document.Close(true);
                    
            //Defining the ContentType for pdf file
            string contentType = "application/pdf";
                    
            //Define the file name
            string fileName = "Output.pdf";
                    
            //Creates a FileContentResult object by using the file contents, content type, and file name
            return File(stream, contentType, fileName);
        }
       
    }
}