using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class Car
    {
        private String _model;
        private String _color;
        private String _regNumber;

        public string Model
        {
            get => _model;
            set => _model = value;
        }

        public string Color
        {
            get => _color;
            set => _color = value;
        }

        public string RegNumber
        {
            get => _regNumber;
            set => _regNumber = value;
        }

        public Car():this("dummyModel", "dummyColor", "dummyRegNo")
        {
        }

        public Car(string model, string color, string regNumber)
        {
            _model = model;
            _color = color;
            _regNumber = regNumber;
        }

        public override string ToString()
        {
            return $"{nameof(Model)}: {_model}, {nameof(Color)}: {_color}, {nameof(RegNumber)}: {_regNumber}";
        }
    }
}
