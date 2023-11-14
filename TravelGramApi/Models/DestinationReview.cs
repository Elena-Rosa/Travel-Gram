using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace TravelGramApi.Models
{
  public class DestinationReview
  {
    public int DestinationReviewId { get; set; }
    public int DestinationId { get; set; }
    public int ReviewId { get; set; }
    public Destination Destination { get; set; }
    public List<joinDestinationReview> JoinEntities { get; }
    public Review Review { get; set; }
  }  
}