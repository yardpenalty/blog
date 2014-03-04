using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.ViewModels
{
    public class IceCreamFlavor
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    //RAZOR VIEWMODEL
//    @Html.LabelFor(m=>m.SelectedFlavorId)
//@Html.DropDownListFor(m => m.SelectedFlavorId, Model.FlavorItems)
//@Html.ValidationMessageFor(m=>m.SelectedFlavorId)
//<input type="submit" value="Submit" />      
    public class SelectListViewModel
    {
        private readonly List<IceCreamFlavor> _flavors;

        [Display(Name = "Favorite Flavor")]
        public int SelectedFlavorId { get; set; }

        //public IEnumerable<SelectListItem> FlavorItems
        //{
        //    get { return new SelectList(_flavors, "Id", "Name"); }
        //}
    
    

        public IEnumerable<SelectListItem> FlavorItems
        {
            get
            {
                var allFlavors = _flavors.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Name
                });
                return DefaultFlavorItem.Concat(allFlavors);
            }
        }

        public IEnumerable<SelectListItem> DefaultFlavorItem
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select a flavor"
                }, count: 1);
            }
        }
    }
}