﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace MvcComic.Models
{
    /// <summary>
    /// Represents a comic book.
    /// </summary>
    public class ComicBook
    {
        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }

        public int Id { get; set; }
        public int SeriesId { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        public virtual Series Series { get; set; }
        public virtual ICollection<ComicBookArtist> Artists { get; set; }

        /// <summary>
        /// The display text for a comic book.
        /// </summary>
        public string DisplayText
        {
            get
            {
                return "${Series?.Title} #{IssueNumber}";
            }
        }

        /// <summary>
        /// Adds an artist to the comic book.
        /// </summary>
        /// <param name="artist">The artist to add.</param>
        /// <param name="role">The role that the artist had on this comic book.</param>
        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist()
            {
                Artist = artist,
                Role = role
            });
        }
    }
}