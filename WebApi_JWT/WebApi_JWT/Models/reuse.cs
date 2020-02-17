using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_JWT.Models
{
    public class reuse
    {

    }

    /* public string DecodeJsonWebToken(string hashJsonWebToken)
     {
         try
         {
             var array = hashJsonWebToken.Split('.');
             var base64EncodedBytesH = Convert.FromBase64String(array[0]);
             var base64EncodedBytesP = Convert.FromBase64String(array[1]);

             var jsonHeader = Encoding.UTF8.GetString(base64EncodedBytesH);
             var jsonPayload = Encoding.UTF8.GetString(base64EncodedBytesP);
             var json = jsonHeader + " - " + jsonPayload;

             return json;
         }
         catch (Exception ex)
         {
             throw ex;
         }
     }*/



    // CONVERTER PARA BASE 64 JWT HARD CODE

    /*
              var secret = "Secret_key-12345678";

             var headerEmJson = JsonConvert.SerializeObject(header);

             var payloadEmJson = JsonConvert.SerializeObject(paylod);

             var secretEmJson = JsonConvert.SerializeObject(secret);


             var plainTextBytes = Encoding.UTF8.GetBytes(headerEmJson);
            var plainTextBytesP = Encoding.UTF8.GetBytes(payloadEmJson);
            var plainTextBytesS = Encoding.UTF8.GetBytes(secretEmJson);


             var base64H = Convert.ToBase64String(plainTextBytes);
             var base64P = Convert.ToBase64String(plainTextBytesP);
              var base64S = Convert.ToBase64String(plainTextBytesS);

             var base64 = base64H + "." + base64P;



      //  return jsonWebToken;
        // var tokenjwt = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjbGFpbTEiOjAsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.8pwBI_HtXqI3UgQHQ_rDRnSQRxFL1SR8fbQoS-5kM5s";

        /* string Decode(string jwt)
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


   // string jwt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsInBhcnRuZXIiOiIwMTI0IiwidmVyc2lvbktleSI6IjEifQ.eyJjcGZDbnBqIjoiMTEyODQ3NDMwMDAxNTciLCJkYXRlVGltZVJlcXVlc3QiOiIyMDE5LTA1LTEwVDE1OjAxOjU1IiwiYW1vdW50IjoxMDAwMCwiYWRkaXRpb25hbEF1dGhlbnRpY2F0aW9uRGF0YSI6IjgyOTg2NSIsInV1aWQiOiI2NWMzODNiOS1lYTFhLTRiYjQtYmEyMi03MTlkODgzYmMxZWYiLCJyZWZlcmVuY2VEYXRlVHJhbnMiOiIyMDE5LTA1LTEzIn0.k4cxzSVySwS9LJ7cENchAwHAMFJ3szn6cvxzfSaRf-0";

    //   DecodeWebToken(jwt);
    /*
      public  string DecodeWebToken( string jwt) { 
            string token = jwt;
            string secret = "secrettt23";

       try
       {
       var publicKey = new X509Certificate2("my-key.p12", "password");
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
           return "";
       }
       */

}
