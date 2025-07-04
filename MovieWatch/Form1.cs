using System;
using System.Windows.Forms;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;
using System.Linq;
using System.Configuration; // Para acceder a la clave de la API desde App.config


//             //

namespace MovieWatch
{
    public partial class Form1 : Form
    {
        private const string BASE_URL = "https://api.themoviedb.org/3";
        private readonly string API_KEY = ConfigurationManager.AppSettings["TMDbApiKey"];
        private const string idioma = "en-EN"; // Idioma por defecto - inglés (en-EN) - "es-ES" español
        private readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            lstPeliculas.SelectedIndexChanged += lstPeliculas_SelectedIndexChanged;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await BuscarPeliculasPopulares();
        }

        private async void btnUltimas_Click(object sender, EventArgs e)
        {
            await BuscarPeliculasRecientes();
        }

        private async void btnBuscarTorrents_Click(object sender, EventArgs e)
        {
            lstPeliculas.Items.Clear();
            txtDescripcion.Text = "";
            picPoster.Image = null;

            var torrents = await BuscarTorrentsDesdeApi();

            foreach (var torrent in torrents)
            {
                lstPeliculas.Items.Add(new Pelicula
                {
                    Titulo = torrent.Titulo,
                    Descripcion = torrent.MagnetLink,
                    PosterPath = null, // no hay imagen
                    Puntuacion = null,
                    FechaEstreno = null
                });
            }

            MessageBox.Show($"Se encontraron {torrents.Count} torrents.");
        }



        // metodo que se ejecuta cuando el usuario selecciona una peli de la lista
        private async void lstPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pelicula peli = lstPeliculas.SelectedItem as Pelicula;

