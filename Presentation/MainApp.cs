using BusinessLogic;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Presentation
{
    [XmlRoot("ArrayOfKategori")]
    public partial class MainApp : Form
    {
        KategoriHandler _kategoriHandler;
        PodcastHandler _podcastHandler;
        Validation validation;

        public MainApp()
        {
            InitializeComponent();

            _kategoriHandler = new KategoriHandler();
            _podcastHandler = new PodcastHandler();
            validation = new Validation();
            LoadPodcasts();
            LoadCategories();
        }
        private void LoadPodcasts()
        {
            var podcasts = _podcastHandler.GetAllPodcastNames();
            foreach (var podcast in podcasts)
            {
                PodcastTbl.Rows.Add(podcast.Name, podcast.NameAc, podcast.Category, podcast.Episodes.Count()); //nu sparas namn 2 ggr, i brist på den andra egenskapen tillagd i podcast.cs
            }
        }

        private void RefreshPodcastTable()
        {
            // Rensa DataGridView
            PodcastTbl.Rows.Clear();

            // Ladda om data
            LoadPodcasts();
        }

        private void LoadCategories()
        {
            var categories = _kategoriHandler.HamtaKategoriLista();

            LbCategori.Items.Clear();
            foreach (var category in categories)
            {
                if (category.Genre != null)
                {
                    LbCategori.Items.Add(category.Genre);
                }
            }
            LaggTillIListan();
        }

        private void LaggTillIListan()
        {
            LbCategori.Items.Clear();
            foreach (Kategori kategori in _kategoriHandler.HamtaKategoriLista())
            {
                if (!string.IsNullOrWhiteSpace(kategori.Genre))
                {
                    LbCategori.Items.Add(kategori.Genre);
                }
            }
            AndringarCategoricbx();
            AndringarfilterCategoricbx();
        }

        private void AddCategori_Click(object sender, EventArgs e)
        {
            string name = CatogeryBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Kategorinamnet får inte vara tomt.");
                return;
            }

            // Kontrollera om kategorin redan finns
            if (validation.IsCategoryTaken(name))
            {
                MessageBox.Show("Kategorin finns redan.");
                return;
            }

            // Skapa en ny kategori och lägg till den i din lista

            _kategoriHandler.SkapaKategori(name);

            // Uppdatera listan i användargränssnittet
            LaggTillIListan();

            CatogeryBox.Clear();
        }

        private void ChangeCategori_Click(object sender, EventArgs e)
        {
            if (LbCategori.SelectedItem != null)
            {
                int index = LbCategori.SelectedIndex;
                if (index >= 0)
                {
                    string gamlaVardet = LbCategori.SelectedItem.ToString();
                    string nyaVardet = CatogeryBox.Text;

                    if (string.IsNullOrWhiteSpace(nyaVardet))
                    {
                        MessageBox.Show("Du har inte skrivit något i kategori-fältet.");
                        return;
                    }

                    // Kontrollera om det nya namnet är unikt

                    if (validation.IsCategoryTaken(nyaVardet))
                    {
                        MessageBox.Show("Detta kategorinamn går ej att välja då det redan existerar. Välj ett annat namn.");
                        return;
                    }

                    LbCategori.Items[index] = nyaVardet;

                    Kategori updaterKategori = _kategoriHandler.HamtaKategoriLista()[index];
                    updaterKategori.Genre = nyaVardet;

                    _podcastHandler.UpdatePodcastsKategori(gamlaVardet, nyaVardet);
                    _kategoriHandler.UpdateraKategori(index, updaterKategori);

                    RefreshPodcastTable();
                    LaggTillIListan();
                }
            }
            AndringarCategoricbx();
            AndringarfilterCategoricbx();
            CatogeryBox.Clear();
        }

        private void DeleteCategori_Click(object sender, EventArgs e)
        {
            if (LbCategori.SelectedItems == null || LbCategori.SelectedItems.Count < 1)
                return;

            var result = MessageBox.Show("Vill du ta bort denna kategori?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            string taBortKategori = LbCategori.SelectedItem.ToString();

            _kategoriHandler.TaBortKategori(LbCategori.SelectedIndex);
            _podcastHandler.TaBortKategoriPodcast(taBortKategori);


            RefreshPodcastTable();
            LaggTillIListan();
            AndringarCategoricbx();
            AndringarfilterCategoricbx();
        }

        private void AndringarCategoricbx()
        {
            CategoriCbx.Items.Clear();

            List<Kategori> kategoriListan = _kategoriHandler.HamtaKategoriLista();

            foreach (Kategori kategorii in kategoriListan)
            {
                if (kategorii.Genre != null)
                {
                    CategoriCbx.Items.Add(kategorii.Genre);
                }
            }
        }

        private void AndringarfilterCategoricbx()
        {
            FilterCategorycbx.Items.Clear();

            List<Kategori> kategoriListan = _kategoriHandler.HamtaKategoriLista();

            foreach (Kategori kategorii in kategoriListan)
            {
                if (kategorii.Genre != null)
                {
                    FilterCategorycbx.Items.Add(kategorii.Genre);
                }
            }
        }

        private async void AddPodcast_Click(object sender, EventArgs e)
        {
            string namn = NamnBox.Text;
            string kategori = CategoriCbx.SelectedItem?.ToString();
            string url = URLTextBox.Text;


            if (string.IsNullOrEmpty(namn) || string.IsNullOrEmpty(kategori) || !validation.IsUrlValid(url))
            {
                MessageBox.Show("Felaktig inmatning");
                return;
            }
            Podcast? podcast = await _podcastHandler.HamataUrl(URLTextBox.Text);
            if (podcast == null)
            {
                MessageBox.Show("Kunde inte hitta någon pod, kontrollera att URL:en är korrekt.");
                URLTextBox.Clear();
                return;
            }

            podcast.NameAc = namn;
            podcast.Category = kategori;
            PodcastTbl.Rows.Add(podcast.Name, namn, kategori, podcast.Episodes.Count());
            _podcastHandler.SkapaPodacast(podcast);

            NamnBox.Clear();
            CategoriCbx.SelectedItem = null;
            URLTextBox.Clear();
        }

        private void ChangePodcast_Click(object sender, EventArgs e)
        {
            if (PodcastTbl.SelectedCells.Count > 0)
            {
                int rowIndex = PodcastTbl.SelectedCells[0].RowIndex;
                string nyttNamn = NamnBox.Text;
                string? nyKategori = CategoriCbx.SelectedItem?.ToString();  // Använd null-conditional operator här
                string? alias = PodcastTbl.Rows[rowIndex].Cells[0].Value.ToString();

                if (alias != null)
                    _podcastHandler.UpdateName(alias, nyKategori, nyttNamn);

                RefreshPodcastTable();
            }
            else
            {
                MessageBox.Show("Inget podd-flöde är markerat, eller så är ingen ändring angiven.");
            }
            NamnBox.Clear();
            CategoriCbx.SelectedItem = null;
        }

        private void DeletePodcast_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Vill du sluta preminurer på denna podcast?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;
            if (PodcastTbl.SelectedRows.Count > 0)
            {
                int rowIndex = PodcastTbl.CurrentCell.RowIndex;

                PodcastTbl.Rows.RemoveAt(rowIndex);
                _podcastHandler.DeletePodcast(rowIndex);
            }
            else
            {
                MessageBox.Show("Säkerställ att du markerat hela raden. Klicka på play-knappen längst till vänster.");
            }
        }

        private void PodcastTbl_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRow = PodcastTbl.SelectedRows;
            if (selectedRow.Count != 1)
                return;

            var row = selectedRow[0];
            var title = row.Cells[1].Value?.ToString();
            var podcast = _podcastHandler.GetInfoPodcast(title);
            if (podcast == null)
                return;

            LbEpisode.Items.Clear();
            foreach (var episode in podcast.Episodes)
            {
                if (episode.Name == null)
                    continue;

                LbEpisode.Items.Add(episode.Name);
            }
        }

        private void LbEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItems = LbEpisode.SelectedItems;
            var selectedRow = PodcastTbl.SelectedRows;
            if (selectedRow.Count != 1 || selectedItems.Count != 1)
                return;

            var row = selectedRow[0];
            var title = row.Cells[1].Value.ToString();

            var episode = selectedItems[0]?.ToString();
            var description = _podcastHandler.GetInfoPodcast(title, episode);
            TextBox1.Clear();
            TextBox1.Text = description;
        }

        private void FilterCategorycbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valdKategori = FilterCategorycbx.SelectedItem.ToString();
            FiltreraPodcasts(valdKategori);
        }

        private void FiltreraPodcasts(string valdKategori)
        {
            var podcastName = _podcastHandler.GetAllPodcastNames();

            PodcastTbl.Rows.Clear();

            var filtreradePodcasts = from Podcast in podcastName where Podcast.Category.Equals(valdKategori) select Podcast;

            foreach (var podcast in filtreradePodcasts)
            {
                int rowIndex = PodcastTbl.Rows.Add();
                PodcastTbl.Rows[rowIndex].Cells["Column1"].Value = podcast.Name;
                PodcastTbl.Rows[rowIndex].Cells["Column2"].Value = podcast.NameAc;
                PodcastTbl.Rows[rowIndex].Cells["Column3"].Value = podcast.Category;
                PodcastTbl.Rows[rowIndex].Cells["Column4"].Value = podcast.Episodes.Count();
            }

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            PodcastTbl.Rows.Clear();

            foreach (var podcast in _podcastHandler.GetAllPodcastNames())
            {
                int rowIndex = PodcastTbl.Rows.Add();
                PodcastTbl.Rows[rowIndex].Cells["Column1"].Value = podcast.Name;
                PodcastTbl.Rows[rowIndex].Cells["Column2"].Value = podcast.NameAc;
                PodcastTbl.Rows[rowIndex].Cells["Column3"].Value = podcast.Category;
                PodcastTbl.Rows[rowIndex].Cells["Column4"].Value = podcast.Episodes.Count();// Byt ut "ColumnName" med det faktiska namnet på kolumnen där du vill lägga till podcastnamnet.
            }
        }
    }
}

