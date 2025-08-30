using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class AppDbContext :IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Furkan;initial catalog=SpotiWaveDb; integrated Security=true;trust server certificate=true");
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SongArtist> SongArtists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------------------------------
            // Song - Artist (çok-çok) via SongArtist
            // -------------------------------
            modelBuilder.Entity<SongArtist>()
                .HasKey(sa => new { sa.SongId, sa.ArtistId });

            modelBuilder.Entity<SongArtist>()
                .HasOne(sa => sa.Song)
                .WithMany(s => s.SongArtists)
                .HasForeignKey(sa => sa.SongId)
                .OnDelete(DeleteBehavior.Cascade); // Song silindiğinde ilişkili SongArtist silinsin

            modelBuilder.Entity<SongArtist>()
                .HasOne(sa => sa.Artist)
                .WithMany(a => a.songArtists)
                .HasForeignKey(sa => sa.ArtistId)
                .OnDelete(DeleteBehavior.Cascade); // Artist silindiğinde ilişkili SongArtist silinsin

            // -------------------------------
            // Album - Song (1-çok)
            // -------------------------------
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Cascade); // Album silindiğinde şarkılar silinsin

            // -------------------------------
            // Artist - Album (1-çok)
            // -------------------------------
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.Restrict); // Artist silinse bile albümler silinmesin

            // -------------------------------
            // Song - Genre (1-çok)
            // -------------------------------
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Genres)
                .WithMany()
                .HasForeignKey(s => s.GenresId)
                .OnDelete(DeleteBehavior.Restrict); // Genre silinse bile şarkılar silinmesin

            // -------------------------------
            // Playlist - Song (çok-çok) via PlaylistSong
            // -------------------------------
            modelBuilder.Entity<PlaylistSong>()
                .HasKey(ps => new { ps.PlayListId, ps.SongId });

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.PlayList)
                .WithMany(p => p.playlistSongs)
                .HasForeignKey(ps => ps.PlayListId)
                .OnDelete(DeleteBehavior.Restrict); // Playlist silinse bile şarkılar silinmesin

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId)
                .OnDelete(DeleteBehavior.Restrict); // Song silinse bile playlistteki kayıt silinmesin (istersen cascade yapabilirsin)

            // -------------------------------
            // User - Playlist (1-çok)
            // -------------------------------
            modelBuilder.Entity<PlayList>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u.PlayLists)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Kullanıcı silinse bile playlist silinmesin
        }



    }
}