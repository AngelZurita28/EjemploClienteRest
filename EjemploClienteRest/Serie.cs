using System.Runtime.Serialization;

namespace EjemploClienteRest
{
    [DataContract]
    class Serie
    {
        [DataMember(Name = "titulo")]
        public string Title { get; set; }

        [DataMember(Name = "idSerie")]
        public string IdSerie { get; set; }

        [DataMember(Name = "datos")]
        public DataSerie[] Data { get; set; }

    }

    [DataContract]
    class DataSerie
    {
        [DataMember(Name = "fecha")]
        public string Date { get; set; }

        [DataMember(Name = "dato")]
        public string Data { get; set; }
    }

    [DataContract]
    class SeriesResponse
    {
        [DataMember(Name = "series")]
        public Serie[] series { get; set; }
    }

    [DataContract]
    class Response
    {
        [DataMember(Name = "bmx")]
        public SeriesResponse seriesResponse { get; set; }
    }
}