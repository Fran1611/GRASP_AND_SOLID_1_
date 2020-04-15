//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

/* Le asignamos a la clase Recipe la responsabilidad de de implementar el metodo GetProductionCost, ya que la clase conoce 
toda la informacion para implementarlo. Por lo tanto se usa el patron Expert. 
Los beneficios de utilizar este patron son:
- Se mantiene el encapsulamiento, los objetos usan su propia informacion.
- Se distribuye el comportamiento entre las clases que contienen la informacion.
*/

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
                
            }
            Console.WriteLine("el precio de produccion es " + GetProductionCost());
        }
        
        // Método para obtener el costo de producción.
        public double GetProductionCost()
        {   
        double costoFinal = 0;
            
            foreach(Step step in steps)
            {
                costoFinal += (step.Quantity/1000 * step.Input.UnitCost) + (step.Time/3600 * (step.Equipment.HourlyCost));
            }
            return costoFinal;
        }
    }
}
