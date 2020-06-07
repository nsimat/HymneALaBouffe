using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HymnALaBouffe.Data;
using HymneALaBouffe.CoreBusiness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HymneALaBouffe.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [TempData]
        public String Message { get; set; }
        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }                
            return Page();
        }
    }
}