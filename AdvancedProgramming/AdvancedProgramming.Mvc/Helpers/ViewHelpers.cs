using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace AdvancedProgramming.Mvc.Helpers
{
    public static class ViewHelpers
    {
        public static HtmlString StarRating(decimal? rating)
        {
            double ratingValue = rating.HasValue ? (double)rating.Value : 0;

            int fullStars = (int)Math.Floor(ratingValue);
            int halfStar = (ratingValue - fullStars) >= 0.5 ? 1 : 0;
            int emptyStars = 5 - fullStars - halfStar;

            var stars = new StringBuilder();
            for (int i = 0; i < fullStars; i++) stars.Append("<span class='fa fa-star checked'></span>");
            if (halfStar == 1) stars.Append("<span class='fa fa-star-half-o checked'></span>");
            for (int i = 0; i < emptyStars; i++) stars.Append("<span class='fa fa-star-o'></span>");

            return new HtmlString(stars.ToString());
        }

    }
}