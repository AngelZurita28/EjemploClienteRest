using System;
using System.Net;
using System.Runtime.Serialization.Json;

namespace EjemploClienteRest
{
    class Program
    {
        public static Response ReadSerie()
        {
            try
            {
                string url = "https://www.banxico.org.mx/SieAPIRest/service/v1/series/SF43718/datos/2023-01-31/2023-01-31";
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Accept = "application/json";
                request.Headers["Bmx-Token"] = "69260904c3e398685c78e54928e7129fb21c7f79443e3c8b59e5c91f8319ef47";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                Response jsonResponse = objResponse as Response;
                return jsonResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        static void Main(string[] args)
        {
            Response response = ReadSerie();
            Serie serie = response.seriesResponse.series[0];
            Console.WriteLine("Serie: {0}", serie.Title);
            foreach (DataSerie dataSerie in serie.Data)
            {
                if (dataSerie.Data.Equals("N/E")) continue;
                Console.WriteLine("Fecha: {0}", dataSerie.Date);
                Console.WriteLine("Dato: {0}", dataSerie.Data);
            }
            Console.ReadLine();
        }
    }
}