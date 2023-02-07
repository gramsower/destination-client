using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace TravelClient.Models
{
  public class Destination
  {
    public int DestinationId { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Review { get; set; }
    public double Rating { get; set; }
  

    public static List<Destination> GetDestinations()
    {
    Task<string> apiCallTask = ApiHelper.GetAll();
    string result = apiCallTask.Result;

    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    List<Destination> destinationList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());

    return destinationList;
    }

    public static Destination GetDetails(int id)
    {
      Task<string> apiCallTask = ApiHelper.Get(id);
      string result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Destination destination = JsonConvert.DeserializeObject<Destination>(jsonResponse.ToString());

      return destination;
    }

    public static void Post(Destination destination)
    {
      string jsonDestination = JsonConvert.SerializeObject(destination);
      ApiHelper.Post(jsonDestination);
    }

    public static void Put(Destination destination)
    {
      string jsonDestination = JsonConvert.SerializeObject(destination);
      ApiHelper.Put(destination.DestinationId, jsonDestination);
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }
  } 
}