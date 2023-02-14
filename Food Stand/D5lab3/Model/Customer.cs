namespace D5Lab3.Model
{
    public partial class Customer
    {
        public uint CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public uint FavouriteItem { get; set; }
        public string CustomerPhoto { get; set; } = null!;

        public virtual Menu FavouriteItemNavigation { get; set; } = null!;

    }
}
