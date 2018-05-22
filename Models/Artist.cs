using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcComic.Models
{
    /// <summary>
    /// Represents a comic book artist.
    /// </summary>
    public class Artist
    {
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }

        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<ComicBookArtist> ComicBooks { get; set; }
    }
}