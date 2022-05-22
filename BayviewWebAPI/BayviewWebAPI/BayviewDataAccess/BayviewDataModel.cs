using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace BayviewDataAccess
{
    public class BayviewDataModel : DbContext
    {
        // Your context has been configured to use a 'BayviewDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BayviewDataAccess.BayviewDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BayviewDataModel' 
        // connection string in the application configuration file.
        public BayviewDataModel()
            : base("name=BayviewDataModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Image> Images { get; set; }
    }

    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
    }
}