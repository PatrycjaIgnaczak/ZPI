﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class StateData
    {
        private static Dictionary<State, StateData> states = new Dictionary<State, StateData>
        {
            { State.Alabama, new StateData("Alabama", 13.5f, 13.5f, 4, 13.5f, 13.5f) },
            { State.Alaska, new StateData("Alaska", 0, 0, 0, 0, 0) },
            { State.Arizona, new StateData("Arizona", 5.6f, 10.725f, 5.6f, 10.725f, 10.725f) },
            { State.Arkansas, new StateData("Arkansas", 11.625f, 11.625f, 6.5f, 11.625f, 11.625f ) },
            { State.California, new StateData("California", 7.25F, 9.75f, 7.25F, 9.75f, 9.75f) },
          
                   
        };

        public static List<string> getStateNames()
        {
            return states.Values.Select<StateData, string>(state => state.Name).ToList();
        }

        public static StateData info(State state)
        {
            return states[state];
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        private double groceries;
        private double preparedFood;
        private double prescriptionDrug;
        private double nonPrescriptedDrug;
        private double clothing;

        public StateData() { }

        public StateData(string name, 
            double groceries, 
            double preparedFood, 
            double prescriptionDrug, 
            double nonPrescriptedDrug, 
            double clothing)
        {
            this.name = name;
            this.groceries = groceries;
            this.preparedFood = preparedFood;
            this.prescriptionDrug = prescriptionDrug;
            this.nonPrescriptedDrug = nonPrescriptedDrug;
            this.clothing = clothing;
        }

        public double Tax(ProductType type)
        {
            switch (type)
            {
                case ProductType.Clothing:
                    return clothing;
                case ProductType.Groceries:
                    return groceries;
                case ProductType.NonPrescriptionDrug:
                    return nonPrescriptedDrug;
                case ProductType.PreparedFood:
                    return preparedFood;
                case ProductType.PrescriptionDrug:
                    return prescriptionDrug;
                default:
                    throw new Exception();
            }
        }

        public static StateData StateTax(State state)
        {
            return null;
        }
    }
}
