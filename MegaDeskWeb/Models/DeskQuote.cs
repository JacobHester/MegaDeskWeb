﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MegaDeskWeb
{
    public class DeskQuote {
        public int DeskQuoteID { get; set; }
        public int DeskID { get; set; }
        public Desk Desk { get; set; }
        public string Name { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal Price { get; set; }
        public int ShipSelector {get;set;}
        public int RushShippingID { get; set; }
        [BindProperty]
         public RushShipping RushShipping { get; set; }

        public decimal QuoteTotal(DeskQuote deskQuote)
        {
            /////////////////////////////// Variables ///////////////////////
            //Declare Variables for calculations
            decimal quoteTotal = 200;
            var surfaceMaterialCost = 0;
            var additionalMaterialCost = 0;
            var rushCost = 0;

            //Varialbles with values from deskQuote
            var surfaceMaterial = deskQuote.Desk.SurfaceMaterial.ToString();
    // TO BE FIXED var rushValue = deskQuote.Rush.ToString();

            //Variable with calculations
            var surfaceArea = deskQuote.Desk.Depth * deskQuote.Desk.Width;
            var drawerCost = deskQuote.Desk.NumDrawers * 50;

            //RushShipping Prices from .txt file
            String input = File.ReadAllText("rushOrderPrices.txt");
            int[,] rushArray = new int[3, 3];
            int i, j;
            var counter = 0;
            string[] parsedInput = input.Split('\n');
            for (i = 0; i<3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    int.TryParse( parsedInput[counter],out rushArray[i,j]);
                    counter++;
                }
      
            }

            ///////////////////////////// Calculations /////////////////////////

            //Determine if additional material is needed
            if ((surfaceArea) > 1000)
            {
                additionalMaterialCost = (int) surfaceArea - 1000;
            }

            //Determine Surface Material Cost
            if (surfaceMaterial == "Oak") {
                surfaceMaterialCost = 200; }
            else if (surfaceMaterial == "Laminate") {
                surfaceMaterialCost = 100; }
            else if (surfaceMaterial == "Pine") {
                surfaceMaterialCost = 50; }
            else if (surfaceMaterial == "Rosewood") {
                surfaceMaterialCost = 300; }
            else { surfaceMaterialCost = 125; } //Veneer

         
            //Determine RushShipping Cost
            /*
            if (rushValue == "Three_Day")
            {
                if (surfaceArea <= 1000)
                {
                    rushCost = rushArray[0,0];
                }
                else if (surfaceArea > 2000)
                {
                    rushCost = rushArray[0,2];
                }
                else { rushCost = rushArray[0,1]; }
            }
            else if (rushValue == "Five_Day")
            {
                if (surfaceArea <= 1000)
                {
                    rushCost = rushArray[1,0];
                }
                else if (surfaceArea > 2000)
                {
                    rushCost = rushArray[1,2];
                }
                else { rushCost = rushArray[1,1]; }
            }
            else if (rushValue == "Seven_Day")
            {
                if (surfaceArea <= 1000)
                {
                    rushCost = rushArray[2,0];
                }
                else if (surfaceArea > 2000)
                {
                    rushCost = rushArray[2,2];
                }
                else { rushCost = rushArray[2,1]; }
            }
            */
            Price = quoteTotal + additionalMaterialCost + surfaceMaterialCost + rushCost + drawerCost;
            return Price;
        }
    }

    //toString("c")
    //Json array of deskquote with desk inside

    
}
