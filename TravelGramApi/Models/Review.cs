using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace TravelGramApi.models
{
    public class Review
    {
      public int ReviewId { get; set; }
      public string Score { get; set; }
      public string Author { get; set; }
      public string Tagline { get; set; }
      public string Body { get; set; }
      public virtual joinDestinationReview joinDestinationReview { get; set; }
    }  
}