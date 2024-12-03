using eCommerce;
using System;
using System.Windows.Forms;

namespace esecizio_applicazione_ecommerce
{
    public partial class Form1 : Form
    {
        private List<Prodotto> prodottiDisponibili = new List<Prodotto>();

        private Carrello carrello = new Carrello("C001");

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            prodottiDisponibili.Add(new Prodotto("Caricatore", "Wireless", "434", 18.99));
            prodottiDisponibili.Add(new Prodotto("Caricatore", "Wireless 3 in 1", "341", 24.99));
            prodottiDisponibili.Add(new Prodotto("Caricatore", "20W", "612", 25));
            prodottiDisponibili.Add(new Prodotto("Caricatore", "65W", "291", 35));

            // aggiungere nella listbox
            foreach (Prodotto prodotto in prodottiDisponibili)
            {
                Prodotti_listBox1.Items.Add($"{prodotto.Marca} {prodotto.Modello} - €{prodotto.Prezzo}");
            }
            //costoTotale_label.Visible= false;
        }

        private void Prodotti_listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Prodotti_listBox1.SelectedIndex;
            if (index >= 0 && index < prodottiDisponibili.Count)
            {
                Prodotto prodotto = prodottiDisponibili[index];
                label2.Text = $"Marca: {prodotto.Marca}\nModello: {prodotto.Modello}\nPrezzo: €{prodotto.Prezzo}";
            }
        }

        private void Carrello_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Carrello_listBox.SelectedIndex;
            if (index >= 0 && index < carrello.ProdottiCarrello.Count)
            {
                Prodotto prodotto = carrello.ProdottiCarrello[index];
                label2.Text = $"Selezionato dal carrello:\nMarca: {prodotto.Marca}\nModello: {prodotto.Modello}\nPrezzo: €{prodotto.Prezzo}";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rimuovi_btn_Click(object sender, EventArgs e)
        {
            int index = Carrello_listBox.SelectedIndex;
            if (index >= 0 && index < carrello.ProdottiCarrello.Count)
            {
                Prodotto prodotto = carrello.ProdottiCarrello[index];
                carrello.rimuoviProdotto(prodotto);
                Carrello_listBox.Items.RemoveAt(index);
                AggiornaTotale();
            }
            else
            {
                MessageBox.Show("Seleziona un prodotto dal carrello da rimuovere.");
            }
        }

        private void Svuota_btn_Click(object sender, EventArgs e)
        {
            carrello.svuotaCarrello();
            Carrello_listBox.Items.Clear();
            AggiornaTotale();
        }

        private void AggiornaTotale()
        {
            double totale = 0;
            foreach (Prodotto prodotto in carrello.ProdottiCarrello)
            {
                totale += prodotto.Prezzo;
            }
            costoTotale_label.Text = $"Totale: €{totale:F2}";
        }

        private void costoTotale_label_Click(object sender, EventArgs e)
        {

        }

        private void Aggiungi_btn_Click(object sender, EventArgs e)
        {
            int index  = Prodotti_listBox1.SelectedIndex;
            if (index >= 0 && index < prodottiDisponibili.Count)
            {
                Prodotto prodotto = prodottiDisponibili[index];
                carrello.aggiungiProdotto(prodotto);
                Carrello_listBox.Items.Add($"{prodotto.Marca} {prodotto.Modello} - €{prodotto.Prezzo}");
                AggiornaTotale();
            }
            else
            {
                MessageBox.Show("Seleziona un prodotto da aggiungere al carrello.");
            }
        }
    }
}
