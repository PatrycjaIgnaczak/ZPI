using System;
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
            { State.Alabama,            new StateData("Alabama", 13.5f, 13.5f, 4, 13.5f, 13.5f) },
            { State.Alaska,             new StateData("Alaska", 0, 0, 0, 0, 0) },
            { State.Arizona,            new StateData("Arizona", 5.6f, 10.725f, 5.6f, 10.725f, 10.725f) },
            { State.Arkansas,           new StateData("Arkansas", 11.625f, 11.625f, 6.5f, 11.625f, 11.625f ) },
            { State.California,         new StateData("California", 7.25F, 9.75f, 7.25F, 9.75f, 9.75f) },
            { State.Colorado,           new StateData("Colorado", 2.9f, 10, 2.9f, 10, 2.9f) },
            { State.Connecticut,        new StateData("Connecticut", 6.35f, 6.35f, 6.35f, 6.35f, 6.35f) },
            { State.Delaware,           new StateData("Delaware", 0, 0, 0, 0, 0) },
            { State.DistrictOfColumbia, new StateData("DistrictOfColumbia", 5.75f, 5.75f, 5.75f, 5.75f, 5.75f) },
            { State.Florida,            new StateData("Florida", 6, 7.5f, 6, 7.5f, 7.5f) },
            { State.Georgia,            new StateData("Georgia", 8, 8, 4, 8, 9) },
            { State.Guam,               new StateData("Guam", 4, 4, 4, 4, 4) },
            { State.Hawaii,             new StateData("Hawaii", 4.712f, 4.712f, 4.712f, 4.712f, 4.712f) },
            { State.Idaho,              new StateData("Idaho", 8.5f, 8.5f, 6, 8.5F, 8.5f) },
            { State.Illinois,           new StateData("Illinois", 10.25f, 10.25f, 10.25f, 10.25f, 10.25f) },
            { State.Indiana,            new StateData("Indiana", 7, 7, 7, 7, 7) },
            { State.Iowa,               new StateData("Iowa", 6, 7, 6, 7, 7) },
            { State.Kansas,             new StateData("Kansas", 10.15f, 10.15f, 10.15f, 10.15f, 10.15f) }
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
