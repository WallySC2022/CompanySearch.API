using CompanySearch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CompanySearch.Services;
using RestSharp;
using Newtonsoft.Json;

namespace CompanySearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/ConsultarEmpresa/{cnpj}")]
        public string ConsultarEmpresa([FromRoute]string cnpj)
        {
            try
            {
                Company company = ConsultarEmpresaReceitaWS(cnpj);

                var JSON = JsonConvert.SerializeObject(company);
                
                return JSON;
            }
            catch (Exception Exception)
            {
                return Exception.Message;
            }
        }

        [Route("Home/GravarEmpresa/{company}")]
        public string GravarEmpresa(string company)
        {
            Company? CompanyFromJSON;
            CompanyService CompanyService;

            try
            {
                CompanyFromJSON = JsonConvert.DeserializeObject<Company?>(company);

                CompanyService = new CompanyService();
                CompanyService.CriarEmpresa(CompanyFromJSON);

                return "Gravou";
            }
            catch (Exception Exception)
            {
                return Exception.Message;
            }
        }

        public Company ConsultarEmpresaReceitaWS(string cnpj)
        {
            Company Company = null;

            try
            {
                RestClient restClient = new RestClient("https://receitaws.com.br/v1/");
                RestRequest restRequest = new RestRequest(("cnpj/" + cnpj), Method.Get);
                RestResponse response = restClient.ExecuteGetAsync(restRequest).Result;
                string? responsecontent = response.Content;
                dynamic CompanyJSON = JsonConvert.DeserializeObject(responsecontent);

                Company = new Company();
                Company.Nome = CompanyJSON["nome"];
                Company.Uf = CompanyJSON["uf"];
                Company.Email = CompanyJSON["email"];
                Company.Telefone = CompanyJSON["telefone"];
                Company.Situacao = CompanyJSON["situacao"];
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return Company;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}