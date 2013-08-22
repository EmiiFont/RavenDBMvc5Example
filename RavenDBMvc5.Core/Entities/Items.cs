using System;

namespace RavenDBMvc5.Core.Entities
{
    //TODO: Shouldn't this be singular? 
    public class Items
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string  Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateTime { get; set; }

    }
}