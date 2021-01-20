﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace GeoEspacial.Models
{
    class Airport
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> loc { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string code { get; set; }
    }
}