//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

/* Le asignamos a la clase Recipe la responsabilidad de de implementar el metodo GetProductionCost, ya que la clase conoce 
toda la informacion para implementarlo. Por lo tanto se usa el patron Expert. 
La clase conoce la lista de pasos a seguir para hacer un producto, por lo tanto conoce la cantidad, el precio unitario, el costo
del equipamiento y el tiempo del uso, que es lo que se necesita para el metodo.
Los beneficios de utilizar este patron son:
- Se mantiene el encapsulamiento, los objetos usan su propia informacion.
- Se distribuye el comportamiento entre las clases que contienen la informacion.
*/

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();
        private Product finalProduct;
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
            Console.WriteLine($"Costo total de producción: {this.GetProductionCost()}");
        }

        /* Esta clase tiene toda la información necesaria para implementar la responsabilidad de calcular el costo total de producción
        por lo tanto es la experta en información. Lo que estamos haciendo es aplicar el patrón experto.*/

        public double GetProductionCost()
        {
            double costoInsumos = 0;
            double costoEquipamiento = 0;

            foreach (Step paso in steps)
            {
                costoInsumos += paso.Input.UnitCost * paso.Quantity;
                costoEquipamiento += paso.Equipment.HourlyCost * paso.Time;
            }

            return costoInsumos + costoEquipamiento;
        }
    }
}
