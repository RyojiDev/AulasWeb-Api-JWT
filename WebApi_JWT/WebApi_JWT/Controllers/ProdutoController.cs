using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_JWT.Models;
using Newtonsoft.Json;
using System.Text;
using JWT.Serializers;
using JWT;
using Nancy.Json;
using JWT.Algorithms;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace WebApi_JWT.Controllers
{
    [Authorize(Policy ="UsuarioAPI")]
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            var lista = new List<Produto>();

            for(int i = 0; i <= 10; i++)
            {
                lista.Add(new Produto { Id = i, NomeProduto = "Nome_produto -" + i.ToString() });
            }
            return Ok(lista);
        }

        [HttpPut]
        [AllowAnonymous]
        public string TesteJwt()
        {
            var header = new Header();

            var paylod = new Payload()
            {
                uuid = "2",
                srcDateTime = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssZ"),
                srcId = 123,
                srcAgencyNumber = "2568",
                srcAccountNumber = "5005565",
                srcClientName = "Ryoji",
                srcCpfCnpj = "885588999555",
                amount = 5058,
                urlConfirm = "http://google.com.br",
                withdrawStatus = "aprovado"
            };


            

            var privateKey = new X509Certificate2("my-key.p12", "password", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet);
            var extraHeaders = new Dictionary<string, object>
            {
                { "partner", 0000 },
                { "versionKey", 1 }
            };


            IJwtAlgorithm algorithm = new RS256Algorithm(privateKey);
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var jsonWebToken = encoder.Encode(extraHeaders, paylod, privateKey.PrivateKey.ToString());

            return jsonWebToken;
        }

 
    [HttpPost]
    [AllowAnonymous]
    public Object FuncaoRetornoJWT(string token)
    {

        try
        {
            var publicKey = new X509Certificate2("my-key.p12", "password");
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

            var json = decoder.Decode(token, publicKey.ToString(), verify: true);

            return json;
        }
        catch (TokenExpiredException)
        {
            Console.WriteLine("Token has expired");
        }
        catch (SignatureVerificationException)
        {
            Console.WriteLine("Token has invalid signature");
        }
        return "";
    }

      
    }

    

}

