using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyFrankenstein.Models
{
    public class Monster                            // Main monster class 
    {
        [Key]                                       // User input Monster fields
        public int MonsterID { get; set; }
        [StringLength(30), Required]
        public string Name { get; set; }            //   Monster name
        [StringLength(20)]
        public string Family { get; set; }          //   Type of monster (ie: ghost, etc.)
        [StringLength(500), Required]
        public string Description { get; set; }     //   Sentence or paragraph descriptor
        public string ImgName { get; set; }         //   Image file to upload (via File browser)

        public string ImgUrl { get; set; }          //   Local URL on file server
        public string ImgType { get; set; }         //   Image file type (only jpg, gif, png allowed)
        public byte[] ImgThumb { get; set; }        //   Small thumbnail image for index 
        public string Contributor { get; set; }     //   Creator user (for edit/delete access)
    }

    public class MonsterPics                        // Will put image in filesystem (this not needed)
    {
        public int ImageID { get; set; }            //   but would do this way if storing in DB
        public byte[] MonsterImage { get; set; }    
        public int MonsterID { get; set; }          
    }

    public class MonsterDBContext : DbContext
    {
        public DbSet<Monster> Monsters { get; set; }
    }
}