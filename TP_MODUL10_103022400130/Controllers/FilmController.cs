using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TP_MODUL10_103022400130.Models;

namespace TP_MODUL10_103022400130.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private static List<Film> films = new List<Film>
    {
        new Film { Judul="Inception", Sutradara="Christopher Nolan", Tahun="2010", Genre="Sci-Fi", Rating="9.0" },
        new Film { Judul="Interstellar", Sutradara="Christopher Nolan", Tahun="2014", Genre="Sci-Fi", Rating="8.7" },
        new Film { Judul="Parasite", Sutradara="Bong Joon-ho", Tahun="2019", Genre="Thriller", Rating="8.6" }
    };

        [HttpGet]
        public ActionResult<List<Film>> GetAll()
        {
            return films;
        }

        [HttpGet("{id}")]
        public ActionResult<Film> GetById(int id)
        {
            if (id < 0 || id >= films.Count)
                return NotFound("Index tidak ditemukan");

            return films[id];
        }

        [HttpPost]
        public ActionResult AddFilm([FromBody] Film film)
        {
            films.Add(film);
            return Ok("Film berhasil ditambahkan");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFilm(int id)
        {
            if (id < 0 || id >= films.Count)
                return NotFound("Index tidak ditemukan");

            films.RemoveAt(id);
            return Ok("Film berhasil dihapus");
        }
    }
}
