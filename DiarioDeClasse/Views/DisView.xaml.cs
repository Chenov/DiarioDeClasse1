using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DiarioDeClasse.Views
{
    public class Disciplina
    {
        public string nome { get; set; }
        public decimal carga { get; set; }
        public string CargaFormatada
        {
            get
            {
                return string.Format("Carga horária de {0} horas", carga);
            }
        }

        public FormattedString DisLabel
        {
            get
            {
                return new FormattedString
                {
                    Spans = {
                        new Span { Text = nome },
                        new Span { Text = " - " },
                        new Span { Text = CargaFormatada, FontAttributes = FontAttributes.Bold } }
                };
            }
            set { }
        }
    }

    public partial class DisView : ContentPage
    {
        public List<Disciplina> Disciplina { get; set; }

        public DisView()
        {
            InitializeComponent();

            this.Disciplina = new List<Disciplina>()
            {
                new Disciplina { nome = "Linguagem de Programação III", carga = 45 },
                new Disciplina { nome = "Linguagem de Programação IV", carga = 60 },
                new Disciplina { nome = "Linguagem de Programação Mobile", carga = 60 },
                new Disciplina { nome = "Interdisciplinar", carga = 60 }
         
            };

            this.BindingContext = this;
        }

        private void listViewDisciplina_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var disciplina = (Disciplina)e.Item;

            Navigation.PushAsync(new DetView(disciplina));
        }
    }
}