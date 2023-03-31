using Microsoft.AspNetCore.Mvc.Rendering;
using CoreMVCUyg.Data;
using CoreMVCUyg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCUyg.Helper
{
    public class Dropdown {

        private readonly ApplicationDbContext _context;

        public Dropdown(ApplicationDbContext context)
        {
            _context = context;

        }
        //ürün ana kategori
        public  List<SelectListItem> ProductMainCategoryDropDown()
        {
          

                List<ProductMainCategory> productMainCategoryList = _context.ProductMainCategory.ToList();
                List<SelectListItem> list = (from x in productMainCategoryList
											 select new SelectListItem
                                             {
                                                 Text = x.ProductMainCategoryName,
                                                 Value = x.ProductMainCategoryId.ToString()
                                             }).ToList();
                list.Insert(0, new SelectListItem { Value = "NULL", Text = "SEÇİNİZ..", Selected = true });
                return list;
            

        }

        //ürün alt kategori
        public  List<SelectListItem> productSubCategoryDropDown()
        {
            
                List<ProductSubCategory> productSubCategoryList = _context.ProductSubCategory.ToList();
                List<SelectListItem> list = (from x in productSubCategoryList
											 select new SelectListItem
                                             {
                                                 Text = x.ProductSubCategoryName,
                                                 Value = x.ProductSubCategoryId.ToString()
                                             }).ToList();
                list.Insert(0, new SelectListItem { Value = "NULL", Text = "SEÇİNİZ..", Selected = true });
                return list;

            
        }
        //ürün alt kategori "parametre id"
        public  List<SelectListItem> productSubCategoryDropDown(int id)
        {
           
                List<ProductSubCategory> productSubCategoryList = _context.ProductSubCategory.Where(x => x.ProductMainCategoryId == id).ToList();
                List<SelectListItem> list = (from x in productSubCategoryList
											 select new SelectListItem
                                             {
                                                 Text = x.ProductSubCategoryName,
                                                 Value = x.ProductSubCategoryId.ToString()
                                             }).ToList();
                list.Insert(0, new SelectListItem { Value = "NULL", Text = "SEÇİNİZ..", Selected = true });
                return list;
            


        }

        //ürün kategori
        public  List<SelectListItem> productCategoryDropDown()
        {
            
                List<ProductCategory> productCategoryList = _context.ProductCategory.ToList();
                List<SelectListItem> list = (from x in productCategoryList
											 select new SelectListItem
                                             {
                                                 Text = x.ProductCategoryName,
                                                 Value = x.ProductCategoryId.ToString()
                                             }).ToList();
                list.Insert(0, new SelectListItem { Value = "NULL", Text = "SEÇİNİZ..", Selected = true });
                return list;
            

        }

        //ürün kategori "parametre id"
        public  List<SelectListItem> productCategoryDropDown(int id)
        {
            

                List<ProductCategory> productCategoryList = _context.ProductCategory.Where(x => x.ProductSubCategoryId == id).ToList();
                List<SelectListItem> list = (from x in productCategoryList
											 select new SelectListItem
                                             {
                                                 Text = x.ProductCategoryName,
                                                 Value = x.ProductCategoryId.ToString()
                                             }).ToList();
                list.Insert(0, new SelectListItem { Value = "NULL", Text = "SEÇİNİZ..", Selected = true });
                return list;
            

        }
    }
    }

