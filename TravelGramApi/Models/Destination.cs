using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace TravelGramApi;

public class Destination
{
    public int DestinationId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public virtual joinDestinationReview joinDestinationReview { get; set; }
}