            if (peli != null)
            {
                txtDescripcion.Text = $"⭐ {peli.Puntuacion} - {peli.FechaEstreno}\n\n{peli.Descripcion}";

                if (!string.IsNullOrEmpty(peli.PosterPath))
                {
                    string posterUrl = $"https://image.tmdb.org/t/p/w500{peli.PosterPath}";

                    try
                    {
                        var imageStream = await httpClient.GetStreamAsync(posterUrl);
                        picPoster.Image = Image.FromStream(imageStream);
                    }
                    catch
                    {
                        picPoster.Image = null;
                    }
                }
                else
                {
                    picPoster.Image = null;
                }
                if (peli.Descripcion?.StartsWith("magnet:") == true)
                {
                    Clipboard.SetText(peli.Descripcion);
                    //aca cosa que si hace click aparezca el boton
                    btnAbrirMagnet.Visible = true;
                    btnStremearTorrent.Visible = true;
                }

            }
        }

        private async Task BuscarPeliculasRecientes()
        {
            lstPeliculas.Items.Clear();
            txtDescripcion.Text = "";
            picPoster.Image = null;

            // cambio el endpoint para ver lo más nuevo en cines o sea las ultimas pelis algo asi ni idea
            string url = $"{BASE_URL}/movie/now_playing?api_key={API_KEY}&language={idioma}&page=1";

            try
            {
                string jsonResponse = await httpClient.GetStringAsync(url);
                JObject json = JObject.Parse(jsonResponse);

                foreach (var peli in json["results"])
                {
                    var movie = new Pelicula
                    {
                        Titulo = peli["title"]?.ToString(),
                        Descripcion = peli["overview"]?.ToString(),
                        PosterPath = peli["poster_path"]?.ToString(),
                        Puntuacion = peli["vote_average"]?.ToString(),
                        FechaEstreno = peli["release_date"]?.ToString()
                    };

                    lstPeliculas.Items.Add(movie);
                }
                // ESTO ME QUEDO COMO EL ORTO, SI DESCOMENTO SE VA TODO A LA MIERDA
                //var torrents = await BuscarTorrentsTop48h();

                //foreach (var movie in lstPeliculas.Items.OfType<Pelicula>())
                //{
                //    // Buscamos si hay algún torrent que contenga el título de la peli (case insensitive)
                //    var match = torrents.FirstOrDefault(t => t.Titulo.IndexOf(movie.Titulo, StringComparison.OrdinalIgnoreCase) >= 0);

                //    if (match != null)
                //    {
                //        // Mostramos un mensaje (podés hacer algo más lindo si querés)
                //        DialogResult r = MessageBox.Show($"Match encontrado para '{movie.Titulo}':\n\n{match.MagnetLink}\n\n¿Copiar link al portapapeles?",
                //            "Torrent encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                //        if (r == DialogResult.Yes)
                //        {
                //            Clipboard.SetText(match.MagnetLink);
                //        }
                //    }
                //}
                //var torrentss = await BuscarTorrentsTop48h();
                //System.Diagnostics.Debug.WriteLine($"Se obtuvieron {torrents.Count} torrents desde PirateBay.");

                //foreach (var movie in lstPeliculas.Items.OfType<Pelicula>())
                //{
                //    var match = torrents.FirstOrDefault(t => t.Titulo.IndexOf(movie.Titulo, StringComparison.OrdinalIgnoreCase) >= 0);

                //    if (match != null)
                //    {
                //        System.Diagnostics.Debug.WriteLine($"Match encontrado: {movie.Titulo} con torrent {match.Titulo}");

                //        DialogResult r = MessageBox.Show($"Match encontrado para '{movie.Titulo}':\n\n{match.MagnetLink}\n\n¿Copiar link al portapapeles?",
                //            "Torrent encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                //        if (r == DialogResult.Yes)
                //        {
                //            Clipboard.SetText(match.MagnetLink);
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con TMDb:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task BuscarPeliculasPopulares()
        {
            //primero limpiamos lo que haya en la lista
            lstPeliculas.Items.Clear();
            txtDescripcion.Text = string.Empty;
            picPoster.Image = null;

            //armar link de peticion con la api key y el idioma
            string url = $"{BASE_URL}/movie/popular?api_key={API_KEY}&language={idioma}&page=1";

            try
            {
                //pedimos los datos a la API, nos devuelve json en texto
                string jsonResponse = await httpClient.GetStringAsync(url);
                //convertir a objeto JSON que se pueda recorrer
                JObject json = JObject.Parse(jsonResponse);

                //iteramos sobre cada peli en resultados
                foreach (var peli in json["results"])
                {
                    //creamos el objeto pelicula con la info que deseamos
                    var movie = new Pelicula
                    {
                        Titulo = peli["title"]?.ToString(),
                        Descripcion = peli["overview"]?.ToString(),
                        PosterPath = peli["poster_path"]?.ToString()
                    };
                    lstPeliculas.Items.Add(movie);
                    //console log the json response
                    System.Diagnostics.Debug.WriteLine(jsonResponse);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con TMDb:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<Torrent>> BuscarTorrentsDesdeApi()
        {
            var torrents = new List<Torrent>();
            string url = "https://apibay.org/precompiled/data_top100_all.json";

            try
            {
                string json = await httpClient.GetStringAsync(url);
                JArray data = JArray.Parse(json);

                foreach (var item in data)
                {
                    torrents.Add(new Torrent
                    {
                        Titulo = item["name"]?.ToString(),
                        MagnetLink = $"magnet:?xt=urn:btih:{item["info_hash"]}"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener torrents:\n" + ex.Message);
            }

            return torrents;
        }

        private async Task<List<Torrent>> BuscarTorrentsPorNombre(string nombre)
        {
            var torrents = new List<Torrent>();
            string url = $"https://apibay.org/q.php?q={Uri.EscapeDataString(nombre)}";

            try
            {
                string json = await httpClient.GetStringAsync(url);
                JArray data = JArray.Parse(json);

                foreach (var item in data)
                {
                    torrents.Add(new Torrent
                    {
                        Titulo = item["name"]?.ToString(),
                        MagnetLink = $"magnet:?xt=urn:btih:{item["info_hash"]}"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar torrents:\n" + ex.Message);
            }

            return torrents;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void txtBuscarTorrent_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnBuscarPorNombre_Click(object sender, EventArgs e)
        {
            string consulta = txtBuscarTorrent.Text.Trim();

            if (string.IsNullOrWhiteSpace(consulta))
            {
                MessageBox.Show("Escribí algo para buscar.");
                return;
            }

            lstPeliculas.Items.Clear();
            txtDescripcion.Text = "";
            picPoster.Image = null;

            var torrents = await BuscarTorrentsPorNombre(consulta);

            foreach (var t in torrents)
            {
                lstPeliculas.Items.Add(new Pelicula
                {
                    Titulo = t.Titulo,
                    Descripcion = t.MagnetLink
                });
            }

            if (torrents.Count == 0)
                MessageBox.Show("No se encontraron torrents.");
        }

        private void btnStremearTorrent_Click(object sender, EventArgs e)
        {
            if (lstPeliculas.SelectedItem is Pelicula peli && peli.Descripcion?.StartsWith("magnet:") == true)
            {
                // Verificamos si webtorrent está instalado
                bool webtorrentDisponible = false;

                try
                {
                    var check = new System.Diagnostics.Process
                    {
                        StartInfo = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = "cmd.exe",
                            Arguments = "/C webtorrent -v",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };

                    check.Start();
                    string output = check.StandardOutput.ReadToEnd();
                    check.WaitForExit();
                    MessageBox.Show($"WebTorrent output:\n{output}");

                    if (!string.IsNullOrWhiteSpace(output) && System.Text.RegularExpressions.Regex.IsMatch(output.Trim(), @"^\d+\.\d+"))
                    {
                        webtorrentDisponible = true;
                    }
                }
                catch
                {
                    webtorrentDisponible = false;
                }

                if (!webtorrentDisponible)
                {
                    MessageBox.Show("WebTorrent CLI no está instalado.\n\nInstalalo con:\nnpm install -g webtorrent-cli", "Falta WebTorrent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si está disponible, lo ejecutamos
                try
                {
                    var psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "webtorrent.cmd", // usa directamente el .cmd por seguridad
                        Arguments = $"{peli.Descripcion} --vlc",
                        UseShellExecute = false,
                        CreateNoWindow = false
                    };

                    System.Diagnostics.Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al intentar stremear:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccioná un torrent válido con enlace magnet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAbrirMagnet_Click_1(object sender, EventArgs e)
        {
            if (lstPeliculas.SelectedItem is Pelicula peli && peli.Descripcion?.StartsWith("magnet:") == true)
            {
                try
                {
                    var psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = peli.Descripcion,
                        UseShellExecute = true // Importante para abrir links o protocolos
                    };

                    System.Diagnostics.Process.Start(psi);
                    Console.WriteLine("Intentando abrir magnet: " + peli.Descripcion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el enlace magnet:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccioná un torrent válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lstPeliculas_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}      
// Esta clase representa una película, con sus datos básicos
public class Pelicula
        {
            public string Titulo { get; set; }         // Título de la peli
            public string Descripcion { get; set; }    // Descripción o sinopsis
            public string PosterPath { get; set; }     // Ruta al archivo de imagen del póster
            public string Puntuacion { get; set; }
            public string FechaEstreno { get; set; }

            // Esto hace que el ListBox muestre el título en vez del nombre de la clase
            public override string ToString() => Titulo;
        }  
public class Torrent
        {
            public string Titulo { get; set; }
            public string MagnetLink { get; set; }
        }
