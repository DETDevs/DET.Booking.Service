using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class FormConfig
    {
        public string Title { get; set; }                      // Ej: "Registro de Usuario"
        public string Description { get; set; }                // Texto opcional debajo del título
        public List<FormInput> Inputs { get; set; } = new();    // Lista de inputs
        public List<FormButton> Buttons { get; set; } = new();  // Lista de botones
    }

    public class FormInput
    {
        public string Label { get; set; }       // Texto visible (Ej: "Correo Electrónico")
        public string Name { get; set; }        // Nombre del campo (Ej: "email")
        public string Type { get; set; }        // text, email, password, number, etc.
        public bool Required { get; set; }      // Si es obligatorio
        public string Placeholder { get; set; } // Texto de ayuda
        public string DefaultValue { get; set; } // Valor inicial opcional
    }

    public class FormButton
    {
        public string Text { get; set; }        // Texto visible en el botón
        public string Action { get; set; }      // Acción que ejecuta (submit, cancel, etc.)
        public string Color { get; set; }       // Color del botón
    }

    public class FormLabel
    {
        public string Text { get; set; }      // Texto de la etiqueta
        public string For { get; set; }       // ID o nombre del elemento al que apunta
        public string Color { get; set; }     // Color opcional
    }

}
