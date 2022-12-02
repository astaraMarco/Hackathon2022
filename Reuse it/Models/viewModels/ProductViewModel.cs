﻿using Reuse_it.Enumerations;
using Reuse_it.Models.images;
using System.Data;

namespace Reuse_it.Models.viewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public string? descrizione { get; set; }
        public Size size { get; set; }
        public Usury usura { get; set; }
        public image foto { get; set; }

        
        public decimal? priceBuy { get; set; }
        public decimal? priceRent { get; set; }

        public static ProductViewModel mapRowSell(DataRow product)
        {
            ProductViewModel viewModel = new ProductViewModel()
            {
                Id = (int)product["id_prodotto"],
                nome = (string)product["nome"],
                descrizione = (string)product["descrizione"],
                size = new Size((string)product["grandezza"]),
                priceBuy = (decimal?)product["price_buy"],
                foto= new image( (int)product["id_foto"], System.Convert.ToBase64String((byte[])product["img"]))
            };
            
            return viewModel;
        }
        public static ProductViewModel mapRowRent(DataRow product)
        {
            ProductViewModel viewModel = new ProductViewModel()
            {
                Id = (int)product["id_prodotto"],
                nome = (string)product["nome"],
                descrizione = (string)product["descrizione"],
                size = new Size((string)product["grandezza"]),
                priceRent = (decimal?)product["price_rent"],
                foto = new image((int)product["id_foto"], System.Convert.ToBase64String((byte[])product["img"]))
            };

            return viewModel;
        }
        public static ProductViewModel mapRowSellRent(DataRow product)
        {
            ProductViewModel viewModel = new ProductViewModel()
            {
                Id = (int)product["id_prodotto"],
                nome = (string)product["nome"],
                descrizione = (string)product["descrizione"],
                size = new Size((string)product["grandezza"]),
                priceBuy = (decimal?)product["price_buy"],
                priceRent = (decimal?)product["price_rent"],
                foto = new image((int)product["id_foto"], System.Convert.ToBase64String((byte[])product["img"]))
            };

            return viewModel;
        }
    }
}
