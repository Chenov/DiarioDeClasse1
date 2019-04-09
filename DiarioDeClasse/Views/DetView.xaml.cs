using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DiarioDeClasse.Views
{
    public partial class DetView : ContentPage
    {
        public Disciplina Disciplina { get; set; }

        private const int VALOR_BIMESTRAL = 30;
        private const int VALOR_SEMESTRAL = 60;
        private const int VALOR_ANUAL = 120;

        public string TxtBimestral
        {
            get
            {
                return string.Format("Bimestral - Carga {0}", VALOR_BIMESTRAL);
            }
        }

        public string TxtSemestral
        {
            get
            {
                return string.Format("Semestral - Carga {0}", VALOR_SEMESTRAL);
            }
        }

        public string TxtAnual
        {
            get
            {
                return string.Format("Anual - Carga {0}", VALOR_ANUAL);
            }
        }

        bool temBimestral;
        public bool TemBimestral
        {
            get
            {
                return temBimestral;
            }
            set
            {
                temBimestral = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CagTotFormat));
            }
        }

        bool temSemestral;
        public bool TemSemestral
        {
            get
            {
                return temSemestral;
            }
            set
            {
                temSemestral = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CagTotFormat));
            }
        }

        bool temAnual;
        public bool TemAnual
        {
            get
            {
                return temAnual;
            }
            set
            {
                temAnual = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CagTotFormat));
            }
        }

        public decimal CargaTotal
        {
            get
            {
                return Disciplina.carga
                    + (TemBimestral ? VALOR_BIMESTRAL : 0)
                    + (TemSemestral ? VALOR_SEMESTRAL : 0)
                    + (TemAnual ? VALOR_ANUAL : 0);
            }
        }

        public string CagTotFormat
        {
            get
            {
                return string.Format("Carga Horaria: {0} Horas ", CargaTotal);
            }
        }

        public DetView(Disciplina disciplina)
        {
            this.Disciplina = disciplina;
            InitializeComponent();
            this.BindingContext = this;
        }

        private void botaoProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DDView(this.Disciplina));
        }
    }
}