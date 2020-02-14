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
        public string TesteJwet()
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



           // var secret = "Secret_key-12345678";

            var headerEmJson = JsonConvert.SerializeObject(header);

            var payloadEmJson = JsonConvert.SerializeObject(paylod);

           // var secretEmJson = JsonConvert.SerializeObject(secret);

           
            var plainTextBytes = Encoding.UTF8.GetBytes(headerEmJson);
            var plainTextBytesP = Encoding.UTF8.GetBytes(payloadEmJson);
            //var plainTextBytesS = Encoding.UTF8.GetBytes(secretEmJson);


            var base64H = Convert.ToBase64String(plainTextBytes);
            var base64P = Convert.ToBase64String(plainTextBytesP);
         //   var base64S = Convert.ToBase64String(plainTextBytesS);

            var base64 = base64H + "." + base64P;

            var tokenjwt = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjbGFpbTEiOjAsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.8pwBI_HtXqI3UgQHQ_rDRnSQRxFL1SR8fbQoS-5kM5s";

            string Decode(string jwt)
            {


                /*
                var array = jwt.Split('.');

               

                var base64EncodedBytesH = Convert.FromBase64String(array[0]);

                var base64EncodedBytesP = Convert.FromBase64String(array[1]);

                var jsonHeader = Encoding.UTF8.GetString(base64EncodedBytesH);

                var jsonPayload = Encoding.UTF8.GetString(base64EncodedBytesP);

               // var json = "{\"jwt\": [" + jsonHeader + " , " + jsonPayload + "]}";


                JavaScriptSerializer serializador = new JavaScriptSerializer();

                var json= serializador.Serialize(jsonPayload);

                var jsonobj = JsonConvert.DeserializeObject(json);

                

                return json;


            }

            //plainTextBytes = Convert.FromBase64String(base64);



            // var base64EncodedBytes = Convert.FromBase64String(jwt);

            //var base64EncodedBytes = Convert.FromBase64String(jwt);

            var zero = 0;

            //Console.WriteLine(Encoding.UTF8.GetString(base64EncodedBytes));*/


                 string token = jwt;
            const string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);

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

            // var json = decoder.Decode(base64, secret, verify: true);
            // Console.WriteLine(json);

            //return basejson;

           return Decode(tokenjwt);
        }
    }
}