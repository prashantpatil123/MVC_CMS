using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO.ViewModels;
using BO;
using BLL.Services;
using DAL.Repository;

namespace MVC.CMS.Web.Controllers
{
    public class ProductController : Controller 
    {
        // GET: Product
        public ActionResult ProductList()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult CreateProduct(VmProduct objProduct)
        {
            ProductService productService = new ProductService(new ProductRepository());

            int DesignId = productService.InsertUpdateDesign(objProduct);

            if (DesignId > 0)
            {
                ViewBag.Message = "Data Saved Successfully";

                objProduct.design.DesignId = DesignId;
            }

            BindDropDowns();

            return PartialView("_CreateVarient", objProduct);
        }


        [HttpPost]
        public PartialViewResult CreateVarient(VmProduct objProduct)
        {
            //ProductService productService = new ProductService(new ProductRepository());

            int DesignId = 1; //productService.InsertUpdateDesign(ObjVmDesign);

            if (DesignId > 0)
            {
                ViewBag.Message = "Data Saved Successfully";
            }

            return PartialView("_VarientList", objProduct);
        }

        [NonAction]
        public void BindDropDowns()
        {
            List<SelectListItem> objDrdColors = new List<SelectListItem>();
            objDrdColors.Add(new SelectListItem { Value = "1", Text = "Red" });
            objDrdColors.Add(new SelectListItem { Value = "2", Text = "Blue" });
            objDrdColors.Add(new SelectListItem { Value = "3", Text = "Green" });
            ViewBag.Color = new SelectList(objDrdColors, "Value", "Text");

            List<SelectListItem> ObjDrdSizes = new List<SelectListItem>();
            ObjDrdSizes.Add(new SelectListItem { Value = "1", Text = "S" });
            ObjDrdSizes.Add(new SelectListItem { Value = "2", Text = "M" });
            ObjDrdSizes.Add(new SelectListItem { Value = "3", Text = "XL" });
            ViewBag.Size = new SelectList(ObjDrdSizes, "Value", "Text");
        }

    }
}