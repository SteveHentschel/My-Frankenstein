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
        [Key]
        public int MonsterID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }          // type of monster
        public string Description { get; set; }     // sentence or paragraph descriptor
        public string ImgUrl { get; set; }          //  < not really needed ? >
        public string ImgName { get; set; }         // need to load for Details View
        public string ImgType { get; set; }         //  < not really needed ? >
        public byte[] ImgThumb { get; set; }        // small thumbnail in db should be ok
        public string Contributor { get; set; }     // which user submitted the entry
    }

    public class MonsterPics                        // Not sure where to put actual image yet
    {
        public int ImageID { get; set; }            //   may store in files (~/Content/Images/)
        public byte[] MonsterImage { get; set; }    //   but will make room here in case of DB
        public int MonsterID { get; set; }          //   link to monster in case in DB
    }

    public class MonsterDBContext : DbContext
    {
        public DbSet<Monster> Monsters { get; set; }
    }
}